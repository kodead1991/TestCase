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

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.comboBoxWordFormat.Items.AddRange(new object[] {
                new FrameViewInfo("0111111110", 0x1FE, 1),
                new FrameViewInfo("1111111111", 0x3FF, 0)
            });

            this.comboBoxWordFormat.SelectedIndex = 0;
            this.comboBoxWordFormat.Enabled = false;

            this.radioButtonDEC.Enabled = false;
            this.radioButtonHEX.Enabled = false;

            this.frameViewer.SelectedIndexChanged += FrameViewer_SelectedIndexChanged;
            this.gistoViewer.SelectedIndexChanged += GistoViewer_SelectedIndexChanged;
        }

        private void FrameViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gistoViewer.SelectedIndex != this.frameViewer.SelectedIndex)
            {
                this.gistoViewer.SelectedIndex = this.frameViewer.SelectedIndex;
            }
        }

        private void GistoViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.frameViewer.SelectedIndex != this.gistoViewer.SelectedIndex)
            {
                this.frameViewer.SelectedIndex = this.gistoViewer.SelectedIndex;
            }
        }   

        //открытие файла с кадром
        private void OpenFile_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файл кадра(*.kdr)|*.kdr|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            path = this.frameViewer.Path = this.gistoViewer.Path = dialog.FileName; // получаем путь выбранного файла

            wordNumber = FrameFile.WordCounter(new StreamReader(path));
            frameNumber = (int)new FileInfo(path).Length / (11 + wordNumber * 5);

            frames = new List<Frame>();

            StreamReader sr = new StreamReader(path);

            frames = FrameFile.Read(path);

            this.comboBoxWordFormat.Enabled = true;
            this.radioButtonDEC.Enabled = true;
            this.radioButtonHEX.Enabled = true;

            this.frameViewer.FrameToShow = this.gistoViewer.FrameToShow = frames[0]; //передача массива кадров в Control отоборажения кадра
            this.frameViewer.Param = this.gistoViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.frameViewer.Radix = this.gistoViewer.Radix = "X3";

            this.frameTrackBar.Minimum = 1;
            this.frameTrackBar.Maximum = frames.Count;
            this.frameTrackBar.Value = 1;
        }

        //отображение выбранного кадра через изменение ползунка
        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.currentFrameNumber.Text = this.frameTrackBar.Value.ToString();

            if (frames == null || frames.Count == 0)
                return;

            //передача массива кадров в Control отоборажения кадра
            this.frameViewer.FrameToShow = frames[this.frameTrackBar.Value - 1]; 
            this.gistoViewer.FrameToShow = frames[this.frameTrackBar.Value - 1];

        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
            {
                this.frameViewer.Radix = "X3";
                this.gistoViewer.Radix = "X3";
            }
            else
            {
                this.frameViewer.Radix = "D3";
                this.gistoViewer.Radix = "D3";
            }
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frames == null || frames.Count == 0)
                return;

            //передача типа структуры кадров в Control отоборажения кадра
            this.frameViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
        }
    }
}
