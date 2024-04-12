using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Utils;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.Codecs.Dialogs;
using DemosCommonCode.Twain;


namespace PdfMrcCompressionDemo
{
    /// <summary>
    ///  Main form of PDF MRC Compression Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Application title.
        /// </summary>
        string _title = string.Format("VintaSoft PDF MRC Compression Demo v{0}", ImagingGlobalSettings.ProductVersion);

        /// <summary>
        /// Information about PDF MRC compression settings for images.
        /// </summary>
        Dictionary<VintasoftImage, MrcCompressionSettingsInfo> _mrcRegionsInfo = new Dictionary<VintasoftImage, MrcCompressionSettingsInfo>();

        /// <summary>
        /// Visual tool for managing rectangular selections on focused image.
        /// </summary>
        MultiRectangularSelectionTool _selectionTool = new MultiRectangularSelectionTool();

        /// <summary>
        /// Simple TWAIN manager.
        /// </summary>
        SimpleTwainManager _simpleTwainManager;

        /// <summary>
        /// Focused image.
        /// </summary>
        VintasoftImage _focusedImage = null;


        /// <summary>
        /// PDF MRC encoder for saving PDF documents with MRC compression.
        /// </summary>
        PdfMrcEncoder _pdfEncoder = new PdfMrcEncoder();

        /// <summary>
        /// PDF encoder settings.
        /// </summary>
        PdfEncoderSettings _pdfEncoderSettings = new PdfEncoderSettings();


        /// <summary>
        /// Default image segmentation command for detecting image regions on focused image.
        /// </summary>
        readonly ImageSegmentationCommand _defaultSegmentation = null;
        
        /// <summary>
        /// Current image segmentation command for detecting image regions on focused image.
        /// </summary>
        ImageSegmentationCommand _segmentation = null;


        /// <summary>
        /// Default image binarization command for detecting text and line-art regions on focused image.
        /// </summary>
        readonly ProcessingCommandBase _defaultBinarization = null;
        
        /// <summary>
        /// Current image binarization command for detecting text and line-art regions on focused image.
        /// </summary>
        ChangePixelFormatToBlackWhiteCommand _binarization = null;


        /// <summary>
        /// Determines that the selection region(s) is deleting.
        /// </summary>
        bool _isSelectionRegionDeleting;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            // load assemblies
            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();

            this.Text = _title;

            imageViewerToolStrip.ImageViewer = imageViewer;

