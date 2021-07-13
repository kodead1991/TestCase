using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestCaseWinforms
{
    public static class FrameFile
    {
        public static Frame Read(StreamReader sr, int wordNumber, int frameNumber)
        {
            int frameSize = wordNumber * 5 + 11;
            int startPos = frameSize * frameNumber;
            char[] charLine = new char[frameSize];
            sr.Read(charLine, startPos, startPos + frameSize);
            string[] str = (new string(charLine)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            str = str.Where(val => val != "=KADR=").ToArray();

            Frame frame = new Frame(wordNumber);
            for (int i = wordNumber * frameNumber; i < wordNumber * (frameNumber + 1); i++)
            {
                frame.frameArray[i - wordNumber * frameNumber] = Convert.ToUInt16(str[i], 16);
            }
            return frame;
        }
        public static int WordCounter(StreamReader sr)
        {
            bool wordKadrFlag = false;
            int wordCount = 0;
            char[] charLine = new char[5000];
            sr.Read(charLine, 0, 5000);
            string[] str = (new string(charLine)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == "=KADR=")
                {
                    if (wordKadrFlag != true)
                    {
                        wordKadrFlag = true;
                        continue;
                    }
                    else
                        break;
                }
                wordCount++;
            }

            return wordCount;
        }
        public static long FrameCounter(string path)
        {
            return (new System.IO.FileInfo(path).Length);
        }
    }
}
