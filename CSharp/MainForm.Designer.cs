namespace PdfMrcCompressionDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

         #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageViewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquireFromScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mrcCompressionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.thumbnailViewer = new Vintasoft.Imaging.UI.ThumbnailViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mrcCompressionSettingsPanel = new System.Windows.Forms.Panel();
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.detectTextManualRadioButton = new System.Windows.Forms.RadioButton();
            this.binarizationGroupBox = new System.Windows.Forms.GroupBox();
            this.binarizationAdaptiveRadioButton = new System.Windows.Forms.RadioButton();
            this.binarizationManualRadioButton = new System.Windows.Forms.RadioButton();
            this.binarizationAutoRadioButton = new System.Windows.Forms.RadioButton();
            this.adaptiveBinarizationSettingsButton = new System.Windows.Forms.Button();
            this.manualBinarizationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.detectTextDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.manualTextPanelGroupBox = new System.Windows.Forms.GroupBox();
            this.removeAllTextRegionsButton = new System.Windows.Forms.Button();
            this.removeTextRegionButton = new System.Windows.Forms.Button();
            this.addTextRegionButton = new System.Windows.Forms.Button();
            this.textRegionsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.detectImagesGroupBox = new System.Windows.Forms.GroupBox();
            this.detectImagesManualRadioButton = new System.Windows.Forms.RadioButton();
            this.manualDetectGroupBox = new System.Windows.Forms.GroupBox();
            this.removeAllImageRegionsButton = new System.Windows.Forms.Button();
            this.imageRegionsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.removeImageRegionButton = new System.Windows.Forms.Button();
            this.addImageRegionButton = new System.Windows.Forms.Button();
            this.detectImagesButton = new System.Windows.Forms.Button();
            this.detectImagesNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.detectImagesAutoRadioButton = new System.Windows.Forms.RadioButton();
            this.detectImagesAutoSettingsButton = new System.Windows.Forms.Button();
            this.detectImagesDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbumbnailLoadingProgressToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imagesEncodingProgressToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageEncodingProgressToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.processingToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.mrcCompressionSettingsPanel.SuspendLayout();
            this.textGroupBox.SuspendLayout();
            this.binarizationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualBinarizationNumericUpDown)).BeginInit();
            this.manualTextPanelGroupBox.SuspendLayout();
            this.detectImagesGroupBox.SuspendLayout();
            this.manualDetectGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageViewerToolStrip);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 54);
            this.panel1.TabIndex = 0;
            // 
            // imageViewerToolStrip
            // 
            this.imageViewerToolStrip.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip.CanPrint = false;
            this.imageViewerToolStrip.CanScan = true;
            this.imageViewerToolStrip.ImageViewer = null;
            this.imageViewerToolStrip.ScanButtonEnabled = true;
            this.imageViewerToolStrip.Location = new System.Drawing.Point(0, 24);
            this.imageViewerToolStrip.Name = "imageViewerToolStrip";
            this.imageViewerToolStrip.PageCount = 0;
            this.imageViewerToolStrip.PrintButtonEnabled = true;
            this.imageViewerToolStrip.SaveButtonEnabled = false;
            this.imageViewerToolStrip.Size = new System.Drawing.Size(846, 25);
            this.imageViewerToolStrip.TabIndex = 1;
            this.imageViewerToolStrip.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip.UseImageViewerImages = true;
            this.imageViewerToolStrip.SaveFile += new System.EventHandler(this.saveToPdfToolStripMenuItem_Click);
            this.imageViewerToolStrip.Scan += new System.EventHandler(this.acquireFromScannerToolStripMenuItem_Click);
            this.imageViewerToolStrip.OpenFile += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addToolStripMenuItem,
            this.acquireFromScannerToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.mrcCompressionSettingsToolStripMenuItem,
            this.saveToPdfToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.addToolStripMenuItem.Text = "Add...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // acquireFromScannerToolStripMenuItem
            // 
            this.acquireFromScannerToolStripMenuItem.Name = "acquireFromScannerToolStripMenuItem";
            this.acquireFromScannerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.acquireFromScannerToolStripMenuItem.Text = "Acquire from Scanner...";
            this.acquireFromScannerToolStripMenuItem.Click += new System.EventHandler(this.acquireFromScannerToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // mrcCompressionSettingsToolStripMenuItem
            // 
            this.mrcCompressionSettingsToolStripMenuItem.Name = "mrcCompressionSettingsToolStripMenuItem";
            this.mrcCompressionSettingsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.mrcCompressionSettingsToolStripMenuItem.Text = "MRC Compression Settings...";
            this.mrcCompressionSettingsToolStripMenuItem.Click += new System.EventHandler(this.mrcCompressionSettingsToolStripMenuItem_Click);
            // 
            // saveToPdfToolStripMenuItem
            // 
            this.saveToPdfToolStripMenuItem.Name = "saveToPdfToolStripMenuItem";
            this.saveToPdfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToPdfToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.saveToPdfToolStripMenuItem.Text = "Save to PDF...";
            this.saveToPdfToolStripMenuItem.Click += new System.EventHandler(this.saveToPdfToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(224, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // imageViewer
            // 
            this.imageViewer.AutoScroll = true;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(0, 0);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewer.Size = new System.Drawing.Size(434, 486);
            this.imageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.imageViewer.TabIndex = 0;
            this.imageViewer.Text = "imageViewer1";
            this.imageViewer.ImageLoadingProgress += new System.EventHandler<Vintasoft.Imaging.ProgressEventArgs>(this.imageViewer_ImageLoadingProgress);
            this.imageViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageViewer_KeyDown);
            this.imageViewer.FocusedIndexChanged += new System.EventHandler<Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs>(this.imageViewer_FocusedIndexChanged);
            // 
            // thumbnailViewer
            // 
            this.thumbnailViewer.AllowDrop = true;
            this.thumbnailViewer.AutoScroll = true;
            this.thumbnailViewer.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.thumbnailViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.thumbnailViewer.FocusedThumbnailAppearance = thumbnailAppearance1;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.thumbnailViewer.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.thumbnailViewer.Location = new System.Drawing.Point(0, 0);
            this.thumbnailViewer.MasterViewer = this.imageViewer;
            this.thumbnailViewer.Name = "thumbnailViewer";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.thumbnailViewer.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.thumbnailViewer.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.thumbnailViewer.Size = new System.Drawing.Size(160, 486);
            this.thumbnailViewer.TabIndex = 0;
            this.thumbnailViewer.Text = "thumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.thumbnailViewer.ThumbnailAppearance = thumbnailAppearance5;
            this.thumbnailViewer.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.thumbnailViewer.ThumbnailSize = new System.Drawing.Size(100, 100);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 508);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.thumbnailViewer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.mrcCompressionSettingsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(846, 486);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.imageViewer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(434, 486);
            this.panel4.TabIndex = 1;
            // 
            // mrcCompressionSettingsPanel
            // 
            this.mrcCompressionSettingsPanel.Controls.Add(this.textGroupBox);
            this.mrcCompressionSettingsPanel.Controls.Add(this.detectImagesGroupBox);
            this.mrcCompressionSettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mrcCompressionSettingsPanel.Location = new System.Drawing.Point(434, 0);
            this.mrcCompressionSettingsPanel.Name = "mrcCompressionSettingsPanel";
            this.mrcCompressionSettingsPanel.Size = new System.Drawing.Size(248, 486);
            this.mrcCompressionSettingsPanel.TabIndex = 0;
            // 
            // textGroupBox
            // 
            this.textGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textGroupBox.Controls.Add(this.detectTextManualRadioButton);
            this.textGroupBox.Controls.Add(this.binarizationGroupBox);
            this.textGroupBox.Controls.Add(this.detectTextDefaultRadioButton);
            this.textGroupBox.Controls.Add(this.manualTextPanelGroupBox);
            this.textGroupBox.Location = new System.Drawing.Point(5, 223);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Size = new System.Drawing.Size(238, 247);
            this.textGroupBox.TabIndex = 1;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text (Mask layer)";
            // 
            // detectTextManualRadioButton
            // 
            this.detectTextManualRadioButton.AutoSize = true;
            this.detectTextManualRadioButton.Location = new System.Drawing.Point(10, 42);
            this.detectTextManualRadioButton.Name = "detectTextManualRadioButton";
            this.detectTextManualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.detectTextManualRadioButton.TabIndex = 3;
            this.detectTextManualRadioButton.Text = "Manual";
            this.detectTextManualRadioButton.UseVisualStyleBackColor = true;
            this.detectTextManualRadioButton.CheckedChanged += new System.EventHandler(this.detectTextManualRadioButton_CheckedChanged);
            // 
            // binarizationGroupBox
            // 
            this.binarizationGroupBox.Controls.Add(this.binarizationAdaptiveRadioButton);
            this.binarizationGroupBox.Controls.Add(this.binarizationManualRadioButton);
            this.binarizationGroupBox.Controls.Add(this.binarizationAutoRadioButton);
            this.binarizationGroupBox.Controls.Add(this.adaptiveBinarizationSettingsButton);
            this.binarizationGroupBox.Controls.Add(this.manualBinarizationNumericUpDown);
            this.binarizationGroupBox.Location = new System.Drawing.Point(6, 140);
            this.binarizationGroupBox.Name = "binarizationGroupBox";
            this.binarizationGroupBox.Size = new System.Drawing.Size(228, 101);
            this.binarizationGroupBox.TabIndex = 2;
            this.binarizationGroupBox.TabStop = false;
            this.binarizationGroupBox.Text = "Binarization";
            // 
            // binarizationAdaptiveRadioButton
            // 
            this.binarizationAdaptiveRadioButton.AutoSize = true;
            this.binarizationAdaptiveRadioButton.Location = new System.Drawing.Point(8, 63);
            this.binarizationAdaptiveRadioButton.Name = "binarizationAdaptiveRadioButton";
            this.binarizationAdaptiveRadioButton.Size = new System.Drawing.Size(67, 17);
            this.binarizationAdaptiveRadioButton.TabIndex = 7;
            this.binarizationAdaptiveRadioButton.Text = "Adaptive";
            this.binarizationAdaptiveRadioButton.UseVisualStyleBackColor = true;
            this.binarizationAdaptiveRadioButton.CheckedChanged += new System.EventHandler(this.binarizationRadioButton_CheckedChanged);
            // 
            // binarizationManualRadioButton
            // 
            this.binarizationManualRadioButton.AutoSize = true;
            this.binarizationManualRadioButton.Location = new System.Drawing.Point(8, 40);
            this.binarizationManualRadioButton.Name = "binarizationManualRadioButton";
            this.binarizationManualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.binarizationManualRadioButton.TabIndex = 6;
            this.binarizationManualRadioButton.Text = "Manual";
            this.binarizationManualRadioButton.UseVisualStyleBackColor = true;
            this.binarizationManualRadioButton.CheckedChanged += new System.EventHandler(this.binarizationRadioButton_CheckedChanged);
            // 
            // binarizationAutoRadioButton
            // 
            this.binarizationAutoRadioButton.AutoSize = true;
            this.binarizationAutoRadioButton.Checked = true;
            this.binarizationAutoRadioButton.Location = new System.Drawing.Point(8, 17);
            this.binarizationAutoRadioButton.Name = "binarizationAutoRadioButton";
            this.binarizationAutoRadioButton.Size = new System.Drawing.Size(47, 17);
            this.binarizationAutoRadioButton.TabIndex = 5;
            this.binarizationAutoRadioButton.TabStop = true;
            this.binarizationAutoRadioButton.Text = "Auto";
            this.binarizationAutoRadioButton.UseVisualStyleBackColor = true;
            // 
            // adaptiveBinarizationSettingsButton
            // 
            this.adaptiveBinarizationSettingsButton.Enabled = false;
            this.adaptiveBinarizationSettingsButton.Location = new System.Drawing.Point(114, 60);
            this.adaptiveBinarizationSettingsButton.Name = "adaptiveBinarizationSettingsButton";
            this.adaptiveBinarizationSettingsButton.Size = new System.Drawing.Size(106, 23);
            this.adaptiveBinarizationSettingsButton.TabIndex = 4;
            this.adaptiveBinarizationSettingsButton.Text = "Settings...";
            this.adaptiveBinarizationSettingsButton.UseVisualStyleBackColor = true;
            this.adaptiveBinarizationSettingsButton.Click += new System.EventHandler(this.adaptiveBinarizationButton_Click);
            // 
            // manualBinarizationNumericUpDown
            // 
            this.manualBinarizationNumericUpDown.Enabled = false;
            this.manualBinarizationNumericUpDown.Location = new System.Drawing.Point(114, 37);
            this.manualBinarizationNumericUpDown.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.manualBinarizationNumericUpDown.Name = "manualBinarizationNumericUpDown";
            this.manualBinarizationNumericUpDown.Size = new System.Drawing.Size(106, 20);
            this.manualBinarizationNumericUpDown.TabIndex = 3;
            this.manualBinarizationNumericUpDown.Value = new decimal(new int[] {
            384,
            0,
            0,
            0});
            // 
            // detectTextDefaultRadioButton
            // 
            this.detectTextDefaultRadioButton.AutoSize = true;
            this.detectTextDefaultRadioButton.Checked = true;
            this.detectTextDefaultRadioButton.Location = new System.Drawing.Point(10, 19);
            this.detectTextDefaultRadioButton.Name = "detectTextDefaultRadioButton";
            this.detectTextDefaultRadioButton.Size = new System.Drawing.Size(204, 17);
            this.detectTextDefaultRadioButton.TabIndex = 2;
            this.detectTextDefaultRadioButton.TabStop = true;
            this.detectTextDefaultRadioButton.Text = "Default (all image area except images)";
            this.detectTextDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // manualTextPanelGroupBox
            // 
            this.manualTextPanelGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manualTextPanelGroupBox.Controls.Add(this.removeAllTextRegionsButton);
            this.manualTextPanelGroupBox.Controls.Add(this.removeTextRegionButton);
            this.manualTextPanelGroupBox.Controls.Add(this.addTextRegionButton);
            this.manualTextPanelGroupBox.Controls.Add(this.textRegionsComboBox);
            this.manualTextPanelGroupBox.Controls.Add(this.label2);
            this.manualTextPanelGroupBox.Enabled = false;
            this.manualTextPanelGroupBox.Location = new System.Drawing.Point(6, 42);
            this.manualTextPanelGroupBox.Name = "manualTextPanelGroupBox";
            this.manualTextPanelGroupBox.Size = new System.Drawing.Size(228, 92);
            this.manualTextPanelGroupBox.TabIndex = 4;
            this.manualTextPanelGroupBox.TabStop = false;
            // 
            // removeAllTextRegionsButton
            // 
            this.removeAllTextRegionsButton.Enabled = false;
            this.removeAllTextRegionsButton.Location = new System.Drawing.Point(152, 63);
            this.removeAllTextRegionsButton.Name = "removeAllTextRegionsButton";
            this.removeAllTextRegionsButton.Size = new System.Drawing.Size(68, 23);
            this.removeAllTextRegionsButton.TabIndex = 7;
            this.removeAllTextRegionsButton.Text = "Remove all";
            this.removeAllTextRegionsButton.UseVisualStyleBackColor = true;
            this.removeAllTextRegionsButton.Click += new System.EventHandler(this.removeAllTextRegionsButton_Click);
            // 
            // removeTextRegionButton
            // 
            this.removeTextRegionButton.Enabled = false;
            this.removeTextRegionButton.Location = new System.Drawing.Point(78, 63);
            this.removeTextRegionButton.Name = "removeTextRegionButton";
            this.removeTextRegionButton.Size = new System.Drawing.Size(68, 23);
            this.removeTextRegionButton.TabIndex = 2;
            this.removeTextRegionButton.Text = "Remove";
            this.removeTextRegionButton.UseVisualStyleBackColor = true;
            this.removeTextRegionButton.Click += new System.EventHandler(this.removeTextRegionButton_Click);
            // 
            // addTextRegionButton
            // 
            this.addTextRegionButton.Location = new System.Drawing.Point(4, 63);
            this.addTextRegionButton.Name = "addTextRegionButton";
            this.addTextRegionButton.Size = new System.Drawing.Size(68, 23);
            this.addTextRegionButton.TabIndex = 3;
            this.addTextRegionButton.Text = "Add";
            this.addTextRegionButton.UseVisualStyleBackColor = true;
            this.addTextRegionButton.Click += new System.EventHandler(this.addTextRegionButton_Click);
            // 
            // textRegionsComboBox
            // 
            this.textRegionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textRegionsComboBox.FormattingEnabled = true;
            this.textRegionsComboBox.Location = new System.Drawing.Point(6, 36);
            this.textRegionsComboBox.Name = "textRegionsComboBox";
            this.textRegionsComboBox.Size = new System.Drawing.Size(214, 21);
            this.textRegionsComboBox.TabIndex = 6;
            this.textRegionsComboBox.SelectedIndexChanged += new System.EventHandler(this.textRegionsComboBox_SelectedIndexChanged);
            this.textRegionsComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.textRegionsComboBox_Format);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mask regions:";
            // 
            // detectImagesGroupBox
            // 
            this.detectImagesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detectImagesGroupBox.Controls.Add(this.detectImagesManualRadioButton);
            this.detectImagesGroupBox.Controls.Add(this.manualDetectGroupBox);
            this.detectImagesGroupBox.Controls.Add(this.detectImagesNoneRadioButton);
            this.detectImagesGroupBox.Controls.Add(this.detectImagesAutoRadioButton);
            this.detectImagesGroupBox.Controls.Add(this.detectImagesAutoSettingsButton);
            this.detectImagesGroupBox.Controls.Add(this.detectImagesDefaultRadioButton);
            this.detectImagesGroupBox.Location = new System.Drawing.Point(3, 6);
            this.detectImagesGroupBox.Name = "detectImagesGroupBox";
            this.detectImagesGroupBox.Size = new System.Drawing.Size(240, 211);
            this.detectImagesGroupBox.TabIndex = 0;
            this.detectImagesGroupBox.TabStop = false;
            this.detectImagesGroupBox.Text = "Detect images (Image segmentation)";
            // 
            // detectImagesManualRadioButton
            // 
            this.detectImagesManualRadioButton.AutoSize = true;
            this.detectImagesManualRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.detectImagesManualRadioButton.Location = new System.Drawing.Point(12, 88);
            this.detectImagesManualRadioButton.Name = "detectImagesManualRadioButton";
            this.detectImagesManualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.detectImagesManualRadioButton.TabIndex = 1;
            this.detectImagesManualRadioButton.Text = "Manual";
            this.detectImagesManualRadioButton.UseVisualStyleBackColor = false;
            this.detectImagesManualRadioButton.CheckedChanged += new System.EventHandler(this.detectImagesManualRadioButton_CheckedChanged);
            // 
            // manualDetectGroupBox
            // 
            this.manualDetectGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manualDetectGroupBox.Controls.Add(this.removeAllImageRegionsButton);
            this.manualDetectGroupBox.Controls.Add(this.imageRegionsComboBox);
            this.manualDetectGroupBox.Controls.Add(this.label1);
            this.manualDetectGroupBox.Controls.Add(this.removeImageRegionButton);
            this.manualDetectGroupBox.Controls.Add(this.addImageRegionButton);
            this.manualDetectGroupBox.Controls.Add(this.detectImagesButton);
            this.manualDetectGroupBox.Enabled = false;
            this.manualDetectGroupBox.Location = new System.Drawing.Point(6, 91);
            this.manualDetectGroupBox.Name = "manualDetectGroupBox";
            this.manualDetectGroupBox.Size = new System.Drawing.Size(228, 117);
            this.manualDetectGroupBox.TabIndex = 5;
            this.manualDetectGroupBox.TabStop = false;
            // 
            // removeAllImageRegionsButton
            // 
            this.removeAllImageRegionsButton.Enabled = false;
            this.removeAllImageRegionsButton.Location = new System.Drawing.Point(154, 88);
            this.removeAllImageRegionsButton.Name = "removeAllImageRegionsButton";
            this.removeAllImageRegionsButton.Size = new System.Drawing.Size(68, 23);
            this.removeAllImageRegionsButton.TabIndex = 6;
            this.removeAllImageRegionsButton.Text = "Remove all";
            this.removeAllImageRegionsButton.UseVisualStyleBackColor = true;
            this.removeAllImageRegionsButton.Click += new System.EventHandler(this.removeAllImageRegionsButton_Click);
            // 
            // imageRegionsComboBox
            // 
            this.imageRegionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageRegionsComboBox.FormattingEnabled = true;
            this.imageRegionsComboBox.Location = new System.Drawing.Point(6, 61);
            this.imageRegionsComboBox.Name = "imageRegionsComboBox";
            this.imageRegionsComboBox.Size = new System.Drawing.Size(216, 21);
            this.imageRegionsComboBox.TabIndex = 5;
            this.imageRegionsComboBox.SelectedIndexChanged += new System.EventHandler(this.imageRegionsComboBox_SelectedIndexChanged);
            this.imageRegionsComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.imageRegionsComboBox_Format);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image regions:";
            // 
            // removeImageRegionButton
            // 
            this.removeImageRegionButton.Enabled = false;
            this.removeImageRegionButton.Location = new System.Drawing.Point(80, 88);
            this.removeImageRegionButton.Name = "removeImageRegionButton";
            this.removeImageRegionButton.Size = new System.Drawing.Size(68, 23);
            this.removeImageRegionButton.TabIndex = 2;
            this.removeImageRegionButton.Text = "Remove";
            this.removeImageRegionButton.UseVisualStyleBackColor = true;
            this.removeImageRegionButton.Click += new System.EventHandler(this.removeImageRegionButton_Click);
            // 
            // addImageRegionButton
            // 
            this.addImageRegionButton.Location = new System.Drawing.Point(6, 88);
            this.addImageRegionButton.Name = "addImageRegionButton";
            this.addImageRegionButton.Size = new System.Drawing.Size(68, 23);
            this.addImageRegionButton.TabIndex = 3;
            this.addImageRegionButton.Text = "Add";
            this.addImageRegionButton.UseVisualStyleBackColor = true;
            this.addImageRegionButton.Click += new System.EventHandler(this.addImageRegionButton_Click);
            // 
            // detectImagesButton
            // 
            this.detectImagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detectImagesButton.Location = new System.Drawing.Point(6, 19);
            this.detectImagesButton.Name = "detectImagesButton";
            this.detectImagesButton.Size = new System.Drawing.Size(111, 23);
            this.detectImagesButton.TabIndex = 0;
            this.detectImagesButton.Text = "Detect images";
            this.detectImagesButton.UseVisualStyleBackColor = true;
            this.detectImagesButton.Click += new System.EventHandler(this.detectImagesButton_Click);
            // 
            // detectImagesNoneRadioButton
            // 
            this.detectImagesNoneRadioButton.AutoSize = true;
            this.detectImagesNoneRadioButton.Location = new System.Drawing.Point(12, 42);
            this.detectImagesNoneRadioButton.Name = "detectImagesNoneRadioButton";
            this.detectImagesNoneRadioButton.Size = new System.Drawing.Size(51, 17);
            this.detectImagesNoneRadioButton.TabIndex = 4;
            this.detectImagesNoneRadioButton.Text = "None";
            this.detectImagesNoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // detectImagesAutoRadioButton
            // 
            this.detectImagesAutoRadioButton.AutoSize = true;
            this.detectImagesAutoRadioButton.Location = new System.Drawing.Point(12, 65);
            this.detectImagesAutoRadioButton.Name = "detectImagesAutoRadioButton";
            this.detectImagesAutoRadioButton.Size = new System.Drawing.Size(47, 17);
            this.detectImagesAutoRadioButton.TabIndex = 3;
            this.detectImagesAutoRadioButton.Text = "Auto";
            this.detectImagesAutoRadioButton.UseVisualStyleBackColor = true;
            this.detectImagesAutoRadioButton.CheckedChanged += new System.EventHandler(this.detectImagesAutoRadioButton_CheckedChanged);
            // 
            // detectImagesAutoSettingsButton
            // 
            this.detectImagesAutoSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detectImagesAutoSettingsButton.Enabled = false;
            this.detectImagesAutoSettingsButton.Location = new System.Drawing.Point(123, 62);
            this.detectImagesAutoSettingsButton.Name = "detectImagesAutoSettingsButton";
            this.detectImagesAutoSettingsButton.Size = new System.Drawing.Size(111, 23);
            this.detectImagesAutoSettingsButton.TabIndex = 1;
            this.detectImagesAutoSettingsButton.Text = "Settings...";
            this.detectImagesAutoSettingsButton.UseVisualStyleBackColor = true;
            this.detectImagesAutoSettingsButton.Click += new System.EventHandler(this.detectImagesAutoSettingsButton_Click);
            // 
            // detectImagesDefaultRadioButton
            // 
            this.detectImagesDefaultRadioButton.AutoSize = true;
            this.detectImagesDefaultRadioButton.Checked = true;
            this.detectImagesDefaultRadioButton.Location = new System.Drawing.Point(12, 19);
            this.detectImagesDefaultRadioButton.Name = "detectImagesDefaultRadioButton";
            this.detectImagesDefaultRadioButton.Size = new System.Drawing.Size(191, 17);
            this.detectImagesDefaultRadioButton.TabIndex = 0;
            this.detectImagesDefaultRadioButton.TabStop = true;
            this.detectImagesDefaultRadioButton.Text = "Default (specified encoder settings)";
            this.detectImagesDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbumbnailLoadingProgressToolStripProgressBar,
            this.imagesEncodingProgressToolStripProgressBar,
            this.imageEncodingProgressToolStripProgressBar,
            this.processingToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(846, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbumbnailLoadingProgressToolStripProgressBar
            // 
            this.tbumbnailLoadingProgressToolStripProgressBar.Name = "tbumbnailLoadingProgressToolStripProgressBar";
            this.tbumbnailLoadingProgressToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.tbumbnailLoadingProgressToolStripProgressBar.Visible = false;
            // 
            // imagesEncodingProgressToolStripProgressBar
            // 
            this.imagesEncodingProgressToolStripProgressBar.Name = "imagesEncodingProgressToolStripProgressBar";
            this.imagesEncodingProgressToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.imagesEncodingProgressToolStripProgressBar.Visible = false;
            // 
            // imageEncodingProgressToolStripProgressBar
            // 
            this.imageEncodingProgressToolStripProgressBar.Name = "imageEncodingProgressToolStripProgressBar";
            this.imageEncodingProgressToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.imageEncodingProgressToolStripProgressBar.Visible = false;
            // 
            // processingToolStripProgressBar
            // 
            this.processingToolStripProgressBar.Name = "processingToolStripProgressBar";
            this.processingToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.processingToolStripProgressBar.Visible = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "PDF Files|*.pdf";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft PDF MRC Compression Demo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.mrcCompressionSettingsPanel.ResumeLayout(false);
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.binarizationGroupBox.ResumeLayout(false);
            this.binarizationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualBinarizationNumericUpDown)).EndInit();
            this.manualTextPanelGroupBox.ResumeLayout(false);
            this.manualTextPanelGroupBox.PerformLayout();
            this.detectImagesGroupBox.ResumeLayout(false);
            this.detectImagesGroupBox.PerformLayout();
            this.manualDetectGroupBox.ResumeLayout(false);
            this.manualDetectGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem saveToPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel mrcCompressionSettingsPanel;
        private System.Windows.Forms.GroupBox detectImagesGroupBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tbumbnailLoadingProgressToolStripProgressBar;
        private System.Windows.Forms.ToolStripProgressBar imagesEncodingProgressToolStripProgressBar;
        private System.Windows.Forms.ToolStripProgressBar imageEncodingProgressToolStripProgressBar;
        private System.Windows.Forms.ToolStripProgressBar processingToolStripProgressBar;
        private System.Windows.Forms.RadioButton detectImagesManualRadioButton;
        private System.Windows.Forms.RadioButton detectImagesDefaultRadioButton;
        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.Button removeImageRegionButton;
        private System.Windows.Forms.Button detectImagesAutoSettingsButton;
        private System.Windows.Forms.Button detectImagesButton;
        private DemosCommonCode.Imaging.ImageViewerToolStrip imageViewerToolStrip;
        private System.Windows.Forms.Button addTextRegionButton;
        private System.Windows.Forms.Button removeTextRegionButton;
        private System.Windows.Forms.RadioButton detectTextManualRadioButton;
        private System.Windows.Forms.RadioButton detectTextDefaultRadioButton;
        private System.Windows.Forms.Button addImageRegionButton;
        private System.Windows.Forms.ToolStripMenuItem acquireFromScannerToolStripMenuItem;
        private Vintasoft.Imaging.UI.ThumbnailViewer thumbnailViewer;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox binarizationGroupBox;
        private System.Windows.Forms.RadioButton binarizationAdaptiveRadioButton;
        private System.Windows.Forms.RadioButton binarizationManualRadioButton;
        private System.Windows.Forms.RadioButton binarizationAutoRadioButton;
        private System.Windows.Forms.Button adaptiveBinarizationSettingsButton;
        private System.Windows.Forms.NumericUpDown manualBinarizationNumericUpDown;
        private System.Windows.Forms.RadioButton detectImagesNoneRadioButton;
        private System.Windows.Forms.RadioButton detectImagesAutoRadioButton;
        private System.Windows.Forms.GroupBox manualDetectGroupBox;
        private System.Windows.Forms.GroupBox manualTextPanelGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeAllImageRegionsButton;
        private System.Windows.Forms.ComboBox imageRegionsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeAllTextRegionsButton;
        private System.Windows.Forms.ComboBox textRegionsComboBox;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mrcCompressionSettingsToolStripMenuItem;
    }
}
