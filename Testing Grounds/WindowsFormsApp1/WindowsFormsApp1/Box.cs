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
	public class Box : Item
	{
		public int height { get; set; }
		public int width { get; set; }
		public Point TLCorner { get; set; } //Top Left Corner of box
		public Color color { get; set; }
		public int thickness { get; set; } //thickness of border lines
		public TextBox text;

		private DrawingSurface surface;

		public ContextMenuStrip contextMenu;

		public List<Line> top_anchor { get; private set; }
		public List<Line> bottom_anchor { get; private set; }
		public List<Line> left_anchor { get; private set; }
		public List<Line> right_anchor { get; private set; }

		public Line default_anchor { get; set; }

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

			top_anchor = new List<Line>();
			bottom_anchor = new List<Line>();
			left_anchor = new List<Line>();
			right_anchor = new List<Line>();

			default_anchor = null;

			contextMenu = d.boxMenu;

		}
		

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

			using (var path = getPath())
			{
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

			foreach (Line l in top_anchor)
			{
				l.MoveEndpoint(this, get_top_anchor_position());
			}

			foreach (Line l in bottom_anchor)
			{
				l.MoveEndpoint(this, get_bottom_anchor_position());
			}

			foreach (Line l in left_anchor)
			{
				l.MoveEndpoint(this, get_left_anchor_position());
			}

			foreach (Line l in right_anchor)
			{
				l.MoveEndpoint(this, get_right_anchor_position());
			}
		}

		public ContextMenuStrip GetContextMenu()
		{
			return contextMenu;
		}

		#region get anchor positions

		public Point get_top_anchor_position()
		{
			int x = TLCorner.X + (width / 2);
			int y = TLCorner.Y;

			return new Point(x, y);
		}

		public Point get_bottom_anchor_position()
		{
			int x = TLCorner.X + (width / 2);
			int y = TLCorner.Y + height;

			return new Point(x, y);
		}

		public Point get_left_anchor_position()
		{
			int x = TLCorner.X;
			int y = TLCorner.Y + (height / 2);

			return new Point(x, y);
		}

		public Point get_right_anchor_position()
		{
			int x = TLCorner.X + width;
			int y = TLCorner.Y + (height / 2);

			return new Point(x, y);
		}
		#endregion

		public void Connect(ref ConnectionLine line)
		{
			default_anchor = line;

			line.Connect(this);

			/*	How connecting works
			 *	
			 *	1.) The user right-clicks on a box and clicks "Connect To..."
			 *	
			 *	2.) A line is created, and immediately connected to the box the user right-clicked on.
			 *		2a.) The Drawing Surface calls the line's Connect() function, passing the box.
			 *		2b.) The Drawing Surface then calls the box's Connect() function, passing the line.
			 *			2ba.) The box must choose which anchor point to connect the line to. It could ask for the location of the connected endpoint.
			 *			OR
			 *			the line could ask the box to pick an anchor point, passing a point (e.g. the current position of the cursor), so it can find the closest anchor point.
			 *			
			 *			OR OR
			 *			The box could just pick a default anchor point (e.g. bottom), and then once both boxes have been connected, call a method to choose which anchor point
			 *			to move the endpoint to.
			 *		
			 *	3.) The user then clicks on a second box to finish the connection.
			 *		3a.) The Drawing Surface calls the line's Connect() function, passing the box.
			 *		3b.) The Drawing Surface then calls the box's Connect() function, passing the line.
			 *			3ba.) The box stores the line in a default anchor
			 *		
			 *	4.) The Drawing surface, knowing that the connection has been made, calls the second box's FinishConnection() function.
			 *		4a.) The function asks the line in it's default anchor for the position of the far endpoint
			 *			4aa.) the box could pass it's default_anchor position to the line, which will then compare to the locations of it's endpoints.
			 *				The line will then return the position of the endpoint connected to the other box.
			 *		4b.) The box then chooses which anchor point is closest to that far endpoint, moving the line into the appropriate List, and telling the line to move
			 *			the endpoint to the new position.
			 *			
			 *	5.) repeat step 4 but with the first box.
			 * 
			 */
		}

		public void FinishConnection()
		{
			/*
			 * Move the attached endpoint of the line stored in default_endpoint to the most appropriate anchor point.
			 * 
			 * For a box with 4 sides, there can be at most 2 possible faces (anchor points) the line can be attached at.
			 * 
			 * This could be made more efficient by ackowledging that if, for example, if farEndPoint.Y is between 
			 * TLCorner.Y and TLCorner.Y + height (i.e. the top and bottom of the box), then both the top and bottom anchors can be eliminated, leaving only left and right.
			 * I decided not to implement it that way because it would take longer, would be less readable, would be easier to skrew up, and because the added if statements
			 * may harm the program's performance in most cases (if not implemented well).
			 */

			Point farEndPoint = default_anchor.GetEndPoint(this, false);
			
			if (farEndPoint.Y <= TLCorner.Y) //eliminate the bottom anchor
			{
				float distanceT = Form1.distance(farEndPoint, get_top_anchor_position());

				if (farEndPoint.X <= TLCorner.X) //eliminate the right anchor
				{
					float distanceL = Form1.distance(farEndPoint, get_left_anchor_position());

					if(distanceT <= distanceL)
					{
						default_anchor.MoveEndpoint(this, get_top_anchor_position());
						top_anchor.Add(default_anchor);
						default_anchor = null;

					}
					else
					{
						default_anchor.MoveEndpoint(this, get_left_anchor_position());
						left_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
				else //eliminate the left anchor
				{
					float distanceR = Form1.distance(farEndPoint, get_right_anchor_position());

					if (distanceT <= distanceR)
					{
						default_anchor.MoveEndpoint(this, get_top_anchor_position());
						top_anchor.Add(default_anchor);
						default_anchor = null;
					}
					else
					{
						default_anchor.MoveEndpoint(this, get_right_anchor_position());
						right_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
			}
			else //eliminate the top anchor
			{
				float distanceB = Form1.distance(farEndPoint, get_bottom_anchor_position());

				if (farEndPoint.X <= TLCorner.X) //eliminate the right anchor
				{
					float distanceL = Form1.distance(farEndPoint, get_left_anchor_position());

					if (distanceB <= distanceL)
					{
						default_anchor.MoveEndpoint(this, get_bottom_anchor_position());
						bottom_anchor.Add(default_anchor);
						default_anchor = null;
					}
					else
					{
						default_anchor.MoveEndpoint(this, get_left_anchor_position());
						left_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
				else //eliminate the left anchor
				{
					float distanceR = Form1.distance(farEndPoint, get_right_anchor_position());

					if (distanceB <= distanceR)
					{
						default_anchor.MoveEndpoint(this, get_bottom_anchor_position());
						bottom_anchor.Add(default_anchor);
						default_anchor = null;
					}
					else
					{
						default_anchor.MoveEndpoint(this, get_right_anchor_position());
						right_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
			}


			/*

			float distanceT = Form1.distance(farEndPoint, get_top_anchor_position());
			float distanceB = Form1.distance(farEndPoint, get_bottom_anchor_position());
			float distanceL = Form1.distance(farEndPoint, get_left_anchor_position());
			float distanceR = Form1.distance(farEndPoint, get_right_anchor_position());

			if(distanceT <= distanceB)	//top or bottom?
			{
				if(distanceL <= distanceR) //left or right?
				{
					if(distanceT <= distanceL) //Top anchor has the shortest distance 
					{
						default_anchor.MoveEndpoint(this, get_top_anchor_position());
						top_anchor.Add(default_anchor);
						default_anchor = null;
					}

					else //left anchor
					{
						default_anchor.MoveEndpoint(this, get_left_anchor_position());
						left_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}

				else	//top or right?
				{
					if (distanceT <= distanceL) //Top anchor has the shortest distance 
					{
						default_anchor.MoveEndpoint(this, get_top_anchor_position());
						top_anchor.Add(default_anchor);
						default_anchor = null;
					}

					else //right anchor
					{
						default_anchor.MoveEndpoint(this, get_right_anchor_position());
						right_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
			}
			else
			{
				if (distanceL <= distanceR) //left or right?
				{
					if (distanceB <= distanceL) //bottom anchor has the shortest distance 
					{
						default_anchor.MoveEndpoint(this, get_bottom_anchor_position());
						bottom_anchor.Add(default_anchor);
						default_anchor = null;
					}

					else //left anchor
					{
						default_anchor.MoveEndpoint(this, get_left_anchor_position());
						left_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}

				else    //bottom or right?
				{
					if (distanceB <= distanceL) //bottom anchor has the shortest distance 
					{
						default_anchor.MoveEndpoint(this, get_bottom_anchor_position());
						bottom_anchor.Add(default_anchor);
						default_anchor = null;
					}

					else //right anchor
					{
						default_anchor.MoveEndpoint(this, get_right_anchor_position());
						right_anchor.Add(default_anchor);
						default_anchor = null;
					}
				}
			}

			*/
			
		}

		public bool handleConnection(Box b)
		{
			if(this == b)
			{
				return false;
			}

			ConnectionLine line = new ConnectionLine(TLCorner, b.TLCorner, ref surface);

			surface.Shapes.Add(line);

			Connect(ref line);

			b.Connect(ref line);

			FinishConnection();
			b.FinishConnection();

			return true;
		}
	}
}
