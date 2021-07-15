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
        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);
        FrameViewInfo _param;
        string _radix;
        Size _size = new Size(40, 20);
        Point _offsetServiceStart = new Point(10, 10);
        Point _offsetDataStart = new Point(10, 70);
        Point _offsetService = new Point(10, 30);
        Point _offsetData = new Point(10, 90);

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

            //рисуем служебную часть кадра
            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path,
                _drawFont,
                _drawBrushService,
                _offsetServiceStart.X,
                _offsetServiceStart.Y);

            for (int i = 0; i < frameInfoSize; i++)
            {
                e.Graphics.DrawString(FrameToShow.frameArray[i]
                    .ToString("X3"),
                    _drawFont,
                    _drawBrushService,
                    _offsetService.X + i * _size.Width,
                    _offsetService.Y + _size.Height);
            }

            //рисуем информационную часть кадра
            e.Graphics.DrawString("Информационная часть кадра",
                _drawFont,
                _drawBrushData,
                _offsetDataStart.X,
                _offsetDataStart.Y);

            for (int i = 0; i < FrameToShow.Length - frameInfoSize; i++)
            {
                var row = Math.DivRem(i, 32, out var column);

                e.Graphics.DrawString((_param.GetWord(FrameToShow.frameArray[frameInfoSize + i]))
                    .ToString(_radix),
                    _drawFont,
                    _drawBrushService,
                    _offsetData.X + column * _size.Width,
                    _offsetData.Y + row * _size.Height);
            }
        }
    }
}
