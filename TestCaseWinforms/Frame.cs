﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace TestCaseWinforms
{
    public enum FrameType { BITSM = 0x1FE, VITSM = 0x1CE };
    public class Frame
    {
        public ushort[] frameArray;


        public Frame(int size)
        {
            frameArray = new ushort[size];
        }
    }
}
