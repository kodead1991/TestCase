using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestCaseConsole
{
    class Kadr
    {
        string[] line;
        string[,] kadr;
        int wordCount;
        int kadrCount;
        public Kadr()
        {
            kadr = null;
            wordCount = 0;
            kadrCount = 0;
        }
        public void openKadr(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                this.line = line.Split(' ');
                
                wordCounter();
                kadrCounter();
                
                kadr = new string[kadrCount, wordCount];
                for (int i = 0, ki = 0; i < kadrCount; i++)
                {
                    for (int j = 0, kj = 0; j < wordCount+5; j++)
                    {
                        if (this.line[(wordCount + 5) * i + j] == "" || this.line[(wordCount+5)*i + j] == "=KADR=")
                            continue;
                        kadr[ki,kj++] = this.line[(wordCount + 5) * i + j];
                    }
                    ki++;
                }

                Console.WriteLine("Число слов в кадре = {0}\nЧисло кадров в файле = {1}", wordCount, kadrCount);
                //foreach (var item in kadr)
                //{
                //    Console.WriteLine(item);
                //}
            }
        }
        public void wordCounter()
        {
            bool wordKadrFlag = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == "=KADR=")
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
