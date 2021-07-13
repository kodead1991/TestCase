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
        public ushort[,] frameArray;
        FrameViewInfo[] frameInfo = new FrameViewInfo[2];
        public Form1()
        {
            InitializeComponent();
            this.frameViewer1.Radix = "HEX";
            frameInfo[0] = new FrameViewInfo(0b0111111110, "БИТС-М");
            frameInfo[1] = new FrameViewInfo(0b0111001110, "МИТС-Б");
            this.comboBox1.Items.Add(frameInfo[0]);
            this.comboBox1.Items.Add("(" + frameInfo[1].Mask.ToString() + ") " + frameInfo[1].Structure);
            this.comboBox1.SelectedIndex = 1;
            this.comboBox1.Enabled = false;
        }

        //открытие файла с кадром
        private void openFile_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файл кадра(*.kdr)|*.kdr|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            path = dialog.FileName; // получаем путь выбранного файла
            string[] strBuffer = FrameFile.Open(path);
            frameArray = new ushort[FrameFile.frameCount, FrameFile.wordCount];
            for (int i = 0; i < FrameFile.frameCount;i++)
            {
                for (int j = 1; j <= FrameFile.wordCount; j++)
                {
                    frameArray[i] = strBuffer.ToArray()
                }
            }

            this.comboBox1.Enabled = true;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Maximum = FrameFile.frameCount;
            //this.frameViewer1.displayKadrHEX(this.trackBar1.Value); //отображение первого кадра после загрузки
        }

        //отображение выбранного кадра через изменение ползунка
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            //if (this.radioButtonHEX.Checked == true)
            //    this.frameViewer1.displayKadrHEX(trackBar1.Value - 1);
            //else
            //    this.frameViewer1.displayKadrDEC(trackBar1.Value - 1);

            this.kadrNumber.Text = Convert.ToString(this.trackBar1.Value);
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.Radix = "DEC";
        }

        private void radioButtonDEC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonDEC.Checked == true)
                this.frameViewer1.Radix = "HEX";
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
