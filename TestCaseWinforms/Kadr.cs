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
        public Kadr()
        {
            wordCount = 0;
            kadrCount = 0;
        }
        public void openKadr(string path)
        {
            kadrRead(path);    
            wordCounter();
            kadrCounter();
            kadrFill();            
        }
        public void kadrRead(string path)
        {
            string strBuffer;
            StreamReader sr = new StreamReader(path);
            while ((strBuffer = sr.ReadLine()) != null)
            {
                this.line = strBuffer.Split(' ').Select(s => s.Trim()).Where(s => s != "").ToArray();
            }
            this.line = this.line.Where(val => val != "=KADR=").ToArray();
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
        public void kadrFill()
        {
            kadr = new string[kadrCount, wordCount];
            for (int i = 0, ki = 0; i < kadrCount; i++)
            {
                for (int j = 0, kj = 0; j < wordCount + 1; j++)
                {
                    if (this.line[(wordCount + 1) * i + j] == "" || this.line[(wordCount + 1) * i + j] == "=KADR=")
                        continue;
                    kadr[ki, kj++] = this.line[(wordCount + 1) * i + j];
                }
                ki++;
            }
        }
        public void kadrFill(string str)
        {
            kadr = new string[kadrCount, wordCount];
            for (int i = 0, ki = 0; i < kadrCount; i++)
            {
                for (int j = 0, kj = 0; j < wordCount + 1; j++)
                {
                    kadr[ki, kj++] = str;
                }
                ki++;
            }
        }
    }
}
