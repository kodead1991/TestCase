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
        int frameInfoSize = 31;

        public FrameViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //чтобы быстрее отрисовывалось в Control'е
        }

        //отображение кадра в Control'е в формате HEX
        //public void DisplayFrame(int frameNum, string numeralSystem)
        //{
        //    if (frameToShow == null || frameToShow.frameArray.Length == 0)
        //        return;

        //    drawString = new string[frameToShow.wordCount];

        //    for (int i = 0; i < frameInfoSize; i++)
        //    {
        //        drawString[i] = (frameToShow.frameArray[frameNum, i] & 0x3FF).ToString("X4"); //дополняем нулями до 4-х знаков в HEX'e (0000 to FFFF)
        //    }
        //    for (int i = frameInfoSize; i < frameToShow.wordCount; i++)
        //    {
        //        if (frameToShow.frameType == FrameType.BITSM)
        //        {
        //            if (numeralSystem == "DEC")
        //                drawString[i] = ((frameToShow.frameArray[frameNum, i] & (int)FrameType.BITSM) >> 1).ToString("D3");
        //            else if (numeralSystem == "HEX")
        //                drawString[i] = ((frameToShow.frameArray[frameNum, i] & (int)FrameType.BITSM) >> 1).ToString("X2");
        //        }
        //        else if (frameToShow.frameType == FrameType.VITSM)
        //        {
        //            if (numeralSystem == "DEC")
        //                drawString[i] = ((frameToShow.frameArray[frameNum, i] & (int)FrameType.VITSM) >> 1).ToString("D3");
        //            else if (numeralSystem == "HEX")
        //                drawString[i] = ((frameToShow.frameArray[frameNum, i] & (int)FrameType.VITSM) >> 1).ToString("X2");
        //        }
        //    }
        //    this.Invalidate();
        //}

        private void FrameViewer_Paint(object sender, PaintEventArgs e)
        {
            if (FrameToShow == null || FrameToShow.Length == 0)
                return;

            //рисуем название и служебную часть кадра
            Font drawFont = new Font("Courier New", 10);
            SolidBrush drawBrush = new SolidBrush(Color.DarkMagenta);

            e.Graphics.DrawString("Служебная часть кадра \t Путь файла: " + Path, drawFont, drawBrush, 10, 10);
            for (int j = 0; j < frameInfoSize; j++)
                e.Graphics.DrawString(FrameToShow.frameArray[j].ToString(), drawFont, drawBrush, 10 + j * 40, 30);

            ////рисуем название и информационную часть кадра
            //drawBrush = new SolidBrush(Color.DarkBlue);
            //e.Graphics.DrawString("Информационная часть кадра", drawFont, drawBrush, 10, 70);
            //for (int i = 0; i < frameToShow.wordCount - frameInfoSize; i++)
            //{
            //e.Graphics.DrawString(drawString[frameInfoSize + i].ToString(), drawFont, drawBrush, 10 + i % 32 * 40, 90 + i / 32 * 20);
            //}

        }
    }
}
