﻿using System;
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
        int _posX = 0, _posY = 0;

        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);
        Pen _levelLinePen = new Pen(Brushes.DeepSkyBlue);
        Pen _dataLinePen = new Pen(Brushes.DarkBlue);

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
            //get { return _cellPos; }
            set
            {
                //if (FrameToShow == null || FrameToShow.Length == 0)
                //    return;

                //if ((value.X >= _offsetService.X - _cellPosShift
                //    && value.X < _offsetService.X - _cellPosShift + _cellSize.Width * _wordsServiceCount
                //    && value.Y >= _offsetService.Y - _cellPosShift
                //    && value.Y < _offsetService.Y - _cellPosShift + _cellSize.Height)
                //    ||
                //    (value.X >= _offsetData.X - _cellPosShift
                //    && value.X < _offsetData.X - _cellPosShift + _cellSize.Width * _frameRowNumber
                //    && value.Y >= _offsetData.Y - _cellPosShift
                //    && value.Y < _offsetData.Y - _cellPosShift + _cellSize.Height * (_frameToShow.Length / _frameRowNumber)))
                //{
                //    _cellPos.X = _offsetService.X - _cellPosShift + ((value.X - _offsetService.X) / _cellSize.Width) * _cellSize.Width;
                //    _cellPos.Y = _offsetService.Y - _cellPosShift + ((value.Y - _offsetService.Y) / _cellSize.Height) * _cellSize.Height;
                //    Invalidate();
                //}
                _posX = value.X;
                _posY = value.Y;

                Invalidate();
            }
        }
        public Keys KeyPos
        {
            set
            {
                //if (FrameToShow == null || FrameToShow.Length == 0)
                //    return;

                //if (value == Keys.Up && _cellPos.Y >= _offsetService.Y - _cellPosShift + _cellSize.Height)
                //    if (_cellPos.Y == _offsetData.Y - _cellPosShift)
                //        _cellPos.Y -= _cellSize.Height * 3;
                //    else
                //        _cellPos.Y -= _cellSize.Height;

                //if (value == Keys.Down && _cellPos.Y < _offsetData.Y - _cellPosShift + _cellSize.Height * (_frameToShow.Length / _frameRowNumber - 1))
                //    if (_cellPos.Y == _offsetService.Y - _cellPosShift)
                //        _cellPos.Y += _cellSize.Height * 3;
                //    else
                //        _cellPos.Y += _cellSize.Height;

                //if (value == Keys.Left && _cellPos.X >= _offsetData.X - _cellPosShift + _cellSize.Width)
                //    _cellPos.X -= _cellSize.Width;

                //if (value == Keys.Right && _cellPos.X < _offsetData.X - _cellPosShift + _cellSize.Width * (_frameRowNumber - 1))
                //    _cellPos.X += _cellSize.Width;

                //Invalidate();
            }
        }

        public GistoViewer()
        {
            InitializeComponent();
            Invalidate();
            this.DoubleBuffered = true;
            _levelLinePen.Width = 1.0F;
            _levelLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _dataLinePen.Width = 1;
        }

        private void GistoViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Путь файла: " + Path + " XF:" + _posX + " YF:" + _posY,
                _drawFont,
                _drawBrushService,
                0,
                0);

            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            for (int i = _wordsServiceCount, j = 0; i < _frameToShow.Length; i++, j += 2)
            {
                e.Graphics.DrawLine(
                    _dataLinePen,
                    new Point(j, 512),
                    new Point(j, 512 - ((_frameToShow.frameArray[i] & _param.Mask) >> _param.Offset) * 2)
                    );
            }
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 0), new Point(1710, 0));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 128), new Point(1710, 128));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 256), new Point(1710, 256));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 392), new Point(1710, 392));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 512), new Point(1710, 512));
        }
    }
}
