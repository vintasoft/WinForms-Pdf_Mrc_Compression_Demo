using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace PdfMrcCompressionDemo
{
    /// <summary>
    /// Represents the rectangular text selection region on image in image viewer.
    /// </summary>
    public class RectangularTextSelection : RectangularSelection
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularTextSelection"/> class.
        /// </summary>
        /// <param name="boundingBox">Bounding box of the region.</param>
        public RectangularTextSelection(Rectangle boundingBox)
            : this(Rectangle.Empty, boundingBox)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularTextSelection"/> class.
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="boundingBox">Bounding box of the region.</param>
        public RectangularTextSelection(Rectangle rect, Rectangle boundingBox)
            : base(rect)
        {
            // set background color
            Brush = new SolidBrush(Color.FromArgb(24, 0, 0, 192));
            // set frame color
            Pen = new Pen(Color.FromArgb(192, 0, 0, 128));

            SelectionBoundingBox = boundingBox;
        }


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return base.SelectedRect.ToString();
        }

    }
}
