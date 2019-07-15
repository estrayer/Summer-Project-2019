using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
		public static Form1 form;

        public Form1()
        {
            InitializeComponent();
			form = this;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
		
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void arrayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insert_Rectangle_Click(object sender, EventArgs e)
        {
			//PaintEventArgs pea = new PaintEventArgs();

			//  Rectangle box = new Rectangle(250, 0, 100, 200);

			// paint_Rectangle(box);

			Point p = new Point(100, 100);

			Box box = new Box(p, ref drawingSurface1);

			drawingSurface1.Shapes.Add(box);

			box.Draw(drawingSurface1.CreateGraphics());
        }


		private void insert_Line_Click(object sender, EventArgs e)
		{
			Point p1 = new Point(100, 150);
			Point p2 = new Point(100, 300);

			Line line = new Line(p1, p2, ref drawingSurface1);

			drawingSurface1.Shapes.Add(line);

			line.Draw(drawingSurface1.CreateGraphics());
		}

		public static int distance(Point p1, Point p2)
		{
			int a = p1.X - p2.X;
			int b = p1.Y - p2.Y;

			double cSquared = Math.Pow(a, 2) + Math.Pow(b, 2);
			int c = (int) Math.Truncate(Math.Sqrt(cSquared));

			return c;
		}

		private void drawingSurface1_Click(object sender, EventArgs e)
		{

		}

		private void connectTo(object sender, EventArgs e)
		{
			
		}
	}
}