            // subscribe to image viewer events
            imageViewer.Images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
            imageViewer.Images.ImageCollectionSavingFinished += new EventHandler(Images_ImageCollectionSavingFinished);
            imageViewer.Images.ImageSavingException += new EventHandler<ExceptionEventArgs>(Images_ImageSavingException);
            imageViewer.Images.ImageSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageSavingProgress);
            imageViewer.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(Images_ImageCollectionChanged);

            _pdfEncoder.ImageSaving += new EventHandler<ImageSavingEventArgs>(pdfEncoder_ImageSaving);
            _defaultBinarization = _pdfEncoder.MrcCompressionSettings.MaskBinarization;
            _defaultSegmentation = _pdfEncoder.MrcCompressionSettings.ImageSegmentation;

            _selectionTool.FocusedRectangleChanged += new PropertyChangedEventHandler<RectangularSelection>(selectionTool_FocusedRectangleChanged);
            _selectionTool.FocusedRectangleInteractionFinished += new EventHandler(selectionTool_FocusedRectangleInteractionFinished);
            imageViewer.VisualTool = _selectionTool;
            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog);

            // set the initial directory in open file dialog
            DemosTools.SetTestFilesFolder(openFileDialog);

            UpdateUI();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the text regions on current image.
        /// </summary>
        private Rectangle[] TextRegions
        {
            get
            {
                // create a list of text regions
                List<Rectangle> regions = new List<Rectangle>();
                // for each region selected using selection tool
                foreach (RectangularSelection rectangle in _selectionTool.Selection)
                {
                    // if selected region is text region
                    if (rectangle is RectangularTextSelection)
                        // add region to the list of text regions
                        regions.Add(Rectangle.Round(rectangle.SelectedRect));
                }

                // if there is no text regions
                if (regions.Count == 0)
                    return null;
                // if there are text regions
                else
                    return regions.ToArray();
            }
            set
            {
                // create a list of regions to remove
                List<RectangularSelection> rectanglesToRemove = new List<RectangularSelection>();
                // for each region selected using selection tool
                foreach (RectangularSelection rectangle in _selectionTool.Selection)
                {
                    // if selected region is text region
                    if (rectangle is RectangularTextSelection)
                        // add region to the list of regions to remove
                        rectanglesToRemove.Add(rectangle);
                }

                // specify that removing of selection rectangle(s) is started
                _isSelectionRegionDeleting = true;

                // for each region to remove
                foreach (RectangularSelection rectangle in rectanglesToRemove)
                    // remove region from selected regions of visual tool
                    _selectionTool.Selection.Remove(rectangle);

                // clear the combo box with text regions
                textRegionsComboBox.Items.Clear();

                // if new property value is not null
                if (value != null)
                {
                    // save information about selected regions of visual tool
                    List<RectangularSelection> imageSelection = new List<RectangularSelection>(_selectionTool.Selection);
                    // clear the selected regions of visual tool
                    _selectionTool.Selection.Clear();

                    // get the bounding box for text regions
                    Rectangle bbox = new Rectangle(0, 0, imageViewer.Image.Width, imageViewer.Image.Height);
                    // begin update of combo box with text regions
                    textRegionsComboBox.BeginUpdate();
                    // for each new text region
                    foreach (Rectangle rect in value)
                    {
                        // create a text region
                        RectangularTextSelection textRect = new RectangularTextSelection(rect, bbox);
                        // add the text region to the selected regions of visual tool
                        _selectionTool.Selection.Add(textRect);
                        // add the text region to the combo box with text regions
                        textRegionsComboBox.Items.Add(textRect);
                    }
                    // end update of combo box with text regions
                    textRegionsComboBox.EndUpdate();

                    // for each previously saved region
                    foreach (RectangularSelection rect in imageSelection)
                        // add the text region to the selected regions of visual tool
                        _selectionTool.Selection.Add(rect);
                }

                // specify that removing of selection rectangle(s) is finished
                _isSelectionRegionDeleting = false;

                // update the UI
                UpdateUI();
            }
        }

        /// <summary>
        /// Gets or sets the image regions on current image.
        /// </summary>
        private Rectangle[] ImageRegions
        {
            get
            {
                // create list of image regions
                List<Rectangle> regions = new List<Rectangle>();
                // for each region selected using selection tool
                foreach (RectangularSelection rectangle in _selectionTool.Selection)
                {
                    // if selected region is text region
                    if (rectangle is RectangularImageSelection)
                        // add region to the list of text regions
                        regions.Add(Rectangle.Round(rectangle.SelectedRect));
                }

                // if there is no image regions
                if (regions.Count == 0)
                    return null;
                // if there are text regions
                else
                    return regions.ToArray();
            }
            set
            {
                // search all image regions of image
                List<RectangularSelection> removeRectangles = new List<RectangularSelection>();
                foreach (RectangularSelection rectangle in _selectionTool.Selection)
                    if (rectangle is RectangularImageSelection)
                        removeRectangles.Add(rectangle);

                // remove all image regions of image
                foreach (RectangularSelection rectangle in removeRectangles)
                    _selectionTool.Selection.Remove(rectangle);

                imageRegionsComboBox.Items.Clear();

                if (value != null)
                {
                    // add new image regions of image

                    Rectangle bbox = new Rectangle(0, 0, imageViewer.Image.Width, imageViewer.Image.Height);
                    imageRegionsComboBox.BeginUpdate();
                    foreach (Rectangle rect in value)
                    {
                        RectangularImageSelection imageRect = new RectangularImageSelection(rect, bbox);
                        _selectionTool.Selection.Add(imageRect);
                        imageRegionsComboBox.Items.Add(imageRect);
                    }
                    imageRegionsComboBox.EndUpdate();
                }
                UpdateUI();
            }
        }

        bool _isImageRegionsSearchingInProgress = false;
        /// <summary>
        /// Gets or sets a value indicating whether searching of the image regions is in progress.
        /// </summary>      
        private bool IsImageRegionsSearchingInProgress
        {
            get
            {
                return _isImageRegionsSearchingInProgress;
            }
            set
            {
                _isImageRegionsSearchingInProgress = value;
                InvokeUpdateUI();
            }
        }

        bool _isImageSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether the image(s) is saving.
        /// </summary>    
        private bool IsImageSaving
        {
            get
            {
                return _isImageSaving;
            }
            set
            {
                _isImageSaving = value;
                InvokeUpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        #region 'File' menu

        /// <summary>
        /// Handles the Click event of openToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open dialog for file selection
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // clear image collection
                CloseAllImages();

                try
                {
                    // add image(s) to the image collection
                    AddImages(openFileDialog.FileName);
                }
                catch (Exception exc)
                {
                    DemosTools.ShowErrorMessage(exc);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of addToolStripMenuItem object.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            // open dialog for file selection
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.Multiselect = false;
                // adds image(s) to the image collection
                foreach (string fileName in openFileDialog.FileNames)
                    AddImages(fileName);
            }
        }

        /// <summary>
        /// Handles the Click event of acquireFromScannerToolStripMenuItem object.
        /// </summary>
        private void acquireFromScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acquireFromScannerToolStripMenuItem.Enabled = false;
            imageViewerToolStrip.ScanButtonEnabled = false;
            try
            {
                if (_simpleTwainManager == null)
                    _simpleTwainManager = new SimpleTwainManager(this, thumbnailViewer.Images);

                _simpleTwainManager.SelectDeviceAndAcquireImage();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                acquireFromScannerToolStripMenuItem.Enabled = true;
                imageViewerToolStrip.ScanButtonEnabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of closeAllToolStripMenuItem object.
        /// </summary>
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllImages();
        }

        /// <summary>
        /// Handles the Click event of mrcCompressionSettingsToolStripMenuItem object.
        /// </summary>
        private void mrcCompressionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMrcCompressionSettingsDialog();
        }

        /// <summary>
        /// Handles the Click event of saveToPdfToolStripMenuItem object.
        /// </summary>
        private void saveToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IsImageSaving = true;

                    if (_mrcRegionsInfo.ContainsKey(imageViewer.Image))
                        _mrcRegionsInfo[imageViewer.Image] = GetMrcCompressionSettingsInfo();
                    // save image collection
                    if (ShowMrcCompressionSettingsDialog())
                        imageViewer.Images.SaveAsync(saveFileDialog.FileName, _pdfEncoder);
                    else
                        IsImageSaving = false;
                }
                catch (EncoderException exc)
                {
                    DemosTools.ShowErrorMessage(exc);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllImages();
            this.Close();
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dialog = new AboutBoxForm())
            {
                dialog.ShowDialog();
            }
        }

        #endregion


        #region Image regions

        /// <summary>
        /// Handles the CheckedChanged event of detectImagesManualRadioButton object.
        /// </summary>
        private void detectImagesManualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable the manual search of image regions 
            manualDetectGroupBox.Enabled = detectImagesManualRadioButton.Checked;
            detectImagesAutoSettingsButton.Enabled = detectImagesManualRadioButton.Checked;

            // if manual search of image regions is enabled
            if (detectImagesManualRadioButton.Checked)
            {
                // load image regions from MRC compression settings of focused image
                this.ImageRegions = _mrcRegionsInfo[imageViewer.Image].ImageRegions;
            }
            // if manual search of image regions is disabled
            else
            {
                // save information about image regions in MRC compression settings of focused image
                _mrcRegionsInfo[imageViewer.Image].ImageRegions = this.ImageRegions;
                // clear image regions of focused image
                this.ImageRegions = null;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of detectImagesAutoRadioButton object.
        /// </summary>
        private void detectImagesAutoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            detectImagesAutoSettingsButton.Enabled = detectImagesAutoRadioButton.Checked;
        }

        /// <summary>
        /// Handles the Click event of detectImagesButton object.
        /// </summary>
        private void detectImagesButton_Click(object sender, EventArgs e)
        {
            // clear image regions
            this.ImageRegions = null;
            IsImageRegionsSearchingInProgress = true;
            try
            {
                VintasoftImage focusedImage = imageViewer.Image;

                if (_segmentation == null)
                    _segmentation = new ImageSegmentationCommand();

                _segmentation.Progress += new EventHandler<ImageProcessingProgressEventArgs>(segmentationCommand_Progress);
                try
                {
                    // execute the image segmentation command
                    _segmentation.ExecuteInPlace(focusedImage);
                }
                finally
                {
                    _segmentation.Progress -= segmentationCommand_Progress;
                }

                // get the image segmentation command results
                ReadOnlyCollection<Rectangle> result = _segmentation.Regions;
                // if image regions are detected
                if (result != null)
                {
                    // create an array of image regions
                    Rectangle[] resultArray = new Rectangle[result.Count];
                    for (int i = 0; i < resultArray.Length; i++)
                        resultArray[i] = result[i];

                    // set the array of image regions
                    this.ImageRegions = resultArray;
                }
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
            finally
            {
                IsImageRegionsSearchingInProgress = false;
            }
        }

        /// <summary>
        /// Handles the Click event of detectImagesAutoSettingsButton object.
        /// </summary>
        private void detectImagesAutoSettingsButton_Click(object sender, EventArgs e)
        {
            if (_segmentation == null)
                _segmentation = new ImageSegmentationCommand();

            // show the settings for detecting the image regions
            using (PropertyGridForm dialog = new PropertyGridForm(_segmentation, "Segmentation command settings", true))
            {
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of addImageRegionButton object.
        /// </summary>
        private void addImageRegionButton_Click(object sender, EventArgs e)
        {
            // get the bounding box for selection
            Rectangle boundingBox = new Rectangle(0, 0, imageViewer.Image.Width, imageViewer.Image.Height);
            // create the rectangular image selection
            RectangularImageSelection imageRect = new RectangularImageSelection(boundingBox);
            // add selection to a list of image regions
            imageRegionsComboBox.Items.Add(imageRect);
            // start the selection building
            _selectionTool.AddAndBuild(imageRect);
            // subscribe to the selection building event
            IInteractiveObject item = (IInteractiveObject)imageRect;
            item.InteractionController.Interaction += new EventHandler<InteractionEventArgs>(InteractionController_Interaction);
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Interaction event of InteractionController object.
        /// </summary>
        private void InteractionController_Interaction(object sender, InteractionEventArgs e)
        {
            // if image/text region building is finished
            if (e.InteractionFinished)
            {
                UpdateFocusedRectangleInfo();
                IInteractionController controller = (IInteractionController)sender;
                controller.Interaction -= InteractionController_Interaction;
                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of removeImageRegionButton object.
        /// </summary>
        private void removeImageRegionButton_Click(object sender, EventArgs e)
        {
            // get the focused selection
            RectangularSelection rect = _selectionTool.FocusedSelectionItem;
            // if image region is focused
            if (rect != null && rect is RectangularImageSelection)
            {
                // get index of focused image region
                int index = imageRegionsComboBox.Items.IndexOf(rect);
                // get a reference to image region which must be selected after removing of focused image region
                RectangularSelection newSelectedRectangle = null;
                if (index != imageRegionsComboBox.Items.Count - 1)
                    newSelectedRectangle = (RectangularSelection)imageRegionsComboBox.Items[index + 1];
                if (newSelectedRectangle == null && index > 0)
                    newSelectedRectangle = (RectangularSelection)imageRegionsComboBox.Items[index - 1];

                // remove focused image region
                _selectionTool.Selection.Remove(rect);

                // update the image regions combo box
                UpdateImageRegionsComboBox();
                // update the UI
                UpdateUI();

                // select the new focused image region
                imageRegionsComboBox.SelectedItem = newSelectedRectangle;
            }
        }

        /// <summary>
        /// Handles the Click event of removeAllImageRegionsButton object.
        /// </summary>
        private void removeAllImageRegionsButton_Click(object sender, EventArgs e)
        {
            this.ImageRegions = null;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of imageRegionsComboBox object.
        /// </summary>
        private void imageRegionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageRegionsComboBox.SelectedItem != null &&
                _selectionTool.FocusedSelectionItem != imageRegionsComboBox.SelectedItem)
                _selectionTool.FocusedSelectionItem = imageRegionsComboBox.SelectedItem as RectangularImageSelection;
        }

        /// <summary>
        /// Handles the Format event of imageRegionsComboBox object.
        /// </summary>
        private void imageRegionsComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = string.Format("{0}: {1}", imageRegionsComboBox.Items.IndexOf(e.ListItem) + 1, e.ListItem);
        }

        #endregion


        #region Text regions

        /// <summary>
        /// Handles the CheckedChanged event of detectTextManualRadioButton object.
        /// </summary>
        private void detectTextManualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable the manual search of text regions 
            manualTextPanelGroupBox.Enabled = detectTextManualRadioButton.Checked;

            // get a reference to the focused image
            VintasoftImage focusedImage = imageViewer.Image;

            // if manual search of text regions is enabled
            if (detectTextManualRadioButton.Checked)
            {
                // load text regions

                // get text regions which were selected previously
                this.TextRegions = _mrcRegionsInfo[focusedImage].TextRegions;
                // if a list of text regions is empty
                if (this.TextRegions == null)
                {
                    // if there is focused image in image viewer
                    if (focusedImage != null)
                    {
                        // create text region that covers the whole image
                        Rectangle textRegion = new Rectangle(0, 0, focusedImage.Width, focusedImage.Height);
                        Rectangle[] textRegions = new Rectangle[] { textRegion };
                        // set new text regions for focused image
                        this.TextRegions = textRegions;


                        // set focus to the new text region

                        foreach (RectangularSelection rect in _selectionTool.Selection)
                        {
                            if (rect is RectangularTextSelection)
                            {
                                _selectionTool.FocusedSelectionItem = rect;
                                break;
                            }
                        }
                    }
                }
            }
            // if manual search of text regions is disabled
            else
            {
                // save information about text regions in MRC compression settings of focused image
                _mrcRegionsInfo[focusedImage].TextRegions = this.TextRegions;
                // clear text regions of focused image
                this.TextRegions = null;
            }
        }

        /// <summary>
        /// Handles the Click event of addTextRegionButton object.
        /// </summary>
        private void addTextRegionButton_Click(object sender, EventArgs e)
        {
            // get the bounding box for selection
            Rectangle boundingBox = new Rectangle(0, 0, imageViewer.Image.Width, imageViewer.Image.Height);
            // create the rectangular text selection
            RectangularTextSelection textRect = new RectangularTextSelection(boundingBox);
            // add selection to a list of text regions
            textRegionsComboBox.Items.Add(textRect);
            // start the selection building
            _selectionTool.AddAndBuild(textRect);
            // subscribe to the selection building event
            IInteractiveObject item = (IInteractiveObject)textRect;
            item.InteractionController.Interaction += new EventHandler<InteractionEventArgs>(InteractionController_Interaction);
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of removeTextRegionButton object.
        /// </summary>
        private void removeTextRegionButton_Click(object sender, EventArgs e)
        {
            // specify that region is deleting
            _isSelectionRegionDeleting = true;

            // get the focused selection
            RectangularSelection rect = _selectionTool.FocusedSelectionItem;
            // if text region is focused
            if (rect != null && rect is RectangularTextSelection)
            {
                // get index of focused text region
                int index = textRegionsComboBox.Items.IndexOf(rect);
                // get a reference to the text region which must be selected after removing of focused text region
                RectangularSelection newSelectedRectangle = null;
                if (index != textRegionsComboBox.Items.Count - 1)
                    newSelectedRectangle = (RectangularSelection)textRegionsComboBox.Items[index + 1];
                if (newSelectedRectangle == null && index > 0)
                    newSelectedRectangle = (RectangularSelection)textRegionsComboBox.Items[index - 1];

                // remove focused text region
                _selectionTool.Selection.Remove(rect);

                // update the text regions combo box
                UpdateTextRegionsComboBox();
                // update the UI
                UpdateUI();

                // select the new focused text region
                textRegionsComboBox.SelectedItem = newSelectedRectangle;
            }

            // specify that region is deleted
            _isSelectionRegionDeleting = false;
        }

        /// <summary>
        /// Handles the Click event of removeAllTextRegionsButton object.
        /// </summary>
        private void removeAllTextRegionsButton_Click(object sender, EventArgs e)
        {
            this.TextRegions = null;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of textRegionsComboBox object.
        /// </summary>
        private void textRegionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textRegionsComboBox.SelectedItem != null &&
                _selectionTool.FocusedSelectionItem != textRegionsComboBox.SelectedItem)
                _selectionTool.FocusedSelectionItem = textRegionsComboBox.SelectedItem as RectangularTextSelection;
        }

        /// <summary>
        /// Handles the Format event of textRegionsComboBox object.
        /// </summary>
        private void textRegionsComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = string.Format("{0}: {1}", textRegionsComboBox.Items.IndexOf(e.ListItem) + 1, e.ListItem);
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the FocusedIndexChanged event of imageViewer object.
        /// </summary>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            // if there is reference to the previously focused image
            if (_focusedImage != null)
                // save the MRC compression settings for the previously focused image
                _mrcRegionsInfo[_focusedImage] = GetMrcCompressionSettingsInfo();

            // save reference to focused image
            _focusedImage = imageViewer.Image;
            // set the MRC compression settings for focused image
            SetMrcCompressionSettingsForFocusedImage();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the ImageLoadingProgress event of imageViewer object.
        /// </summary>
        private void imageViewer_ImageLoadingProgress(object sender, ProgressEventArgs e)
        {
            tbumbnailLoadingProgressToolStripProgressBar.ProgressBar.Visible = e.Progress != 100 && !e.Cancel;
            tbumbnailLoadingProgressToolStripProgressBar.ProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// Handles the KeyDown event of imageViewer object.
        /// </summary>
        private void imageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            // if delete key is down and there is focused selection
            if (e.KeyCode == Keys.Delete && _selectionTool.FocusedSelectionItem != null)
            {
                _isSelectionRegionDeleting = true;
                RectangularSelection rectangle = _selectionTool.FocusedSelectionItem;

                // get the type of items depending on the type of the selected item

                ComboBox comboBox = null;
                if (rectangle is RectangularImageSelection)
                    comboBox = imageRegionsComboBox;
                else
                    comboBox = textRegionsComboBox;

                // get the rectangle to be selected after deletion

                int index = comboBox.Items.IndexOf(rectangle);
                RectangularSelection newSelectedRectangle = null;
                if (index != comboBox.Items.Count - 1)
                    newSelectedRectangle = (RectangularSelection)comboBox.Items[index + 1];
                if (newSelectedRectangle == null && index > 0)
                    newSelectedRectangle = (RectangularSelection)comboBox.Items[index - 1];

                // remove the seelected item
                _selectionTool.Selection.Remove(rectangle);

                // update UI

                if (rectangle is RectangularImageSelection)
                    UpdateImageRegionsComboBox();
                else
                    UpdateTextRegionsComboBox();

                UpdateUI();

                // set newly selected item
                comboBox.SelectedItem = newSelectedRectangle;
                _isSelectionRegionDeleting = false;
            }
        }

        #endregion


        #region Binarization

        /// <summary>
        /// Handles the CheckedChanged event of binarizationRadioButton object.
        /// </summary>
        private void binarizationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            manualBinarizationNumericUpDown.Enabled = binarizationManualRadioButton.Checked;
            adaptiveBinarizationSettingsButton.Enabled = binarizationAdaptiveRadioButton.Checked;
        }

        /// <summary>
        /// Handles the Click event of adaptiveBinarizationButton object.
        /// </summary>
        private void adaptiveBinarizationButton_Click(object sender, EventArgs e)
        {
            if (_binarization == null)
                _binarization = new ChangePixelFormatToBlackWhiteCommand();

            _binarization.BinarizationMode = BinarizationMode.Adaptive;
            // show the adaptive binarization settings
            using (PropertyGridForm dialog = new PropertyGridForm(_binarization, "Binarization settings", true))
            {
                dialog.ShowDialog();
                _binarization.BinarizationMode = BinarizationMode.Adaptive;
            }
        }

        #endregion


        #region Visual tool

        /// <summary>
        /// Handles the FocusedRectangleChanged event of selectionTool object.
        /// </summary>
        private void selectionTool_FocusedRectangleChanged(object sender, PropertyChangedEventArgs<RectangularSelection> e)
        {
            // if focused rectangle is changed
            if (e.OldValue != null &&
                e.OldValue is RectangularTextSelection &&
                !_isSelectionRegionDeleting)
            {
                MasterCollection<RectangularSelection> collection = (MasterCollection<RectangularSelection>)_selectionTool.Selection;

                for (int i = 0; i < collection.Count; i++)
                {
                    if (collection[i] is RectangularImageSelection)
                    {
                        RectangularSelection rect = e.OldValue;
                        collection.Remove(rect);
                        collection.Insert(i, rect);
                        break;
                    }
                }
            }

            // if no new rectangle is selected 
            if (e.NewValue == null)
            {
                removeImageRegionButton.Enabled = false;
                removeTextRegionButton.Enabled = false;
                imageRegionsComboBox.SelectedItem = null;
                textRegionsComboBox.SelectedItem = null;
            }
            else
            {
                removeImageRegionButton.Enabled = e.NewValue is RectangularImageSelection;
                removeTextRegionButton.Enabled = e.NewValue is RectangularTextSelection;

                imageRegionsComboBox.SelectedItem = e.NewValue as RectangularImageSelection;
                textRegionsComboBox.SelectedItem = e.NewValue as RectangularTextSelection;
            }
        }

        /// <summary>
        /// Handles the FocusedRectangleInteractionFinished event of selectionTool object.
        /// </summary>
        private void selectionTool_FocusedRectangleInteractionFinished(object sender, EventArgs e)
        {
            UpdateFocusedRectangleInfo();
        }

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface (UI) of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application

            VintasoftImage focusedImage = imageViewer.Image;
            bool isImageOpened = imageViewer.Images.Count > 0;
            bool isImageRegionsSearchingInProgress = _isImageRegionsSearchingInProgress;
            bool isCompressing = _isImageSaving;
            bool isImageRegionsContains = ImageRegions != null;
            bool isTextRegionsContains = TextRegions != null;
            bool canApplyMrcCompressionSettings = focusedImage != null && GetIsRasterImage(focusedImage) && IsSupportedByPdfMrcEncoder(focusedImage);

            // "File" menu
            fileToolStripMenuItem.Enabled = !isImageRegionsSearchingInProgress && !isCompressing;
            closeAllToolStripMenuItem.Enabled = isImageOpened;
            saveToPdfToolStripMenuItem.Enabled = isImageOpened;

            // MRC compression settings
            mrcCompressionSettingsPanel.Enabled = isImageOpened && canApplyMrcCompressionSettings;

            // "MRC Compression" menu
            mrcCompressionSettingsToolStripMenuItem.Enabled = isImageOpened && !isImageRegionsSearchingInProgress && !isCompressing;

            // "Binarization" group box
            binarizationGroupBox.Enabled = isImageOpened && !isImageRegionsSearchingInProgress && !isCompressing;

            // "Detect images" group box
            detectImagesGroupBox.Enabled = isImageOpened && !isImageRegionsSearchingInProgress && !isCompressing;
            removeAllImageRegionsButton.Enabled = isImageRegionsContains;

            // "Text" group box
            textGroupBox.Enabled = isImageOpened && !isImageRegionsSearchingInProgress && !isCompressing;
            removeAllTextRegionsButton.Enabled = isTextRegionsContains;

            // Toolstip
            imageViewerToolStrip.SaveButtonEnabled = isImageOpened && !isImageRegionsSearchingInProgress && !isCompressing;
            imageViewerToolStrip.CanOpenFile = !isImageRegionsSearchingInProgress && !isCompressing;
            imageViewerToolStrip.CanScan = !isImageRegionsSearchingInProgress && !isCompressing;
        }

        /// <summary>
        /// Updates the user interface of MRC compression settings.
        /// </summary>
        /// <param name="info">MRC compression settings.</param>
        private void UpdateMrcUI(MrcCompressionSettingsInfo info)
        {
            // update UI of image segmentation settings
            detectImagesDefaultRadioButton.Checked = info.UseDefaultSettingsForDetectingImageRegions;
            detectImagesManualRadioButton.Checked = info.ImageRegions != null;
            detectImagesAutoRadioButton.Checked = info.ImageRegions == null && info.Segmentation != null;
            detectImagesNoneRadioButton.Checked = !info.UseDefaultSettingsForDetectingImageRegions
                && info.Segmentation == null && info.ImageRegions == null;

            // update UI of text region detection settings
            detectTextDefaultRadioButton.Checked = info.TextRegions == null;
            detectTextManualRadioButton.Checked = info.TextRegions != null;

            // update UI of binarization settings
            binarizationAutoRadioButton.Checked = info.Binarization == null;
            binarizationManualRadioButton.Checked = info.Binarization != null && info.Binarization.BinarizationMode == BinarizationMode.Threshold;
            binarizationAdaptiveRadioButton.Checked = info.Binarization != null && !binarizationManualRadioButton.Checked;
        }

        /// <summary>
        /// Updates UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        /// <summary>
        /// Updates information about the focused rectangle.
        /// </summary>
        private void UpdateFocusedRectangleInfo()
        {
            RectangularSelection selectionRectangle = _selectionTool.FocusedSelectionItem;
            if (selectionRectangle != null)
            {
                ComboBox comboBox = null;
                if (selectionRectangle is RectangularImageSelection)
                    comboBox = imageRegionsComboBox;
                else
                    comboBox = textRegionsComboBox;

                comboBox.BeginUpdate();

                int index = comboBox.Items.IndexOf(selectionRectangle);
                comboBox.Items.Remove(selectionRectangle);
                comboBox.Items.Insert(index, selectionRectangle);
                comboBox.SelectedIndex = index;

                comboBox.EndUpdate();
            }
        }

        /// <summary>
        /// Update the image regions combo box.
        /// </summary>
        private void UpdateImageRegionsComboBox()
        {
            imageRegionsComboBox.BeginUpdate();

            imageRegionsComboBox.Items.Clear();
            foreach (RectangularSelection item in _selectionTool.Selection)
                if (item is RectangularImageSelection)
                    imageRegionsComboBox.Items.Add(item);

            imageRegionsComboBox.EndUpdate();
        }

        /// <summary>
        /// Updates the text regions combo box.
        /// </summary>
        private void UpdateTextRegionsComboBox()
        {
            textRegionsComboBox.BeginUpdate();

            textRegionsComboBox.Items.Clear();
            foreach (RectangularSelection item in _selectionTool.Selection)
                if (item is RectangularTextSelection)
                    textRegionsComboBox.Items.Add(item);

            textRegionsComboBox.EndUpdate();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Adds images from file to the image collection.
        /// </summary>
        /// <param name="fileName">The name of the file to be added to the image collection.</param>
        private void AddImages(string fileName)
        {
            ImageCollection images = new ImageCollection();
            DocumentPasswordForm.EnableAuthentication(images);
            try
            {
                images.Add(fileName);

                // check vector images and images that are not supported by PDF MRC encoder
                bool containsVectorPages = false;
                bool containsUnsupportedByMrcEncoderPages = false;
                foreach (VintasoftImage image in images)
                {
                    if (!GetIsRasterImage(image))
                        containsVectorPages = true;

                    if (!IsSupportedByPdfMrcEncoder(image))
                        containsUnsupportedByMrcEncoderPages = true;
                }

                if (containsVectorPages)
                {
                    MessageBox.Show(string.Format(
                        "Document '{0}' contains vector pages.\nPDF MRC compression can be used only for color raster images.\n\nBefore using this demo, please convert your searchable PDF document to an image-only PDF document or TIFF file, for example, using ImageConverterDemo.", Path.GetFileName(fileName)),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (containsUnsupportedByMrcEncoderPages)
                {
                    MessageBox.Show(string.Format(
                        "Document '{0}' contains pages that are not supported by PDF MRC encoder.\nPDF MRC compression will be used only for color and gray images, other images will be saved using common encoder settings.", Path.GetFileName(fileName)),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                imageViewer.Images.AddRange(images.ToArray());
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
            finally
            {
                DocumentPasswordForm.DisableAuthentication(images);
            }
        }

        /// <summary>
        /// Returns a value indicating whether image is raster image.
        /// </summary>
        /// <param name="image">Image.</param>
        private bool GetIsRasterImage(VintasoftImage image)
        {
            PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(image);
            if (page == null)
                return true;
            return page.IsImageOnly;
        }

        /// <summary>
        /// Returns a value indicating whether image is supported by PDF MRC encoder.
        /// </summary>
        /// <param name="image">Image.</param>
        private bool IsSupportedByPdfMrcEncoder(VintasoftImage image)
        {
            switch (image.PixelFormat)
            {
                case PixelFormat.Bgr24:
                case PixelFormat.Gray8:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Shows a dialog with the PDF MRC encoder settings.
        /// </summary>
        private bool ShowMrcCompressionSettingsDialog()
        {
            using (PdfEncoderSettingsForm dialog = new PdfEncoderSettingsForm())
            {
                dialog.EncoderSettings = _pdfEncoder.Settings;
                dialog.AppendExistingDocumentEnabled = false;
                dialog.MrcCompressionSettings = _pdfEncoder.MrcCompressionSettings;
                bool canUseTiles = true;
                foreach (MrcCompressionSettingsInfo info in _mrcRegionsInfo.Values)
                    if (info.ImageRegions != null || info.TextRegions != null)
                    {
                        canUseTiles = false;
                        break;
                    }
                if (canUseTiles)
                {
                    dialog.IsMrcCompressionOnly = false;
                    dialog.CanEditImageTilesSettings = true;
                }
                else
                {
                    // enable only MRC compression settings
                    dialog.IsMrcCompressionOnly = true;
                    dialog.CanEditImageTilesSettings = false;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _pdfEncoder.Settings = dialog.EncoderSettings;
                    _pdfEncoder.MrcCompressionSettings = dialog.MrcCompressionSettings;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Clears the image collection.
        /// </summary>
        private void CloseAllImages()
        {
            imageViewer.Images.ClearAndDisposeItems();
            // update the UI
            UpdateUI();
        }

        #endregion


        #region Image collection

        /// <summary>
        /// Image collection is changed.
        /// </summary>
        private void Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            switch (e.Action)
            {
                case ImageCollectionChangeAction.AddImages:
                    foreach (VintasoftImage image in e.Images)
                        if (!_mrcRegionsInfo.ContainsKey(image) && IsSupportedByPdfMrcEncoder(image))
                            _mrcRegionsInfo.Add(image, new MrcCompressionSettingsInfo());
                    break;

                case ImageCollectionChangeAction.Clear:
                    _mrcRegionsInfo.Clear();
                    break;

                case ImageCollectionChangeAction.RemoveImages:
                    foreach (VintasoftImage image in e.Images)
                        _mrcRegionsInfo.Remove(image);
                    break;
            }

            UpdateUI();
        }

        /// <summary>
        /// Image saving is in progress.
        /// </summary>
        private void Images_ImageSavingProgress(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateImageSavingProgressMethod(UpdateImageSavingProgress), e);
            else
                UpdateImageSavingProgress(e);
        }

        /// <summary>
        /// Updates the image saving progress.
        /// </summary>
        private void UpdateImageSavingProgress(ProgressEventArgs e)
        {
            imageEncodingProgressToolStripProgressBar.ProgressBar.Visible = e.Progress != 100 && !e.Cancel;
            imageEncodingProgressToolStripProgressBar.ProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// Image collection saving is in progress.
        /// </summary>
        private void Images_ImageCollectionSavingProgress(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateImageSavingProgressMethod(UpdateImageCollectionSavingProgress), e);
            else
                UpdateImageCollectionSavingProgress(e);
        }

        /// <summary>
        /// Updates the image collection saving progress.
        /// </summary>
        private void UpdateImageCollectionSavingProgress(ProgressEventArgs e)
        {
            imagesEncodingProgressToolStripProgressBar.ProgressBar.Visible = e.Progress != 100 && !e.Cancel;
            imagesEncodingProgressToolStripProgressBar.ProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// Image collection saving is finished.
        /// </summary>
        private void Images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EnableImageSavingProgressBarsMethod(EnableImageSavingProgressBars), false);
            else
                EnableImageSavingProgressBars(false);

            IsImageSaving = false;
        }

        /// <summary>
        /// Enables/disables the visibility of image saving progress bar.
        /// </summary>
        private void EnableImageSavingProgressBars(bool isVisible)
        {
            imageEncodingProgressToolStripProgressBar.ProgressBar.Visible = isVisible;
            imagesEncodingProgressToolStripProgressBar.ProgressBar.Visible = isVisible;
        }

        /// <summary>
        /// Exception occurs during image collection saving.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);

            if (InvokeRequired)
                Invoke(new EnableImageSavingProgressBarsMethod(EnableImageSavingProgressBars), false);
            else
                EnableImageSavingProgressBars(false);

            IsImageSaving = false;
        }

        #endregion


        #region MRC

        /// <summary>
        /// Returns the MRC compression setting info.
        /// </summary>
        private MrcCompressionSettingsInfo GetMrcCompressionSettingsInfo()
        {
            // create the MRC compression settings
            MrcCompressionSettingsInfo info = new MrcCompressionSettingsInfo();


            // enable/disable the default algorithm for image regions search
            info.UseDefaultSettingsForDetectingImageRegions = detectImagesDefaultRadioButton.Checked;

            // if user specified the image regions manually
            if (detectImagesManualRadioButton.Checked)
                // save information about image regions
                info.ImageRegions = ImageRegions;
            else
                // clear information about image regions
                info.ImageRegions = null;

            // if user selected the automatic or manual image segmentation mode
            if (detectImagesAutoRadioButton.Checked || detectImagesManualRadioButton.Checked)
            {
                // if image segmentation command is not specified
                if (_segmentation == null)
                    // create new image segmentation command with dfault settings
                    info.Segmentation = new ImageSegmentationCommand();
                else
                    // save the image segmentation command
                    info.Segmentation = _segmentation;
            }
            else
                // image segmentation command is not specified
                info.Segmentation = null;


            // if user specified the text regions manually
            if (detectTextManualRadioButton.Checked)
                // save information about text regions
                info.TextRegions = TextRegions;
            else
                // clear information about text regions
                info.TextRegions = null;

            // if user selected automatic binarization mode
            if (binarizationAutoRadioButton.Checked)
            {
                // clear the user settings for binarization
                info.Binarization = null;
            }
            // if user selected manual or adaptive binarization mode
            else
            {
                // save the binarization command
                info.Binarization = _binarization;
                //  if user selected the manual binarization
                if (binarizationManualRadioButton.Checked)
                {
                    // save the binarization mode
                    info.Binarization.BinarizationMode = BinarizationMode.Threshold;
                    // save the binarization threshold
                    info.Binarization.Threshold = (int)manualBinarizationNumericUpDown.Value;
                }
                // if user selected the adaptive binarization
                else
                {
                    // save the binarization mode
                    info.Binarization.BinarizationMode = BinarizationMode.Adaptive;
                }
            }

            return info;
        }

        /// <summary>
        /// Sets the MRC compression setting info for focused image.
        /// </summary>
        private void SetMrcCompressionSettingsForFocusedImage()
        {
            if (_focusedImage == null)
            {
                if (imageViewer.Image != null)
                    _selectionTool.FocusedSelectionItem = null;
                return;
            }

            if (!IsSupportedByPdfMrcEncoder(_focusedImage))
            {
                this.ImageRegions = null;
                this.TextRegions = null;
                return;
            }

            MrcCompressionSettingsInfo info;

            // if there is MRC compression settings for focused image
            if (_mrcRegionsInfo.ContainsKey(_focusedImage))
            {
                // get MRC compression settings for focused image
                info = _mrcRegionsInfo[_focusedImage];
            }
            // if there is no MRC compression settings for focused image
            else
            {
                // create new instance of MRC compression settings
                info = new MrcCompressionSettingsInfo();
                // link the focused image and new MRC compression settings
                _mrcRegionsInfo.Add(_focusedImage, info);
            }

            // sets the image regions on focused image
            this.ImageRegions = info.ImageRegions;
            // sets the text regions on focused image
            this.TextRegions = info.TextRegions;

            // set the segmentation command
            _segmentation = info.Segmentation;

            // if binarization command is not specified
            if (info.Binarization == null)
            {
                // create the binarization command with default parameters
                _binarization = new ChangePixelFormatToBlackWhiteCommand();
            }
            else
            {
                // get the binarization command from MRC compression settings
                _binarization = info.Binarization;
            }
            // set the binarization threshold
            manualBinarizationNumericUpDown.Value = _binarization.Threshold;

            // update the UI with MRC compression settings
            UpdateMrcUI(info);
        }

        /// <summary>
        /// Segmentation command is in progress.
        /// </summary>
        private void segmentationCommand_Progress(object sender, ImageProcessingProgressEventArgs e)
        {
            processingToolStripProgressBar.Visible = e.Progress != 100 && !e.Cancel;
            processingToolStripProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// PDF encoder starts image saving.
        /// </summary>
        private void pdfEncoder_ImageSaving(object sender, ImageSavingEventArgs e)
        {
            // set the default settings of PDF encoder
            _pdfEncoder.MrcCompressionSettings.ImageRegions = null;
            _pdfEncoder.MrcCompressionSettings.MaskRegions = null;
            _pdfEncoder.MrcCompressionSettings.MaskBinarization = _defaultBinarization;
            _pdfEncoder.MrcCompressionSettings.ImageSegmentation = _defaultSegmentation;
      
            // if the saving image has MRC compression settings
            if (_mrcRegionsInfo.ContainsKey(e.Image))
            {
                _pdfEncoder.MrcCompressionSettings.EnableMrcCompression = true;

                // get MRC compression settings for the saving image
                MrcCompressionSettingsInfo info = _mrcRegionsInfo[e.Image];

                // copy information about text regions to the PDF encoder
                _pdfEncoder.MrcCompressionSettings.MaskRegions = info.TextRegions;

                // if image regions are not specified
                if (info.ImageRegions == null)
                {
                    // if custom algorithm for image regions search should be used
                    if (!info.UseDefaultSettingsForDetectingImageRegions)
                    {
                        // if image segmentation command is not specified
                        if (info.Segmentation == null && info.ImageRegions == null)
                            // do not use image segmentation in PDF encoder
                            _pdfEncoder.MrcCompressionSettings.ImageSegmentation = null;
                        // if image segmentation command is specified
                        else if (info.ImageRegions == null)
                            // use the image segmentation command with user settings in PDF encoder
                            _pdfEncoder.MrcCompressionSettings.ImageSegmentation = info.Segmentation;
                    }
                }
                // if image regions are specified
                else
                    // copy information about image regions to the PDF encoder
                    _pdfEncoder.MrcCompressionSettings.ImageRegions = info.ImageRegions;

                // if binarization command is not specified
                if (info.Binarization == null)
                    // use the default binarization command in PDF encoder
                    _pdfEncoder.MrcCompressionSettings.MaskBinarization = _defaultBinarization;
                // if binarization command is specified
                else
                    // use the binarization command with user settings in PDF encoder
                    _pdfEncoder.MrcCompressionSettings.MaskBinarization = info.Binarization;
            }
            else
            {
                _pdfEncoder.MrcCompressionSettings.EnableMrcCompression = false;
            }
        }

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// The delegate for <see cref="UpdateUI"/> method.
        /// </summary>
        private delegate void UpdateUIDelegate();

        /// <summary>
        /// The delegate for <see cref="UpdateImageSavingProgress"/> method.
        /// </summary>
        private delegate void UpdateImageSavingProgressMethod(ProgressEventArgs e);

        /// <summary>
        /// The delegate for <see cref="EnableImageSavingProgressBars"/> method.
        /// </summary>
        private delegate void EnableImageSavingProgressBarsMethod(bool isVisible);

        #endregion

    }
}
