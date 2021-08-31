﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestCaseWinforms
{
    public class FramePosViewInfo
    {
        static int colorNumber = 0;
        int _frameIndex;
        Brush _frameIndexBrush;
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
        public Brush FrameIndexBrush
        {
            get { return _frameIndexBrush; }
            set { _frameIndexBrush = value; }
        }

        public FramePosViewInfo(int index)
        {
            _frameIndex = index;
            _frameIndexBrush = new SolidBrush(colors[colorNumber++ % colors.Length]);
        }

        public FramePosViewInfo(int index, Color color)
        {
            _frameIndex = index;
            _frameIndexBrush = new SolidBrush(color);
        }
    }
}
