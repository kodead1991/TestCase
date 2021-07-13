using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public class Frame
    {
        ushort[] words;
        int size;

        public int Length { get => words.Length;  }

        public Frame(string[] str, int size)
        {
            this.size = size;
            words = new ushort[size];
            for (int i = 0; i < size; i++)
                words[i] = Convert.ToUInt16(str[i], 16);
        }
    }
}
