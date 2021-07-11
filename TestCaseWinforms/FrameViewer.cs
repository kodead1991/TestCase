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
        Font drawFont = new Font("Courier New", 10);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        StringFormat drawFormat = new StringFormat();

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
            for (int i = 0; i < 31; i++)
            {
                drawString[i] = (Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x3FF).ToString("X4");
            }
            for (int i = 31; i < 543; i++)
            {
                drawString[i] = ((Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x1FE) >> 1).ToString("X2");
            }

            Font drawFont = new Font("Courier New", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            this.Invalidate();
            return;
        }
        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (drawString == null || drawString.Length == 0)
                return;

            
            
            for (int i = 0; i < this.k.wordCount / 32 + 1; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    posX = 10 + j * 40;
                    posY = 10 + i * 20;
                    if (j + i * 32 < this.k.wordCount)
                        e.Graphics.DrawString(drawString[j+i*32].ToString(), drawFont, drawBrush, posX, posY);

                }
            }
        }
    }
}
