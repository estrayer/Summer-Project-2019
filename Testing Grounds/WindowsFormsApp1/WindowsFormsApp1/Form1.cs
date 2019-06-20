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

	}

	public interface Item
    {
        GraphicsPath getPath();
        bool HitTest(Point p);
        void Draw(Graphics g);
        void Move(Point p);
    }

	public class Line : Item
	{
		public Line(Point a, Point b, ref DrawingSurface d)
		{
			p1 = a;
			p2 = b;

			thickness = 10;
			color = Color.Black;

			surface = d;
			sensitivity = 1.5F;     //The F is used to tell c# that 1.5 is a float, rather than a double. because strying to store it in a Float variable
									//isn't enough of a hint.
		}

		public GraphicsPath getPath()
		{
			var path = new GraphicsPath();

			path.AddLine(p1, p2);

			return path;
		}

		public bool HitTest(Point p)
		{
			var result = false;
			using (var path = getPath())
			{
				using (var pen = new Pen(color, thickness * sensitivity))
				{
					result = path.IsOutlineVisible(p, pen);
				}
			}

			if(result == true)
			{
				//EndPointHitTest(p);
				
				
				if (!EndPointHitTest(p))
				{
					movingEnd = Point.Empty;
				}
				
			}
			return result;
		}

		private bool EndPointHitTest(Point p)
		{
			if (Form1.distance(p, p1) <= (thickness * sensitivity))
			{
				movingEnd = p1;
				return true;
			}
			else if(Form1.distance(p, p2) <= (thickness * sensitivity))
			{
				movingEnd = p2;
				return true;
			}

			return false;
		}

		public void Draw(Graphics g)
		{
			using (var path = getPath())
			{
				using (var pen = new Pen(color, thickness))
				{
					g.DrawPath(pen, path);
				}
			}
		}
		public void Move(Point p)
		{
			//p1 = new Point(p1.X + p.X, p1.Y + p.Y);


			/*
			if (surface.moving == true)
			{
			*/
			
				if (movingEnd.Equals(p1))
				{
					p1 = new Point(p1.X + p.X, p1.Y + p.Y);
					movingEnd = p1;
				}
				else if (movingEnd.Equals(p2))
				{
					p2 = new Point(p2.X + p.X, p2.Y + p.Y);
					movingEnd = p2;
				}
				else
				{
					p1 = new Point(p1.X + p.X, p1.Y + p.Y);
					p2 = new Point(p2.X + p.X, p2.Y + p.Y);
				}
				//movingEnd.X = movingEnd.X + p.X;
				//movingEnd.Y = movingEnd.Y + p.Y;
		
			/*
				}

				else //This will be necessary if we ever allow dragging the background to move all shapes around
				{
					p1 = new Point(p1.X + p.X, p1.Y + p.Y);
					p2 = new Point(p2.X + p.X, p2.Y + p.Y);
				}
			*/
		}

		public Point p1 { get; set; }
		public Point p2 { get; set; }

		public int thickness { get; set; }
		public float sensitivity { get; set; }  //how generous the hit detection is (pretend the line is (thickness * sensitivity) pixels thick)
														
		public Color color { get; set; }
		public Point movingEnd { get; set; }

		private DrawingSurface surface;
		
	}

    public class Box : Item
    {
        public Box(Point p, ref DrawingSurface d)
        {
            height = 50;
            width = 100;
            color = Color.Black;
            thickness = 5;
			TLCorner = p;
			text = new TextBox();
			text.Width = 50;

			surface = d;
        }
        public int height { get; set; }
        public int width { get; set; }
        public Point TLCorner { get; set; } //Top Left Corner of box
        public Color color { get; set; }
        public int thickness { get; set; } //thickness of border lines
		public TextBox text;

		private DrawingSurface surface;

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

        public void Draw(Graphics g)
        {
           // using (var path = getPath())
           // {
                using (var pen = new Pen(color, thickness))
                {
                    g.DrawRectangle(pen, new Rectangle(TLCorner.X, TLCorner.Y, width, height));
				int x = TLCorner.X + (width / 2) - (text.Width / 2);
				int y = TLCorner.Y + (height / 2) - (text.Height / 2);

				surface.Controls.Add(text);
				

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
        public bool moving { get; private set; }
		Point previousPoint = Point.Empty;

		public DrawingSurface(){
			DoubleBuffered = true;
			Shapes = new List<Item>();
			moving = false;
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
				moving = true;
				previousPoint = e.Location;
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
				shape.Draw(e.Graphics);
			}

			base.OnPaint(e);
		}
	}
}
