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
        List<Frame> _frames;

        Brush myBrush;
        Pen myPen;

        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushLevels = new SolidBrush(Color.DarkMagenta);

        FrameViewInfo _param;

        Point _drawOffset = new Point(32, 50);

        Pen _levelLinePen = new Pen(Brushes.DeepSkyBlue);
        Pen _borderLinePen = new Pen(Brushes.Coral);

        string _radix;

        int _scaleX = 2;
        int _scaleY = 2;

        int _startFramePos = 0;

        Rectangle _borderRectangle = new Rectangle(30, 49, 1205, 515);

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

        public FramePosViewer()
        {
            InitializeComponent();

            myBrush = Brushes.Black;
            myPen = new Pen(myBrush);
            myPen.Width = 1.0F;
        }

        private void FramePosViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_borderLinePen, _borderRectangle);

            if (Frames == null || Frames.Count == 0)
                return;

            //отрисовка цифр на оси Y
            for (int i = 256, j = 0; i >= 0; i -= 64, j += 64 * _scaleY)
                e.Graphics.DrawString((i).ToString(_radix), _drawFont, _drawBrushLevels, 0, j + _drawOffset.Y - 10);

            //отрисовка линий уровней данных
            for (int i = 64 * _scaleY; i < 512 - 64; i += 64 * _scaleY)
                e.Graphics.DrawLine(_levelLinePen, new Point(0 + _drawOffset.X, i + _drawOffset.Y), new Point(1200 + _drawOffset.X, i + _drawOffset.Y));

            for (int i = _startFramePos; i < _frames.Count - 1; i++)
            {
                var pos1 = ((Frames[i].frameArray[0] & _param.Mask) >> _param.Offset) * _scaleY;
                var pos2 = ((Frames[i + 1].frameArray[0] & _param.Mask) >> _param.Offset) * _scaleY;
                e.Graphics.DrawLine(myPen, i + _drawOffset.X, 512 - pos1 + _drawOffset.Y, i * 2 + _drawOffset.X, 512 - pos2 + _drawOffset.Y);
            };
        }
    }
}
