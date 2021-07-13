using System;
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

        string[] line;
        public ushort[,] frameArray;
        public string path;
        public int wordCount;
        public int frameCount;
        public FrameType frameType;

        public Frame()
        {
            frameType = FrameType.BITSM;
        }
        public Frame(string path)
        {
            frameType = FrameType.BITSM;
            this.path = path;

            string strBuffer;
            StreamReader sr = new StreamReader(path);

            //Делим через пробелы строку из файла на слова
            while ((strBuffer = sr.ReadLine()) != null)
            {
                this.line = strBuffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //считаем колечство слов в кадре
            //считаем количство кадров в файле
            //удаляем все маркеры кадра
            WordCounter();
            FrameCounter();
            this.line = this.line.Where(val => val != "=KADR=").ToArray();

            //перегоняем из массива строк в массив [номер кадра, слово в кадре]
            frameArray = new ushort[frameCount, wordCount];
            for (int i = 0; i < frameCount; i++)
                for (int j = 0; j < wordCount; j++)
                    frameArray[i, j] = Convert.ToUInt16(this.line[(wordCount) * i + j], 16);
        }

        public void WordCounter()
        {
            bool wordKadrFlag = false;
            for (int i = 0; i < this.line.Length; i++)
            {
                if (this.line[i] == "=KADR=")
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
        }
        public void FrameCounter()
        {
            for (int i = 0; i < line.Length; i++)
                if (line[i] == "=KADR=")
                    frameCount++;
        }
    }
}
