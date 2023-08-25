using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;


namespace PdfMrcCompressionDemo
{
    /// <summary>
    /// Information about PDF MRC compression settings for a single image.
    /// </summary>
    class MrcCompressionSettingsInfo
    {

        Rectangle[] _imageRegions = null;
        /// <summary>
        /// Gets or sets the image (picture and graphics) regions on a source image.
        /// </summary>
        public Rectangle[] ImageRegions
        {
            get
            {
                return _imageRegions;
            }
            set
            {
                _imageRegions = value;
            }
        }

        Rectangle[] _textRegions = null;
        /// <summary>
        /// Gets or sets the text and line-art regions on a source image.
        /// </summary>
        public Rectangle[] TextRegions
        {
            get
            {
                return _textRegions;
            }
            set
            {
                _textRegions = value;
            }
        }

        ImageSegmentationCommand _segmentation = null;
        /// <summary>
        /// Gets or sets the image processings command which is used for image segmentation.
        /// </summary>
        public ImageSegmentationCommand Segmentation
        {
            get
            {
                return _segmentation;
            }
            set
            {
                _segmentation = value;
            }
        }

        ChangePixelFormatToBlackWhiteCommand _binarization = null;
        /// <summary>
        /// Gets or sets the image processings command which is used for image binarization.
        /// </summary>
        public ChangePixelFormatToBlackWhiteCommand Binarization
        {
            get
            {
                return _binarization;
            }
            set
            {
                _binarization = value;
            }
        }

        bool _useDefaultSettingsForDetectingImageRegions = true;
        /// <summary>
        /// Gets or sets a value indicating whether the default encoder settings must be used
        /// for detecting image regions on a source image.
        /// </summary>
        public bool UseDefaultSettingsForDetectingImageRegions
        {
            get
            {
                return _useDefaultSettingsForDetectingImageRegions;
            }
            set
            {
                _useDefaultSettingsForDetectingImageRegions = value;
            }
        }

    }
}
