using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing.Drawing2D.GraphicsPath;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        PaintEventArgs PEA;

        public Form1()
        {
            InitializeComponent();
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

			Box box = new Box(p);

			drawingSurface1.Shapes.Add(box);

			box.Draw(drawingSurface1.CreateGraphics(), drawingSurface1);
        }

        private void paint_Rectangle(Rectangle box)
        {
            Pen pen = new Pen(Color.Black, 2);

            

            PEA.Graphics.DrawRectangle(pen, box);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            PEA = e;
			Rectangle rect = new Rectangle(0, 0, 200, 100);
            paint_Rectangle(rect);
        }
    }

    public interface Item
    {
        GraphicsPath getPath();
        bool HitTest(Point p);
        void Draw(Graphics g, DrawingSurface d);
        void Move(Point p);
    }

    public class Box : Item
    {
        public Box(Point p)
        {
            height = 50;
            width = 100;
            color = Color.Black;
            thickness = 5;
			TLCorner = p;
			text = new TextBox();
			text.Width = 50;
			
        }
        public int height { get; set; }
        public int width { get; set; }
        public Point TLCorner { get; set; } //Top Left Corner of box
        public Color color { get; set; }
        public int thickness { get; set; } //thickness of border lines
		public TextBox text;

		public GraphicsPath getPath()
        {
            var path = new GraphicsPath();

            Rectangle rect = new Rectangle(TLCorner.X, TLCorner.Y, width, height);

            path.AddRectangle(rect);
            return path;
        }

        public bool HitTest(Point p)
        {
            bool result = false;

            using (var path = getPath()) {
                //the "using" statement in this context seems to be a memory management tool
                //and the statement expands into a try-finally block (a try-catch block with no catch block, but a finally block that executes regardless of exceptions)

                //At the end of the "using" statement, it calls "Dispose" on the variable declared or specified in the parentheses.
                //look-up IDisposable for more info
                result = path.IsVisible(p);
            }
            return result;
        }

        public void Draw(Graphics g, DrawingSurface d)
        {
           // using (var path = getPath())
           // {
                using (var pen = new Pen(color, thickness))
                {
                    g.DrawRectangle(pen, new Rectangle(TLCorner.X, TLCorner.Y, width, height));
				int x = TLCorner.X + (width / 2) - (text.Width / 2);
				int y = TLCorner.Y + (height / 2) - (text.Height / 2);

				d.Controls.Add(text);

				//int x = 0;
				//int y = 0;
				text.Location = new Point(x, y);
				text.Show();
				//text.Visible = true;
				//text.BringToFront();


			}
           // }
        }

        public void Move(Point p)
        {
            TLCorner = new Point(TLCorner.X + p.X, TLCorner.Y + p.Y);

			int x = TLCorner.X + (width / 2) - (text.Width / 2);
			int y = TLCorner.Y + (height / 2) - (text.Height / 2);

			text.Location = new Point(x, y);
		}
    }

    public class DrawingSurface : Control
    {
        public List<Item> Shapes { get; private set; }
        Item selectedShape;
        bool moving;
		Point previousPoint = Point.Empty;

		public DrawingSurface(){
			DoubleBuffered = true;
			Shapes = new List<Item>();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			for(var i = Shapes.Count - 1; i >= 0; i--)
			{
				if (Shapes[i].HitTest(e.Location))
				{
					selectedShape = Shapes[i];
					break;
				}
			}

			if(selectedShape != null)
			{
				moving = true; previousPoint = e.Location;
			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (moving)
			{
				var p = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
				selectedShape.Move(p);
				previousPoint = e.Location;
				this.Invalidate();
			}

			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(moving)
			{
				selectedShape = null;
				moving = false;
			}

			base.OnMouseUp(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			foreach(var shape in Shapes)
			{
				shape.Draw(e.Graphics, this);
			}

			base.OnPaint(e);
		}
	}
}
