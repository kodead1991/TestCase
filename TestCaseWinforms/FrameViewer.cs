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
        Frame _frameToShow;
        string _path;
        FrameViewInfo _param;
        string _radix;

        public Frame FrameToShow
        {
            get { return _frameToShow; }
            set { _frameToShow = value; Invalidate(); }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public FrameViewInfo Param
        {
            get { return _param; }
            set { _param = value; Invalidate(); }
        }
        public string Radix
        {
            get { return _radix; }
            set { _radix = value; Invalidate(); }
        }
        int frameInfoSize = 31;

        public FrameViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //чтобы быстрее отрисовывалось в Control'е
        }

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //рисуем название и служебную часть кадра
            Font drawFont = new Font("Courier New", 10);
            SolidBrush drawBrush = new SolidBrush(Color.DarkMagenta);

            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path, drawFont, drawBrush, 10, 10);
            for (int j = 0; j < frameInfoSize; j++)
                e.Graphics.DrawString((FrameToShow.frameArray[j] & _param.Mask >> _param.Offset).ToString(_radix), drawFont, drawBrush, 10 + j * 40, 30);

            //рисуем название и информационную часть кадра
            drawBrush = new SolidBrush(Color.DarkBlue);
            e.Graphics.DrawString("Информационная часть кадра", drawFont, drawBrush, 10, 70);
            for (int i = 0; i < FrameToShow.Length - frameInfoSize; i++)
            {
                e.Graphics.DrawString((FrameToShow.frameArray[frameInfoSize + i] & _param.Mask >> _param.Offset).ToString(_radix), drawFont, drawBrush, 10 + i % 32 * 40, 90 + i / 32 * 20);
            }
        }
    }
}
