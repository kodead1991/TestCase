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
        public Kadr k { get; set; }

        public FrameViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //чтобы быстрее отрисовывалось в Control'е
        }

        //отображение кадра в Control'е в формате HEX
        public void displayKadrHEX(int kadrNum)
        {
            if (k == null || k.kadr.Length == 0)
                return;

            drawString = new string[k.wordCount];

            for (int i = 0; i < 31; i++)
            {
                drawString[i] = (Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x3FF).ToString("X4"); //дополняем нулями до 4-х знаков в HEX'e (0000 to FFFF)
            }
            for (int i = 31; i < k.wordCount; i++)
            {
                if (k.kadrType == "(0111111110) БИТС-М")
                    drawString[i] = ((Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x1FE) >> 1).ToString("X2"); //дополняем нулями до 2-х знаков в HEX'e (00 to FF)
                else if (k.kadrType == "(0111001110) VITS-M")
                    drawString[i] = ((Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x1CE) >> 1).ToString("X2"); //дополняем нулями до 2-х знаков в HEX'e (00 to FF)
            }
            this.Invalidate();
        }

        //отображение кадра в Control'е в формате DEC
        public void displayKadrDEC(int kadrNum)
        {
            if (k == null || k.kadr.Length == 0)
                return;

            drawString = new string[k.wordCount];

            for (int i = 0; i < 31; i++)
            {
                drawString[i] = (Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x3FF).ToString("X4"); //дополняем нулями до 4-х знаков в HEX'e (0000 to FFFF)
            }
            for (int i = 31; i < k.wordCount; i++)
            {
                if (k.kadrType == "(0111111110) БИТС-М")
                    drawString[i] = ((Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x1FE) >> 1).ToString("D3"); //дополняем нулями до 2-х знаков в HEX'e (00 to FF)
                else if (k.kadrType == "(0111001110) VITS-M")
                    drawString[i] = ((Convert.ToInt32(k.kadr[kadrNum, i], 16) & 0x1CE) >> 1).ToString("D3"); //дополняем нулями до 2-х знаков в HEX'e (00 to FF)
            }
            this.Invalidate();
        }
        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (drawString == null || drawString.Length == 0)
                return;

            //рисуем название и служебную часть кадра
            Font drawFont = new Font("Courier New", 10);
            SolidBrush drawBrush = new SolidBrush(Color.DarkMagenta);

            e.Graphics.DrawString("Служебная часть кадра", drawFont, drawBrush, 10, 10);
            for (int j = 0; j < 31; j++)
                e.Graphics.DrawString(drawString[j].ToString(), drawFont, drawBrush, 10 + j * 40, 30);

            //рисуем название и информационную часть кадра
            drawBrush = new SolidBrush(Color.DarkBlue);
            e.Graphics.DrawString("Информационная часть кадра", drawFont, drawBrush, 10, 70);
            for (int i = 0; i < k.wordCount - 31; i++)
            {
                e.Graphics.DrawString(drawString[31 + i].ToString(), drawFont, drawBrush, 10 + i % 32 * 40, 90 + i / 32 * 20);
            }

        }
    }
}
