using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public static class FrameFile
    {
        public static int wordCount = 0;
        public static int frameCount = 0;
        public static string[] Open(string path)
        {
            //Делим через пробелы строку из файла на слова
            if (File.ReadAllText(path) == null)
            {
                MessageBox.Show("Empty file!");
                return null;
            }

            //убираем пустые позиции
            string[] words = File.ReadAllText(path).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 

            //считаем количество слов в кадре
            bool wordKadrFlag = false;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "=KADR=")
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

            //считаем количество кадров
            for (int i = 0; i < words.Length; i++)
                if (words[i] == "=KADR=")
                    frameCount++;
            
            //убираем все метки КАДР и возвращаем массив строк
            return words.Where(val => val != "=KADR=").ToArray();
        }
    }
}
