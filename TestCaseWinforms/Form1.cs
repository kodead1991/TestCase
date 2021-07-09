using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public partial class Form1 : Form
    {
        string path;
        Kadr k = new Kadr();
        private Label[,] kadrLabel;
        public Form1()
        {
            InitializeComponent();
            //label1 = new Label();
            //this.Controls.Add(label1);

            //this.label1.Location = new System.Drawing.Point(255, 187);
            //this.label1.Name = "label1";
            //this.label1.Size = new System.Drawing.Size(35, 13);
            //this.label1.TabIndex = 3;
            //this.label1.Text = "label1";
            //this.label1.AutoSize = true;
        }

        private void openFile_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем путь выбранного файла
            path = dialog.FileName;
            k = new Kadr();
            k.openKadr(path);
            this.frameViewer1.kadrInit(k);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Maximum = k.kadrCount;
            //int xStep = 42, yStep = 22;
            //trackBar1.Value = 1;
            //trackBar1.Minimum = 1;
            //trackBar1.Maximum = k.kadrCount;
            //kadrLabel = new Label[k.wordCount / 32 + 1, 32];
            //for (int i = 0; i < k.wordCount / 32 + 1; i++)
            //    for (int j = 0; j < 32; j++)
            //    {
            //        kadrLabel[i, j] = new Label();
            //        this.Controls.Add(kadrLabel[i, j]);
            //        kadrLabel[i, j].Name = "Pos" + i + "-" + j;
            //        if (k.kadr.GetLength(1) <= 32 * i + j)
            //            kadrLabel[i, j].Text = "";
            //        else
            //            kadrLabel[i, j].Text = k.kadr[0, 32 * i + j];
            //        kadrLabel[i, j].Location = new System.Drawing.Point(xStep * j + 12, yStep *i + 42);
            //        kadrLabel[i, j].Size = new System.Drawing.Size(35, 13);
            //        kadrLabel[i, j].TabIndex = 3;
            //        kadrLabel[i, j].AutoSize = true;
            //    }
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.frameViewer1.drawKadr(trackBar1.Value-1);
            this.kadrNumber.Text = Convert.ToString(this.trackBar1.Value);
            //for (int i = 0; i < k.wordCount / 32 + 1; i++)
            //    for (int j = 0; j < 32; j++)
            //    {
            //        if (k.kadr.GetLength(1) <= 32 * i + j)
            //            kadrLabel[i, j].Text = "";
            //        else
            //            kadrLabel[i, j].Text = k.kadr[this.trackBar1.Value - 1, 32 * i + j];
            //    }
            //this.label1.Text = Convert.ToString(this.trackBar1.Value);

            //frameViewer1.drawString = trackBar1.Value.ToString();
            //frameViewer1.Invalidate();
        }
    }
}
