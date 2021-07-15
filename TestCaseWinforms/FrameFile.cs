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
        private static int _charCountService = 11;
        private static char[] _charLine;

        public static Frame Read(StreamReader sr, int wordNumber, int frameNumber)
        {
            int frameSize = wordNumber * 5 + _charCountService;
            char[] charLine = new char[frameSize];
            sr.Read(charLine, 0, frameSize);

            string[] str = (new string(charLine, _charCountService, frameSize - _charCountService))
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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

            var wordNumber = WordCounter(new StreamReader(path));

            using (StreamReader stream = new StreamReader(path))
            {
                while (TryReadFrame(stream, wordNumber, out frame))
                    frames.Add(frame);
            }
            return frames;
        }
        private static bool TryReadFrame(StreamReader stream, int wordNumber, out Frame frame)
        {
            int frameSize = wordNumber * 5 + _charCountService;

            if (_charLine == null || _charLine.Length != frameSize)
                _charLine = new char[frameSize];

            if (stream.Read(_charLine, 0, frameSize) != _charLine.Length)
            {
                frame = null;
                return false;
            }

            string[] str = (new string(_charLine, _charCountService, frameSize - _charCountService))
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            frame = new Frame(wordNumber);
            for (int i = 0; i < wordNumber; i++)
            {
                frame.frameArray[i] = Convert.ToUInt16(str[i], 16);
            }

            return true;
        }
        public static int WordCounter(StreamReader sr)
        {
            bool wordKadrFlag = false;

            int wordCount = 0;

            char[] buffer = new char[5000];

            var byteRead = sr.Read(buffer, 0, 5000);

            string[] str = (new string(buffer, 0, byteRead))
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
    }
}
