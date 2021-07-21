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

        int _posX = 0, _posY = 0, _gistOffsetX = 32, _gistOffsetY = 50;

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

                if (value.X >= _gistOffsetX && value.X <= _gistOffsetX + (_frameToShow.Length - 1 - _wordsServiceCount) * _scaleX)
                {
                    _redLinePosX = (value.X % 2 == 1) ? value.X - 1 - _gistOffsetX : value.X - _gistOffsetX;
                    //добавить изменение индекса, а отрисовку перенести в Paint
                }

                Invalidate();
            }
        }

        private void GistoViewer_MouseClick(object sender, MouseEventArgs e)
        {
            this.MousePos = e.Location;
        }

        public Keys KeyPos
        {
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                if (value == Keys.Left && _redLinePosX > 0)
                    _redLinePosX -= 1 * _scaleX;

                if (value == Keys.Right && _redLinePosX < (_frameToShow.Length - 1 - _wordsServiceCount) * _scaleX)
                    _redLinePosX += 1 * _scaleX;

                Invalidate();
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;

                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(this, EventArgs.Empty);

                this.Invalidate();
            }
        }

        public GistoViewer()
        {
            InitializeComponent();
            Invalidate();
            this.DoubleBuffered = true;
            _levelLinePen.Width = 1.0F;
            _levelLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _borderLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _dataLinePen.Width = 1;

            this.PreviewKeyDown += controls_PreviewKeyDown;
        }

        private void GistoViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void controls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    this.KeyPos = e.KeyCode;
                    break;
                default:
                    break;
            }
        }

        private void GistoViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_borderLinePen, _borderRectangle);

            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            for (int i = _wordsServiceCount, j = 0; i < _frameToShow.Length; i++, j += 1 * _scaleX)
            {
                e.Graphics.DrawLine(
                    _dataLinePen,
                    new Point(j + _gistOffsetX, 512 + _gistOffsetY),
                    new Point(j + _gistOffsetX, 512 + _gistOffsetY - ((_frameToShow.frameArray[i] & _param.Mask) >> _param.Offset) * _scaleY)
                    );
            }

            for (int i = 256, j = 0; i >= 0; i -= 64, j += 64*_scaleY)
                e.Graphics.DrawString((i).ToString(_radix), _drawFont, _drawBrushService, 0, j + _gistOffsetY - 10);

            for (int i = 64 * _scaleY; i < 512 - 64; i+= 64 * _scaleY)
                e.Graphics.DrawLine(_levelLinePen, new Point(0 + _gistOffsetX, i + _gistOffsetY), new Point(1025 + _gistOffsetX, i + _gistOffsetY));

            //рисуем красную линию
            _redLineValue = (_frameToShow.frameArray[_redLinePosX / _scaleX + _wordsServiceCount] & _param.Mask) >> _param.Offset;
            e.Graphics.DrawLine(
                    _redLinePen,
                    new Point(_redLinePosX + _gistOffsetX, 512 + _gistOffsetY),
                    new Point(_redLinePosX + _gistOffsetX, 512 + _gistOffsetY - (_redLineValue * _scaleY))
                    );

            //рисуем путь файла, координаты мышки и значение выделенной позиции
            gistoText = "Путь файла: " + Path + " Значение слова:" + _redLineValue.ToString(_radix);
            e.Graphics.DrawString(gistoText, _drawFont, _drawBrushService, 0, 0);
        }
    }
}
