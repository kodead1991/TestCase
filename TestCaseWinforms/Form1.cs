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
        Kadr k;
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(new string[] {"(0111111110) БИТС-М", "(0111001110) VITS-M" });
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
            k = new Kadr();
            k.openKadr(path);
            this.comboBox1.Enabled = true;
            this.frameViewer1.k = k; //передача массива кадров в Control отоборажения кадра
            this.trackBar1.Minimum = 1;
            this.trackBar1.Maximum = k.kadrCount;
            this.frameViewer1.displayKadrHEX(0); //отображение первого кадра после загрузки
        }

        //отображение выбранного кадра через изменение ползунка
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.displayKadrHEX(trackBar1.Value - 1);
            else
                this.frameViewer1.displayKadrDEC(trackBar1.Value - 1);

            this.kadrNumber.Text = Convert.ToString(this.trackBar1.Value);
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения формата отображения
        private void RadioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.displayKadrHEX(trackBar1.Value - 1);
            else
                this.frameViewer1.displayKadrDEC(trackBar1.Value - 1);
        }

        //перерисовка кадра в выбранном формате (HEX/DEC) из-за изменения стуктуры слов кадра
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (k == null || k.kadr.Length == 0)
                return;
            this.frameViewer1.k.kadrType = k.kadrType = this.comboBox1.Text; //передача типа структуры кадров в Control отоборажения кадра

            if (this.radioButtonHEX.Checked == true)
                this.frameViewer1.displayKadrHEX(trackBar1.Value - 1);
            else
                this.frameViewer1.displayKadrDEC(trackBar1.Value - 1);
        }
    }
}
