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

        public event EventHandler RemoveCheckedCell;

        public FormMain()
        {
            InitializeComponent();
        }

        //инициализация главной формы при включении программы
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

            this.framePosBox.SelectionMode = SelectionMode.One;

            this.frameViewer.SelectedIndexChanged += FrameViewer_SelectedIndexChanged;
            this.frameViewer.AddСheckedPos += FrameViewer_AddСheckedPos;
            this.frameViewer.RemoveСheckedPos += FrameViewer_RemoveСheckedPos;

            this.gistoViewer.SelectedIndexChanged += GistoViewer_SelectedIndexChanged;

            this.framePosViewer.LinesInfoNeeded += OnFramePosViewerOnLinesInfoNeeded;

            this.RemoveCheckedCell += FormMain_RemoveCheckedCell;
            
        }

        private void FormMain_RemoveCheckedCell(object sender, EventArgs e)
        {
            this.frameViewer.cellChecked[this.framePosViewer.ListBoxSelectedIndex] = false;
        }

        //обработка события запроса списка из listBox'a
        private void OnFramePosViewerOnLinesInfoNeeded(object o, ChartLinesEventArgs args)
        {
            args.Info = framePosBox.Items.Cast<FramePosViewInfo>().ToArray();
        }

        //добавление элемента из listBox'a по двойному клику на frameViewer'e
        private void FrameViewer_AddСheckedPos(object sender, EventArgs e)
        {
            var newItem = new FramePosViewInfo(this.frameViewer.SelectedIndex);

            //проверка на повтор позиции в listBox'e
            for (int i = 0; i < this.framePosBox.Items.Count; i++)
            {
                var currentItem = (FramePosViewInfo)this.framePosBox.Items[i];
                if (currentItem.FrameIndex == newItem.FrameIndex)
                    return;
            }

            this.framePosBox.Items.Add(newItem);
            this.framePosBox.Invalidate();
        }

        //удаление элемента из listBox'a по двойному клику на frameViewer'e
        private void FrameViewer_RemoveСheckedPos(object sender, EventArgs e)
        {
            for (int i = 0; i < this.framePosBox.Items.Count; i++)
            {
                var item = (FramePosViewInfo)(this.framePosBox.Items[i]);
                if (item.FrameIndex == this.frameViewer.SelectedIndex)
                {
                    this.framePosBox.Items.RemoveAt(i);
                    Invalidate();
                }
            }
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

            frames = this.framePosViewer.Frames = FrameFile.Read(path);

            this.comboBoxWordFormat.Enabled = true;
            this.radioButtonDEC.Enabled = true;
            this.radioButtonHEX.Enabled = true;

            this.frameViewer.FrameToShow = this.gistoViewer.FrameToShow = frames[0]; //передача массива кадров в Control отоборажения кадра
            this.frameViewer.Param = this.gistoViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.frameViewer.Radix = this.gistoViewer.Radix = "X3";
            this.frameViewer.cellChecked = new bool[wordNumber];

            this.gistoViewer.Param = this.gistoViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.gistoViewer.Radix = this.gistoViewer.Radix = "X3";

            this.framePosViewer.Param = this.gistoViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.framePosViewer.Radix = this.gistoViewer.Radix = "X3";

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

            //передача в Control номера кадра
            this.framePosViewer.StartFramePos = this.frameTrackBar.Value - 1;

        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonRadix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
            {
                this.frameViewer.Radix = "X3";
                this.gistoViewer.Radix = "X3";
                this.framePosViewer.Radix = "X3";
            }
            else
            {
                this.frameViewer.Radix = "D3";
                this.gistoViewer.Radix = "D3";
                this.framePosViewer.Radix = "D3";
            }
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frames == null || frames.Count == 0)
                return;

            //передача типа структуры кадров в Control отоборажения кадра
            this.frameViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
            this.framePosViewer.Param = (FrameViewInfo)this.comboBoxWordFormat.Items[this.comboBoxWordFormat.SelectedIndex];
        }

        //перерисовка listBox'a после изменения индекса выделения элемента
        private void FramePosBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.framePosBox.DrawItem += new DrawItemEventHandler(FramePosBox_DrawItem);
        }

        private void FramePosBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //if (e.Index < 0)
            //    return;

            //проверка на наличие элементов в listBox'e
            if (this.framePosBox.Items.Count == 0)
            {
                //this.framePosBox.Items.Clear();
                return;
            }    
                

            FramePosViewInfo f = (FramePosViewInfo)this.framePosBox.Items[e.Index];

            //отрисовка номера выбранной позиции
            e.Graphics.DrawString(f.FrameIndex.ToString(),
                e.Font, f.FrameIndexBrush, e.Bounds, StringFormat.GenericDefault);

            Pen myPen = new Pen(f.FrameIndexBrush);
            myPen.Width = 2.0F;

            //отрисовка примера линии
            e.Graphics.DrawLine(myPen, 25, 5 + e.Index * 13, 100, 6 + e.Index * 13);

            //проверка на выделение элемента в listBox'e
            if (this.framePosBox.SelectedItem == null)
                return;

            //отрисовка прямоугольника выделения в listBox'e
            Rectangle itemRect = this.framePosBox.GetItemRectangle(this.framePosBox.SelectedIndex);
            e.Graphics.DrawRectangle(new Pen(Color.Black), itemRect);

        }

        //выбор элемента в listBox'e
        private void FramePosBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.framePosBox.SelectedItem == null)
                return;

            Rectangle itemRect = this.framePosBox.GetItemRectangle(this.framePosBox.SelectedIndex);
            if (itemRect.Contains(e.Location))
            {
                var framePosInfo = (FramePosViewInfo) this.framePosBox.Items[this.framePosBox.SelectedIndex];
                this.framePosViewer.ListBoxSelectedIndex = framePosInfo.FrameIndex;
                this.framePosBox.Invalidate();
            }
        }

        //удаление элемента из listBox'a по двойному клику на listBox
        private void FramePosBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.framePosBox.SelectedItem == null)
                return;

            Rectangle itemRect = this.framePosBox.GetItemRectangle(this.framePosBox.SelectedIndex);
            if (itemRect.Contains(e.Location))
            {
                this.framePosBox.Items.RemoveAt(this.framePosBox.SelectedIndex);

                if (RemoveCheckedCell != null)
                    RemoveCheckedCell(this, EventArgs.Empty);

                this.framePosViewer.ListBoxSelectedIndex = -1;
                this.framePosBox.Invalidate();
                this.framePosViewer.Invalidate();
                this.frameViewer.Invalidate();
            }
        }

        private void AddKadrPosView_Click(object sender, EventArgs e)
        {
            

            var colorSelectDialog = new ColorDialog();
            if (colorSelectDialog.ShowDialog() == DialogResult.OK)
            {
                var newItem = new FramePosViewInfo(this.frameViewer.SelectedIndex, colorSelectDialog.Color);

                //проверка на повтор позиции в listBox'e
                for (int i = 0; i < this.framePosBox.Items.Count; i++)
                {
                    var currentItem = (FramePosViewInfo)this.framePosBox.Items[i];
                    if (currentItem.FrameIndex == newItem.FrameIndex)
                        return;
                }

                this.framePosBox.Items.Add(newItem);
                this.framePosBox.Invalidate();
            }
        }

        private void DeleteKadrPosView_Click(object sender, EventArgs e)
        {
            if (this.framePosBox.SelectedItem == null)
            {
                MessageBox.Show("Позиция кадра не выбрана!", "Сообщение об ошибке", MessageBoxButtons.OK);
                return;
            }
                

            Rectangle itemRect = this.framePosBox.GetItemRectangle(this.framePosBox.SelectedIndex);

            this.framePosBox.Items.RemoveAt(this.framePosBox.SelectedIndex);

            if (RemoveCheckedCell != null)
                RemoveCheckedCell(this, EventArgs.Empty);

            this.framePosViewer.ListBoxSelectedIndex = -1;
            this.framePosBox.Invalidate();
            this.framePosViewer.Invalidate();
            this.frameViewer.Invalidate();
        }
    }
}
