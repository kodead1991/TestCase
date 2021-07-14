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
        private static int _wordNumber;
        private static long _frameNumber;

        public static Frame Read(StreamReader sr, int wordNumber, int frameNumber)
        {
            int frameSize = wordNumber * 5 + 11;
            char[] charLine = new char[frameSize];
            sr.Read(charLine, 0, frameSize);

            string[] str = (new string(charLine)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            str = str.Where(val => val != "=KADR=").ToArray();

            Frame frame = new Frame(wordNumber);
            for (int i = 0; i < wordNumber; i++)
            {
                frame.frameArray[i] = Convert.ToUInt16(str[i], 16);
            }
            return frame;
        }
        public static List<Frame> Read(string path)
        {
            var frames = new List<Frame>();
            Frame frame;
            _wordNumber = WordCounter(new StreamReader(path));
            _frameNumber = FrameCounter(path);
            StreamReader stream = new StreamReader(path);
            using (stream)
            {
                while (TryReadFrame(stream, out frame))
                    frames.Add(frame);
            }
            return frames;
        }
        private static bool TryReadFrame(StreamReader stream, out Frame frame)
        {
            int frameSize = _wordNumber * 5 + 11;
            char[] charLine = new char[frameSize];
            if (stream.Read(charLine, 0, frameSize) != charLine.Length)
            {
                frame = null;
                return false;
            }

            string[] str = (new string(charLine)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            str = str.Where(val => val != "=KADR=").ToArray();

            frame = new Frame(_wordNumber);
            for (int i = 0; i < _wordNumber; i++)
            {
                frame.frameArray[i] = Convert.ToUInt16(str[i], 16);
            }

            return true;
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
