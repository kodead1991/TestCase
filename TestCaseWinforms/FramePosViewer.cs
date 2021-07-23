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
    public partial class FramePosViewer : UserControl
    {
        public event EventHandler<ChartLinesEventArgs> LinesInfoNeeded;

        FramePosViewInfo _framePosInfo;

        List<Frame> _frames;

        Brush myBrush;
        Pen myPen;


        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushLevels = new SolidBrush(Color.DarkMagenta);

        FrameViewInfo _param;

        Point _drawOffset = new Point(32, 50);

        Pen _levelLinePen = new Pen(Brushes.DeepSkyBlue);
        Pen _borderLinePen = new Pen(Brushes.Coral);
        Pen _crossLinePen = new Pen(Brushes.Black);


        string _radix;

        int _scaleX;
        int _scaleY;

        Point _mousePos;

        int _startFramePos = 0;

        int _listBoxSelectedIndex;

        Rectangle _borderRectangle = new Rectangle(31, 49, 1205, 515);

        public List<Frame> Frames
        {
            set { _frames = value; this.Invalidate(); }
            get { return _frames; }
        }
        public FrameViewInfo Param
        {
            get { return _param; }
            set
            {
                if (Frames == null || Frames.Count == 0)
                    return;

                _param = value; Invalidate();
            }
        }
        public string Radix
        {
            get { return _radix; }
            set
            {
                if (Frames == null || Frames.Count == 0)
                    return;

                _radix = value; Invalidate();
            }
        }
        public int StartFramePos
        {
            get { return _startFramePos; }
            set { _startFramePos = value; this.Invalidate(); }
        }

        public Point MousePos
        {
            get { return _mousePos; }
            set { _mousePos = value; this.Invalidate(); }
        }

        public int ListBoxSelectedIndex
        {
            get { return _listBoxSelectedIndex; }
            set { _listBoxSelectedIndex = value; this.Invalidate(); }
        }

        public int ViewScale
        {
            set { _scaleX = _scaleY = value; this.Invalidate(); }
        }

        public FramePosViewer()
        {
            InitializeComponent();

            myBrush = Brushes.Black;
            myPen = new Pen(myBrush);
            myPen.Width = 1.0F;

            _crossLinePen.Width = 1.0F;
            _crossLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            _scaleX = _scaleY = 1;
        }

        private void FramePosViewer_Paint(object sender, PaintEventArgs e)
        {
            //отрисовка цифр на оси Y
            for (int i = 0, j = 0; i <= 256; i += 64, j += 64 * _scaleY)
                e.Graphics.DrawString((i).ToString(_radix), _drawFont, _drawBrushLevels, 0, _drawOffset.Y - 10 + 512 - j);

            //отрисовка линий уровней данных
            for (int i = 512; i >= 256 / _scaleY; i -= 64 * _scaleY)
                e.Graphics.DrawLine(_levelLinePen, new Point(0 + _drawOffset.X, i + _drawOffset.Y), new Point(1200 + _drawOffset.X, i + _drawOffset.Y));

            //отрисовка рамки зоны отображения
            e.Graphics.DrawRectangle(_borderLinePen, _borderRectangle);

            if (Frames == null || Frames.Count == 0)
                return;

            if (LinesInfoNeeded == null)
                return;

            //позиция кадра относительно положения мышки
            var framePos = (MousePos.X - _drawOffset.X + 1) / _scaleX + _startFramePos;

            if (this._borderRectangle.Contains(MousePos))
            {
                //отрисовка перекрётсных линий для отоображения номера кадра и значения позиции
                e.Graphics.DrawLine( //линия по Х
                    _crossLinePen,
                    MousePos.X,
                    _drawOffset.Y,
                    MousePos.X,
                    _drawOffset.Y + 515
                    );
                e.Graphics.DrawLine( //линия по Y
                    _crossLinePen,
                    _drawOffset.X,
                    MousePos.Y,
                    _drawOffset.X + 1205,
                    MousePos.Y
                    );

                if (_listBoxSelectedIndex != -1 && framePos < Frames.Count)
                {

                    //отрисовка информации о позиции рядом с курсором
                    e.Graphics.DrawString(
                        "№ кадра: " + framePos.ToString(),
                        _drawFont,
                        _drawBrushLevels,
                        MousePos.X + 10,
                        MousePos.Y - 40);

                    //отрисовка информации о значении рядом с курсором

                    e.Graphics.DrawString(
                        "Значение: " + ((Frames[framePos].frameArray[ListBoxSelectedIndex] & _param.Mask) >> _param.Offset).ToString(_radix),
                        _drawFont,
                        _drawBrushLevels,
                        MousePos.X + 10,
                        MousePos.Y - 20);
                }
            }
            //создаём событие для передачи через аргументы списка из listBox'a
            var ea = new ChartLinesEventArgs();
            LinesInfoNeeded.Invoke(this, ea);

            //отрисовка сегментов графика позиций кадра
            for (int f = 0; f < ea.Info.Length; f++)
            {
                _framePosInfo = ea.Info[f];
                for (int i = 0, j = _startFramePos; i < _frames.Count - 1 - j; i++)
                {
                    //значения позиции кадра в приближении (i, i+1)
                    var posY1 = ((Frames[i + j].frameArray[_framePosInfo.FrameIndex] & _param.Mask) >> _param.Offset) * _scaleY;
                    var posY2 = ((Frames[i + j + 1].frameArray[_framePosInfo.FrameIndex] & _param.Mask) >> _param.Offset) * _scaleY;

                    //значения точек линии между позициями кадра в приближении (i, i+1)
                    var linePoint1 = new Point(i * _scaleX + _drawOffset.X, 512 - posY1 + _drawOffset.Y);
                    var linePoint2 = new Point((i + 1) * _scaleX + _drawOffset.X, 512 - posY2 + _drawOffset.Y);

                    //отрисовка сегмента графика
                    e.Graphics.DrawLine(
                        new Pen(_framePosInfo.FrameIndexBrush),
                        linePoint1,
                        linePoint2
                        );
                };
            }
        }

        private void FramePosViewer_MouseMove(object sender, MouseEventArgs e)
        {
            this.MousePos = e.Location;
        }

        private void scale_CheckedChanged(object sender, EventArgs e)
        {
            if (this.scaleX1.Checked)
                ViewScale = 1;
            if (this.scaleX2.Checked)
                ViewScale = 2;
        }
    }

    public class ChartLinesEventArgs : EventArgs
    {
        public FramePosViewInfo[] Info { get; set; }

        public ChartLinesEventArgs() => Info = default;
    }
}
