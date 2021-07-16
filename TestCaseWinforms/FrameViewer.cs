﻿using System;
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
        int _wordsServiceCount = 31;
        int _frameRowNumber = 32;
        const int _cellPosShift = 3;
        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);
        FrameViewInfo _param;
        string _radix;
        Size _cellSize = new Size(40, 20);
        Point _offsetServiceStart = new Point(10, 10);
        Point _offsetDataStart = new Point(10, 70);
        Point _offsetService = new Point(10, 30);
        Point _offsetData = new Point(10, 90);
        Pen _myPen = new Pen(Brushes.DeepSkyBlue);
        Point _cellPos = new Point(10 - _cellPosShift, 30 - _cellPosShift);

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
            get { return _cellPos; }
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                if ((value.X >= _offsetService.X - _cellPosShift
                    && value.X < _offsetService.X - _cellPosShift + _cellSize.Width * _wordsServiceCount
                    && value.Y >= _offsetService.Y - _cellPosShift
                    && value.Y < _offsetService.Y - _cellPosShift + _cellSize.Height)
                    ||
                    (value.X >= _offsetData.X - _cellPosShift
                    && value.X < _offsetData.X - _cellPosShift + _cellSize.Width * _frameRowNumber
                    && value.Y >= _offsetData.Y - _cellPosShift
                    && value.Y < _offsetData.Y - _cellPosShift + _cellSize.Height * (_frameToShow.Length / _frameRowNumber)))
                {
                    _cellPos.X = _offsetService.X - _cellPosShift + ((value.X - _offsetService.X) / _cellSize.Width) * _cellSize.Width;
                    _cellPos.Y = _offsetService.Y - _cellPosShift + ((value.Y - _offsetService.Y) / _cellSize.Height) * _cellSize.Height;
                    Invalidate();
                }
            }
        }
        public Keys KeyPos
        {
            set
            {
                if (FrameToShow == null || FrameToShow.Length == 0)
                    return;

                if (value == Keys.Up)
                    _cellPos.Y -= _cellSize.Height;
                if (value == Keys.Down)
                    _cellPos.Y += _cellSize.Height;
                if (value == Keys.Left)
                    _cellPos.Y -= _cellSize.Width;
                if (value == Keys.Right)
                    _cellPos.Y += _cellSize.Width;

                Invalidate();
            }
        }

        public FrameViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //чтобы быстрее отрисовывалось в Control'е

            //настройки линии прямоугольника
            _myPen.Width = 1.0F;
            _myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //рисуем служебную часть кадра
            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path + " XF:" + _cellPos.X + " YF:" + _cellPos.Y,
                _drawFont,
                _drawBrushService,
                _offsetServiceStart.X,
                _offsetServiceStart.Y);

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
                _offsetDataStart.X,
                _offsetDataStart.Y);

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
            e.Graphics.DrawRectangle(_myPen, new Rectangle(_cellPos, _cellSize));
        }

        private void FrameViewer_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyPos = e.KeyCode;
        }
    }
}
