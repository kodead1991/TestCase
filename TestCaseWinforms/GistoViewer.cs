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
    public partial class GistoViewer : UserControl
    {

        Font _drawFont = new Font("Courier New", 10);
        SolidBrush _drawBrushService = new SolidBrush(Color.DarkMagenta);
        SolidBrush _drawBrushData = new SolidBrush(Color.DarkBlue);
        Pen _levelLinePen = new Pen(Brushes.DeepSkyBlue);

        public GistoViewer()
        {
            InitializeComponent();
            Invalidate();
            _levelLinePen.Width = 1.0F;
            _levelLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

        }

        private void GistoViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 0), new Point(1710, 0));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 128), new Point(1710, 128));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 256), new Point(1710, 256));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 392), new Point(1710, 392));
            e.Graphics.DrawLine(_levelLinePen, new Point(0, 512), new Point(1710, 512));
        }
    }
}
