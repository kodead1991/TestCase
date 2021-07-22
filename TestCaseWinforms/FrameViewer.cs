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

        static int _wordsServiceCount = 31;
        static int _frameRowNumber = 32;
        static int _cellPosShift = 3;
        static int _selectedIndex;

        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);

        FrameViewInfo _param;

        string _radix;

        static Size _cellSize = new Size(40, 20);

        static Point _offsetServiceLabel = new Point(10, 10);
        static Point _offsetDataLabel = new Point(10, 70);
        static Point _offsetService = new Point(10, 30);
        static Point _offsetData = new Point(10, 90);

        static Rectangle _rectService = new Rectangle(_offsetService, new Size(40 * 31, 20));
        static Rectangle _rectData = new Rectangle(_offsetData, new Size(40 * 32, 20 * 16));

        Pen _myPen = new Pen(Brushes.DeepSkyBlue);

        Point _cellRectPos = new Point(_offsetService.X - _cellPosShift, _offsetService.Y - _cellPosShift);

        int _row, _col;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectIndexToDraw;

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
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;
                _param = value;
                Invalidate();
            }
        }
        public string Radix
        {
            get { return _radix; }
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;
                _radix = value;
                Invalidate();
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                GetCellRectPos(_selectedIndex);

                this.Invalidate();

                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(this, EventArgs.Empty);
            }
        }
        public Point MousePos
        {
            get { return _cellRectPos; }
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                SelectedIndex = GetIndex(value);

                GetCellRectPos(SelectedIndex);
            }
        }
        public Keys KeyPos
        {
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                switch (value)
                {
                    case Keys.Left:
                        if (SelectedIndex > 0)
                            SelectedIndex--;
                        break;
                    case Keys.Right:
                        if (SelectedIndex < FrameToShow.Length - 1)
                            SelectedIndex++;
                        break;
                    case Keys.Up:
                        if (SelectedIndex >= _wordsServiceCount + 1)
                            SelectedIndex -= 32;
                        break;
                    case Keys.Down:
                        if (SelectedIndex < FrameToShow.Length - 1 - _wordsServiceCount)
                            SelectedIndex += 32;
                        break;
                    default:
                        break;
                }

                GetCellRectPos(SelectedIndex);
            }
        }

        public FrameViewer()
        {
            InitializeComponent();
            Invalidate();

            //настройки линии прямоугольника
            _myPen.Width = 1.0F;
            _myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            this.PreviewKeyDown += controls_PreviewKeyDown;
        }

        //обработка нажатий клавиатуры на Control'e
        private void controls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    this.KeyPos = e.KeyCode;
                    break;
                default:
                    break;
            }
        }

        private void FrameViewer_MouseClick(object sender, MouseEventArgs e)
        {
            this.MousePos = e.Location;
        }

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //рисуем служебную часть кадра
            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path + " XF:" + _cellRectPos.X + " YF:"
                + _cellRectPos.Y + " Row: " + _row + " Column: " + _col + " Позиция: " + (_selectedIndex + 1),
                _drawFont,
                _drawBrushService,
                _offsetServiceLabel.X,
                _offsetServiceLabel.Y);

            for (int i = 0; i < _wordsServiceCount; i++)
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
                _offsetDataLabel.X,
                _offsetDataLabel.Y);

            for (int i = 0; i < FrameToShow.Length - _wordsServiceCount; i++)
            {
                var row = Math.DivRem(i, _frameRowNumber, out var column);

                e.Graphics.DrawString((_param.GetWord(FrameToShow.frameArray[_wordsServiceCount + i]))
                    .ToString(_radix),
                    _drawFont,
                    _drawBrushData,
                    _offsetData.X + column * _cellSize.Width,
                    _offsetData.Y + row * _cellSize.Height);
            }

            //рисуем прямоугольник выделения
            e.Graphics.DrawRectangle(_myPen, new Rectangle(_cellRectPos, _cellSize));
        }

        int GetIndex(Point pos)
        {
            //курсор находится в области служ. слов
            if (_rectService.Contains(pos))
            {
                _row = (pos.X - _offsetService.X) / _cellSize.Width;
                _col = (pos.Y - _offsetService.Y) / _cellSize.Height;
            }

            //курсор находится в области информ. слов
            if (_rectData.Contains(pos))
            {
                _row = (pos.X - _offsetData.X) / _cellSize.Width + 31;
                _col = (pos.Y - _offsetData.Y) / _cellSize.Height;
            }

            return _row + _col * 32;
        }

        private void FramePosBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectIndexToDraw != null)
                SelectIndexToDraw(this, EventArgs.Empty);
        }

        void GetCellRectPos(int index)
        {
            if (_selectedIndex < _wordsServiceCount)
            {
                //нормировка
                _cellRectPos.X = _offsetService.X - _cellPosShift;
                _cellRectPos.Y = _offsetService.Y - _cellPosShift;

                //вычисление позиции для рамки выделения
                _cellRectPos.X += _selectedIndex % _frameRowNumber * _cellSize.Width;
            }
            else
            {
                //нормировка
                _cellRectPos.X = _offsetData.X - _cellPosShift;
                _cellRectPos.Y = _offsetData.Y - _cellPosShift;

                //вычисление позиции для рамки выделения
                _cellRectPos.X += (_selectedIndex - _wordsServiceCount) % _frameRowNumber * _cellSize.Width;
                _cellRectPos.Y += (_selectedIndex - _wordsServiceCount) / _frameRowNumber * _cellSize.Height;
            }
        }
    }
}
