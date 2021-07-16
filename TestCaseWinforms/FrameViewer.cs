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
        int wordsServiceCount = 31;
        int frameRowNumber = 32;
        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);
        FrameViewInfo _param;
        string _radix;
        Size _cellSize = new Size(40, 20);
        Point _offsetServiceStart = new Point(10, 10);
        Point _offsetDataStart = new Point(10, 70);
        Point _offsetService = new Point(10, 30);
        Point _offsetData = new Point(10, 90);
        Pen _myPen = new Pen(Brushes.DeepSkyBlue);
        Point _mousePos;
        int posX, posY;
        //Rectangle _rectangle = new Rectangle(_offsetService.X - 1, _offsetService.Y + 15, _cellWidth, _cellHeight);

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
        public Point MousePos
        {
            get { return _mousePos; }
            set
            {
                //posX = value.X; posY = value.Y;
                if (value.X >= _offsetService.X
                    && value.X < _offsetService.X + _cellSize.Width * wordsServiceCount
                    && value.Y >= _offsetService.Y
                    && value.Y < _offsetService.Y + _cellSize.Height)
                {
                    int posX = _offsetService.X - 3 + ((value.X - _offsetService.X) / _cellSize.Width) * _cellSize.Width;
                    int posY = _offsetService.Y - 3 + ((value.Y - _offsetService.Y) / _cellSize.Height) * _cellSize.Height;
                    _mousePos = new Point(posX, posY);
                    Invalidate();
                }
                else if (value.X >= _offsetData.X
                    && value.X < _offsetData.X + _cellSize.Width * frameRowNumber
                    && value.Y >= _offsetData.Y
                    && value.Y < _offsetData.Y + _cellSize.Height * (_frameToShow.Length / frameRowNumber))
                {
                    int posX = _offsetService.X - 3 + ((value.X - _offsetService.X) / _cellSize.Width) * _cellSize.Width;
                    int posY = _offsetService.Y - 3 + ((value.Y - _offsetService.Y) / _cellSize.Height) * _cellSize.Height;
                    _mousePos = new Point(posX, posY);
                    Invalidate();
                }

            }
        }

        public FrameViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //чтобы быстрее отрисовывалось в Control'е

            //настройки линии прямоугольника
            _myPen.Width = 1.0F;
            _myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //рисуем служебную часть кадра
            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path + " XF:" + _mousePos.X + " YF:" + _mousePos.Y,
                _drawFont,
                _drawBrushService,
                _offsetServiceStart.X,
                _offsetServiceStart.Y);

            for (int i = 0; i < wordsServiceCount; i++)
            {
                e.Graphics.DrawString(FrameToShow.frameArray[i]
                    .ToString("X3"),
                    _drawFont,
                    _drawBrushService,
                    _offsetService.X + i * _cellSize.Width,
                    _offsetService.Y);
            }

            //рисуем информационную часть кадра
            e.Graphics.DrawString("Информационная часть кадра",
                _drawFont,
                _drawBrushData,
                _offsetDataStart.X,
                _offsetDataStart.Y);

            for (int i = 0; i < FrameToShow.Length - wordsServiceCount; i++)
            {
                var row = Math.DivRem(i, frameRowNumber, out var column);

                e.Graphics.DrawString((_param.GetWord(FrameToShow.frameArray[wordsServiceCount + i]))
                    .ToString(_radix),
                    _drawFont,
                    _drawBrushData,
                    _offsetData.X + column * _cellSize.Width,
                    _offsetData.Y + row * _cellSize.Height);
            }

            //рисуем прямоугольник выделения
            e.Graphics.DrawRectangle(_myPen, new Rectangle(_mousePos, _cellSize));
        }
    }
}
