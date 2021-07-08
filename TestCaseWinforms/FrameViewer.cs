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
        public string drawString = "0x0000";
        Kadr k;
        public string DrawString
        {
            set { drawString = "0x00"+value; this.Invalidate(); }
        }

        public FrameViewer()
        {
            InitializeComponent();
        }
        public void frameInit(Kadr k)
        {
            this.k = k;
        }
        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            // Create font and brush.
            Font drawFont = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = 70.0F;
            float y = 20.0F;

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            for (int i = 0; i < 32; i++)
                for (int j = 0; j < k.wordCount / 32 + 1; j++)
                {
                    e.Graphics.DrawString(k.kadr[i,j], drawFont, drawBrush, 10+x*j, 20+y*i, drawFormat);
                }
            
        }
    }
}
