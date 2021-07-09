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
            this.DoubleBuffered = true;
        }
        public void kadrInit(Kadr kadr)
        {
            this.k = kadr;
        }
        public void drawKadr(int kadrNum)
        {
            if (k == null || k.kadr.Length == 0)
                return;
            drawString = new string[543];
            for (int i = 0; i < 543; i++)
            {
                drawString[i] = k.kadr[kadrNum,i];
            }
            this.Invalidate();
            return;
        }
        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (drawString == null || drawString.Length == 0)
                return;

            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            
            for (int i = 0; i < this.k.wordCount / 32 + 1; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    posX = 10 + j * 40;
                    posY = 10 + i * 20;
                    if (j + i * 32 < this.k.wordCount)
                        e.Graphics.DrawString(String.Format(drawString[j+i*32]), drawFont, drawBrush, posX, posY, drawFormat);
                }
            }
        }
    }
}
