using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestCaseWinforms
{
    public class FramePosViewInfo
    {
        static int colorNumber = 0;

        private int _frameIndex;
        private Brush _brush;
        private DashStyle _dashStyle;

        Color[] colors = new Color[] 
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.DarkOrange,
            Color.DeepPink,
            Color.DarkMagenta,
            Color.DarkViolet,
            Color.Olive,
            Color.Gold,
            Color.Gray
        };

        public int FrameIndex
        {
            get { return _frameIndex; }
            set { _frameIndex = value; }
        }
        public Brush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        public DashStyle FrameDashStyle
        {
            get { return _dashStyle; }
            set { _dashStyle = value; }
        }

        public FramePosViewInfo(int index)
        {
            _frameIndex = index;
            _brush = new SolidBrush(colors[colorNumber++ % colors.Length]);
        }

        public FramePosViewInfo(KadrPosLine line)
        {
            _frameIndex = line.pos;
            _brush = new SolidBrush(line.color);
            _dashStyle = line.dashStyle;
        }
    }
}
