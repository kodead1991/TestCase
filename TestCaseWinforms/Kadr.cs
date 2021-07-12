using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public class Kadr
    {
        string[] line;
        public string[,] kadr;
        public int wordCount { get; set; }
        public int kadrCount { get; set; }
        public string kadrType { get; set; }
        public Kadr()
        {
            wordCount = 0;
            kadrCount = 0;
            kadrType = "(0111111110) БИТС-М";
        }
        public void openKadr(string path)
        {
            kadrRead(path);              
        }
        public void kadrRead(string path)
        {
            string strBuffer;
            StreamReader sr = new StreamReader(path);

            //Делим через пробелы строку из файла на слова
            while ((strBuffer = sr.ReadLine()) != null)
            {
                this.line = strBuffer.Split(' ').Select(s => s.Trim()).Where(s => s != "").ToArray(); //убираем пустые позиции
            }

            //считаем колечство слов в кадре
            //считаем количство кадров в файле
            //удаляем все маркеры кадра
            wordCounter();
            kadrCounter();
            this.line = this.line.Where(val => val != "=KADR=").ToArray(); 

            //перегоняем из массива строк в массив [номер кадра, слово в кадре]
            kadr = new string[kadrCount, wordCount];
            for (int i = 0, ki = 0; i < kadrCount; i++)
            {
                for (int j = 0, kj = 0; j < wordCount; j++)
                    kadr[ki, kj++] = this.line[(wordCount) * i + j];
                ki++;
            }
        }
        public void wordCounter()
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

                if (line[i] == "")
                    continue;

                wordCount++;
            }
        }
        public void kadrCounter()
        {
            for (int i = 0; i < line.Length; i++)
                if (line[i] == "=KADR=")
                    kadrCount++;
        }    
    }
}
