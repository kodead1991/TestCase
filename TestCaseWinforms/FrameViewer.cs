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
        Pen _checkedCellPen = new Pen(Brushes.DarkRed);

        Point _cellRectPos;
        Point _cellRectPosChecked;
        int _row, _col;

        public bool[] cellChecked;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler AddСheckedPos;
        public event EventHandler RemoveСheckedPos;

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

                _cellRectPos = new Point(_offsetService.X - _cellPosShift, _offsetService.Y - _cellPosShift);
                _cellRectPosChecked = new Point(_offsetService.X - _cellPosShift, _offsetService.Y - _cellPosShift);

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
                _cellRectPos = GetCellRectPos(_selectedIndex);

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

                _cellRectPos = GetCellRectPos(SelectedIndex);
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

                _cellRectPos = GetCellRectPos(SelectedIndex);
            }
        }

        public FrameViewer()
        {
            InitializeComponent();
            Invalidate();

            //настройки линии прямоугольника
            _myPen.Width = 1.0F;
            _myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            _checkedCellPen.Width = 1.0F;
            _checkedCellPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

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

            //рисуем прямоугольники выделенных позиций для графика
            for (int i = 0; i < FrameToShow.Length; i++)
                if (cellChecked[i])
                    e.Graphics.DrawRectangle(_checkedCellPen, new Rectangle(GetCellRectPos(i), _cellSize));

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

        //меняем флаг выделения позиции на противоположный
        private void FramePosBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            cellChecked[SelectedIndex] = !cellChecked[SelectedIndex];

            //создаём событие на удаление выделения позиции кадра (для listBox'a)
            if (cellChecked[SelectedIndex] == false)
                if (RemoveСheckedPos != null)
                    RemoveСheckedPos(this, EventArgs.Empty);

            //создаём событие на отрисовку
            if (cellChecked[SelectedIndex] == true)
                if (AddСheckedPos != null)
                    AddСheckedPos(this, EventArgs.Empty);
        }

        Point GetCellRectPos(int index)
        {
            Point pos = new Point(0, 0);

            if (index < _wordsServiceCount)
            {
                //нормировка
                pos.X = _offsetService.X - _cellPosShift;
                pos.Y = _offsetService.Y - _cellPosShift;

                //вычисление позиции для рамки выделения
                pos.X += index % _frameRowNumber * _cellSize.Width;
            }
            else
            {
                //нормировка
                pos.X = _offsetData.X - _cellPosShift;
                pos.Y = _offsetData.Y - _cellPosShift;

                //вычисление позиции для рамки выделения
                pos.X += (index - _wordsServiceCount) % _frameRowNumber * _cellSize.Width;
                pos.Y += (index - _wordsServiceCount) / _frameRowNumber * _cellSize.Height;
            }

            return pos;
        }
    }
}
