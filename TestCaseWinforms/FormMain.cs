using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TestCaseWinforms
{
    public partial class FormMain : Form
    {
        public string path;
        int wordNumber;
        int frameNumber;
        List<Frame> frames;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBoxWordFormat.Items.AddRange(new object[] { new FrameViewInfo("0111111110", 0x1FE, 1), new FrameViewInfo("1111111111", 0x3FF, 0) });
            this.comboBoxWordFormat.SelectedIndex = 0;
            this.comboBoxWordFormat.Enabled = false;
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
            
            path = this.frameViewer.Path = dialog.FileName; // получаем путь выбранного файла
            wordNumber = FrameFile.WordCounter(new StreamReader(path));
            frameNumber = (int) new FileInfo(path).Length / (11 + wordNumber * 5);
            frames = new List<Frame>();
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < frameNumber; i++)
            {
                frames.Add(FrameFile.Read(sr, wordNumber, i));
            }

            this.comboBoxWordFormat.Enabled = true;
            this.radioButtonDEC.Enabled = true;
            this.radioButtonHEX.Enabled = true;
            this.frameViewer.FrameToShow = frames[0]; //передача массива кадров в Control отоборажения кадра
            //this.trackBar1.Minimum = 1;
            //this.trackBar1.Maximum = frame.frameCount;
            //this.trackBar1.Value = 1;
            //this.frameViewer.DisplayFrame(this.trackBar1.Value, "HEX"); //отображение первого кадра после загрузки
            //List<Frame> frameList = new List<Frame>();
            //for (int i = 0; i < length; i++)
            //{
            //    frameList.Add()

            //}
        }


        //отображение выбранного кадра через изменение ползунка
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            //if (this.radioButtonHEX.Checked == true)
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "HEX");
            //else
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "DEC");

            //this.kadrNumber.Text = this.trackBar1.Value.ToString();
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.radioButtonHEX.Checked == true)
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "HEX");
            //else
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "DEC");
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frames == null || frames.Count == 0)
                return;

            //передача типа структуры кадров в Control отоборажения кадра
            switch (this.comboBoxWordFormat.SelectedIndex)
            {
                //case 0:
                //    this.frameViewer.frameToShow.frameType = frame.frameType = FrameType.BITSM; break;
                //case 1:
                //    this.frameViewer.frameToShow.frameType = frame.frameType = FrameType.VITSM; break;
                //default:
                //    break;
            }

            //if (this.radioButtonHEX.Checked == true)
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "HEX");
            //else
            //    this.frameViewer.DisplayFrame(trackBar1.Value - 1, "DEC");
        }
    }
}
