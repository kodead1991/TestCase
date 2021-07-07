using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public partial class FrameViewer : UserControl
    {
        public FrameViewer()
        {
            InitializeComponent();
        }

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            // Create string to draw.
            String drawString = "Sample Text";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y = 50.0F;

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }
    }
}
