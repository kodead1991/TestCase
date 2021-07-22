using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestCaseWinforms
{
    class FramePosViewInfo
    {
        static int colorNumber = -1;
        int _frameIndex;
        Brush _frameIndexBrush;

        public int FrameIndex
        {
            get { return _frameIndex; }
            set { _frameIndex = value; }
        }
        public Brush FrameIndexBrush
        {
            get { return _frameIndexBrush; }
            set { _frameIndexBrush = value; }
        }

        public FramePosViewInfo(int index)
        {
            _frameIndex = index;

            switch (++colorNumber % 11)
            {
                case 0:
                    _frameIndexBrush = new SolidBrush(Color.Red); break;
                case 1:
                    _frameIndexBrush = new SolidBrush(Color.Blue); break;
                case 2:
                    _frameIndexBrush = new SolidBrush(Color.Green); break;
                case 3:
                    _frameIndexBrush = new SolidBrush(Color.DarkOrange); break;
                case 4:
                    _frameIndexBrush = new SolidBrush(Color.DeepPink); break;
                case 5:
                    _frameIndexBrush = new SolidBrush(Color.DarkMagenta); break;
                case 6:
                    _frameIndexBrush = new SolidBrush(Color.DarkViolet); break;
                case 7:
                    _frameIndexBrush = new SolidBrush(Color.Olive); break;
                case 9:
                    _frameIndexBrush = new SolidBrush(Color.Gold); break;
                case 10:
                    _frameIndexBrush = new SolidBrush(Color.Gray); break;
                default:
                    break;
            }
        }
    }
}
