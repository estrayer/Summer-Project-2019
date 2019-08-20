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

		public Point p1 { get; set; }
		public Point p2 { get; set; }

		public int thickness { get; set; }
		public float sensitivity { get; set; }  //how generous the hit detection is (pretend the line is (thickness * sensitivity) pixels thick)

		public Color color { get; set; }
		public Point movingEnd { get; set; }

		private DrawingSurface surface;

		public Box item1 { get; set; }     //The item that endpoint p1 is anchored to
		public Box item2 { get; set; }     //The item that endpoint p2 is anchored to



		public Line(Point a, Point b, ref DrawingSurface d)
		{
			p1 = a;
			p2 = b;

			thickness = 10;
			color = Color.Black;

			surface = d;
			sensitivity = 1.5F;     //The F is used to tell c# that 1.5 is a float, rather than a double. because trying to store it in a Float variable
									//isn't enough of a hint.
			item1 = null;
			item2 = null;
		}

		public Line(Point a, Point b, ref DrawingSurface d, ref Box shapeA, ref Box shapeB) : this(a, b, ref d)	//this constructor will call the above constructor
																													//immediately before executing it's own code.
																													//this just avoids copying and pasteing the code.
		{
			item1 = shapeA;
			item2 = shapeB;
			
		}

		public GraphicsPath getPath()
		{
			var path = new GraphicsPath();

			path.AddLine(p1, p2);

			return path;
		}

		public virtual bool HitTest(Point p)
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

		public ContextMenuStrip GetContextMenu()
		{
			return new ContextMenuStrip();
		}

		public bool Connect(Box box)
		{
			if(item1 == null)
			{
				item1 = box;
				return true;
			}
			else if(item2 == null)
			{
				if (item1 == box) //There's no reason to have a line that connects a shape to itself. 
				{
					return false;
				}
				else
				{
					item2 = box;
					return true;
				}
			}
			else
			{
				//if this triggers, then there's an issue somewhere. This should never be happen.
				throw new ConnectionErrorException("Line is already fully connected");
			}
		}

		public void EnsureConnectivity()
		{
			//This function is called to make sure that the line is connected to two shapes.

			if (item1 == null && item2 == null)
			{
				throw new ConnectionErrorException("Line isn't connected to any shape");
			}

			if (item1 == null || item2 == null)
			{
				throw new ConnectionErrorException("Line isn't fully connected");
			}
		}

		public bool MoveEndpoint(Box box, Point p)
			//Unlike Move(), this ensures that the intended endpoint is moved. Which is particularly important if the connected shapes are overlapping eachother, such that
			//relying on distance could lead to un-intended results.
		{
			EnsureConnectivity();

			if(box.TLCorner == item1.TLCorner)
			{
				p1 = p;
				
			}
			else if(box.TLCorner == item2.TLCorner)
			{
				p2 = p;
				
			}
			else
			{
				return false;
			}

			//The caller (or someone else on the stack) must handle updating the drawing surface.

			return true;
			
		}

		public Point GetEndPoint(Box box, bool near = true)
		{
			EnsureConnectivity();

			if (box.TLCorner == item1.TLCorner)
			{
				if (near == true)
				{
					return p1;
				}
				else
				{
					return p2;
				}

			}
			else if (box.TLCorner == item2.TLCorner)
			{
				if (near == true)
				{
					return p2;
				}
				else
				{
					return p1;
				}
			}

			else
			{
				throw new ConnectionErrorException("Line isn't connected to specified Box");
			}
		}

		public bool handleConnection(Box b)
		{
			return false;
		}

	}
}
