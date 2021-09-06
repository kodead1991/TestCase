using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseWinforms
{
    public struct KadrPosLine
    {
        public Color color;
        public int pos;
        public DashStyle dashStyle;
    }

    public partial class FramePosDialog : Form
    {
        public KadrPosLine line;

        public FramePosDialog()
        {
            InitializeComponent();

            //Добавляем в combobox объекты для 
            for (int i = 0; i < 5; i++)
                this.lineType_comboBox.Items.Add(new object());
        }

        private void colorChooseButton_Click(object sender, EventArgs e)
        {
            var colorSelectDialog = new ColorDialog();

            if (colorSelectDialog.ShowDialog() == DialogResult.OK)
                this.selectedColor_button.BackColor = line.color = colorSelectDialog.Color;
        }

        private void LineType_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Point p1 = new Point(e.Bounds.Left + 5, e.Bounds.Y + 8);
            Point p2 = new Point(e.Bounds.Right - 5, e.Bounds.Y + 8);

            switch (e.Index)
            {
                case 0:
                    using (Pen SolidmyPen = new Pen(e.ForeColor, 2.0F))
                        e.Graphics.DrawLine(SolidmyPen, p1, p2);
                    break;
                case 1:
                    using (Pen DashedPen = new Pen(e.ForeColor, 2.0F))
                    {
                        DashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(DashedPen, p1, p2);
                    }
                    break;
                case 2:
                    using (Pen DashedPen = new Pen(e.ForeColor, 2.0F))
                    {
                        DashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        e.Graphics.DrawLine(DashedPen, p1, p2);
                    }
                    break;
                case 3:
                    using (Pen DashDot = new Pen(e.ForeColor, 2.0F))
                    {
                        DashDot.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        e.Graphics.DrawLine(DashDot, p1, p2);
                    }
                    break;
                case 4:
                    using (Pen DashedPen = new Pen(e.ForeColor, 2.0F))
                    {
                        DashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        e.Graphics.DrawLine(DashedPen, p1, p2);
                    }
                    break;
            }
        }

        private void KadrPos_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) //цифры и backspace
            {
                e.Handled = true;
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            if (this.kadrPos_textbox.Text == "")
            {
                MessageBox.Show("Введите номер позиции", "Ошибка");
                this.kadrPos_textbox.Focus();
            }
            else if (Convert.ToInt32(this.kadrPos_textbox.Text) - 1 > 543 - 1) //номер позиции начинается с 0, а отображается с 1
            {
                MessageBox.Show("Несуществующий номер позиции кадра", "Ошибка");
                this.kadrPos_textbox.Clear();
                this.kadrPos_textbox.Focus();
            }
            else
            {
                this.line.color = this.selectedColor_button.BackColor;
                this.line.pos = Convert.ToInt32(this.kadrPos_textbox.Text) - 1;
                switch (lineType_comboBox.SelectedIndex)
                {
                    case 0: this.line.dashStyle = DashStyle.Solid; break;
                    case 1: this.line.dashStyle = DashStyle.Dash; break;
                    case 2: this.line.dashStyle = DashStyle.Dot; break;
                    case 3: this.line.dashStyle = DashStyle.DashDot; break;
                    case 4: this.line.dashStyle = DashStyle.DashDotDot; break;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void KadrPos_textbox_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.kadrPos_textbox, "от 1 до 543");
        }

        private void LineType_comboBox_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.lineType_comboBox, "Вид отображаемой линии");
        }

        private void SelectedColor_button_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.selectedColor_button, "Цвет отображаемой линии");
        }
    }
}
