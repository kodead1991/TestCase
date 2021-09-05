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
    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
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
    }

    public partial class FramePosDialog : Form
    {
        private Color selectedColor;


        public FramePosDialog()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                this.lineType_comboBox.Items.Add(new object());
            }
        }

        private void colorChooseButton_Click(object sender, EventArgs e)
        {
            var colorSelectDialog = new ColorDialog();

            if (colorSelectDialog.ShowDialog() == DialogResult.OK)
                this.colorButton.BackColor = selectedColor = colorSelectDialog.Color;
        }
    }
}
