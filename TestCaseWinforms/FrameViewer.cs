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
        public string[] drawString;
        public float posX, posY;
        Kadr k;

        public FrameViewer()
        {
            InitializeComponent();
            drawString = new string[544];
            for (int i = 0; i < 544; i++)
            {
                drawString[i] = "0";
            }
        }
        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            
            for (int i = 0; i < 544 / 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    posX = 10 + j * 35;
                    posY = 10 + i * 20;
                    e.Graphics.DrawString(String.Format(drawString[j+i*32]), drawFont, drawBrush, posX, posY, drawFormat);
                }
            }
        }
    }
}
