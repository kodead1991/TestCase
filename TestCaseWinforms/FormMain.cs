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

            foreach (var item in Controls.OfType<UserControl>())
            {
                item.PreviewKeyDown += controls_PreviewKeyDown;
            }

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
            frameNumber = (int)new FileInfo(path).Length / (11 + wordNumber * 5);
            frames = new List<Frame>();
            StreamReader sr = new StreamReader(path);
            //for (int i = 0; i < frameNumber; i++)
            //{
            //    frames.Add(FrameFile.Read(sr, wordNumber, i));
            //}
            frames = FrameFile.Read(path);
            this.comboBoxWordFormat.Enabled = true;
            this.radioButtonDEC.Enabled = true;
            this.radioButtonHEX.Enabled = true;
            this.frameViewer.FrameToShow = frames[0]; //передача массива кадров в Control отоборажения кадра
            this.frameViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.frameViewer.Radix = "X3";
            this.frameTrackBar.Minimum = 1;
            this.frameTrackBar.Maximum = frames.Count;
            this.frameTrackBar.Value = 1;
        }

        //отображение выбранного кадра через изменение ползунка
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.currentFrameNumber.Text = this.frameTrackBar.Value.ToString();
            if (frames == null || frames.Count == 0)
                return;
            this.frameViewer.FrameToShow = frames[this.frameTrackBar.Value - 1]; //передача массива кадров в Control отоборажения кадра
            
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer.Radix = "X3";
            else
                this.frameViewer.Radix = "D3";
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frames == null || frames.Count == 0)
                return;

            //передача типа структуры кадров в Control отоборажения кадра
            this.frameViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
        }

        private void frameViewer_MouseClick(object sender, MouseEventArgs e)
        {
            this.frameViewer.MousePos = e.Location;
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            this.frameViewer.KeyPos = e.KeyCode;
        }


        private void controls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    this.frameViewer.KeyPos = e.KeyCode;
                    break;
                default:
                    break;
            }
        }
    }
}
