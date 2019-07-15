using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public class Line : Item
	{
		public Line(Point a, Point b, ref DrawingSurface d)
		{
			p1 = a;
			p2 = b;

			thickness = 10;
			color = Color.Black;

			surface = d;
			sensitivity = 1.5F;     //The F is used to tell c# that 1.5 is a float, rather than a double. because trying to store it in a Float variable
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

			if (result == true)
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
			else if (Form1.distance(p, p2) <= (thickness * sensitivity))
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

		public ContextMenuStrip getContextMenu()
		{
			return new ContextMenuStrip();
		}

		public Point p1 { get; set; }
		public Point p2 { get; set; }

		public int thickness { get; set; }
		public float sensitivity { get; set; }  //how generous the hit detection is (pretend the line is (thickness * sensitivity) pixels thick)

		public Color color { get; set; }
		public Point movingEnd { get; set; }

		private DrawingSurface surface;
	}
}
