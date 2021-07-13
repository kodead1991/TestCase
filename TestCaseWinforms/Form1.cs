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
        Frame frame;
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(new string[] { "(0111111110) БИТС-М", "(0111001110) VITS-M" });
            this.comboBox1.SelectedIndex = 1;
            this.comboBox1.Enabled = false;
            this.radioButtonDEC.Enabled = false;
            this.radioButtonHEX.Enabled = false;
        }

        //открытие файла с кадром
        private void OpenFile_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файл кадра(*.kdr)|*.kdr|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;


            path = dialog.FileName; // получаем путь выбранного файла
            frame = new Frame(path);
            this.comboBox1.Enabled = true;
            this.radioButtonDEC.Enabled = true;
            this.radioButtonHEX.Enabled = true;
            this.frameViewer1.frameToShow = frame; //передача массива кадров в Control отоборажения кадра
            this.trackBar1.Minimum = 1;
            this.trackBar1.Maximum = frame.frameCount;
            this.trackBar1.Value = 1;
            this.frameViewer1.DisplayFrame(this.trackBar1.Value, "HEX"); //отображение первого кадра после загрузки
        }

        //отображение выбранного кадра через изменение ползунка
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "HEX");
            else
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "DEC");

            this.kadrNumber.Text = this.trackBar1.Value.ToString();
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "HEX");
            else
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "DEC");
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frame == null || frame.frameArray.Length == 0)
                return;

            //передача типа структуры кадров в Control отоборажения кадра
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    this.frameViewer1.frameToShow.frameType = frame.frameType = FrameType.BITSM; break;
                case 1:
                    this.frameViewer1.frameToShow.frameType = frame.frameType = FrameType.VITSM; break;
                default:
                    break;
            }

            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "HEX");
            else
                this.frameViewer1.DisplayFrame(trackBar1.Value - 1, "DEC");
        }
    }
}
