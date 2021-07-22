using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public partial class GistoViewer : UserControl
    {
        Frame _frameToShow;

        string _path;

        FrameViewInfo _param;

        string _radix;

        static int _wordsServiceCount = 31;
        static int _selectedIndex;

        Point _drawOffset = new Point(32, 50);

        Rectangle _borderRectangle = new Rectangle(30, 49, 1026, 515);

        int _redLinePosX = 0;
        int _redLineValue = 0;

        string gistoText = "";

        int _scaleX = 2;
        int _scaleY = 2;

        Font _drawFont = new Font("Courier New", 10);

        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);

        Pen _levelLinePen = new Pen(Brushes.DeepSkyBlue);
        Pen _dataLinePen = new Pen(Brushes.DarkBlue);
        Pen _borderLinePen = new Pen(Brushes.Coral);
        Pen _redLinePen = new Pen(Brushes.Red);

        public event EventHandler SelectedIndexChanged;

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
        public Point MousePos
        {
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                if (value.X >= _drawOffset.X && value.X <= _drawOffset.X + (_frameToShow.Length - 1 - _wordsServiceCount) * _scaleX)
                {
                    SelectedIndex = _wordsServiceCount + (value.X - _drawOffset.X) / 2;
                }
            }
        }
        public Keys KeyPos
        {
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                if (value == Keys.Left && SelectedIndex > _wordsServiceCount)
                    SelectedIndex--;

                if (value == Keys.Right && SelectedIndex < FrameToShow.Length - 1)
                    SelectedIndex++;

                if (value == Keys.Up && SelectedIndex < FrameToShow.Length - 1 - 32)
                    SelectedIndex += 32;

                if (value == Keys.Down && SelectedIndex > _wordsServiceCount + 32)
                    SelectedIndex -= 32;
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;

                this.Invalidate();

                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        public GistoViewer()
        {
            InitializeComponent();
            Invalidate();

            _levelLinePen.Width = 1.0F;
            _levelLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            _borderLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            _dataLinePen.Width = 1;

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

        private void GistoViewer_MouseClick(object sender, MouseEventArgs e)
        {
            this.MousePos = e.Location;
        }

        private void GistoViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_borderLinePen, _borderRectangle);

            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //отрисовка информационных слов кадра
            for (int i = _wordsServiceCount, j = 0; i < _frameToShow.Length; i++, j += 1 * _scaleX)
            {
                e.Graphics.DrawLine(
                    _dataLinePen,
                    new Point(j + _drawOffset.X, 512 + _drawOffset.Y),
                    new Point(j + _drawOffset.X, 512 + _drawOffset.Y - ((_frameToShow.frameArray[i] & _param.Mask) >> _param.Offset) * _scaleY)
                    );
            }

            //отрисовка цифр на оси Y
            for (int i = 256, j = 0; i >= 0; i -= 64, j += 64 * _scaleY)
                e.Graphics.DrawString((i).ToString(_radix), _drawFont, _drawBrushService, 0, j + _drawOffset.Y - 10);

            //отрисовка линий уровней данных
            for (int i = 64 * _scaleY; i < 512 - 64; i += 64 * _scaleY)
                e.Graphics.DrawLine(_levelLinePen, new Point(0 + _drawOffset.X, i + _drawOffset.Y), new Point(1025 + _drawOffset.X, i + _drawOffset.Y));

            //рисуем красную линию
            _redLinePosX = _drawOffset.X + (SelectedIndex - _wordsServiceCount) * _scaleX;
            _redLineValue = ((_frameToShow.frameArray[SelectedIndex] & _param.Mask) >> _param.Offset) * _scaleY;
            if (SelectedIndex >= _wordsServiceCount)
                e.Graphics.DrawLine(
                        _redLinePen,
                        new Point(_redLinePosX, 512 + _drawOffset.Y),
                        new Point(_redLinePosX, 512 + _drawOffset.Y - _redLineValue)
                        );

            //рисуем путь файла, координаты мышки и значение выделенной позиции
            gistoText = "Путь файла: " + Path + " Позиция: " + (_selectedIndex + 1) + " Значение слова: " + _redLineValue.ToString(_radix);
            e.Graphics.DrawString(gistoText, _drawFont, _drawBrushService, 0, 0);
        }
    }
}
