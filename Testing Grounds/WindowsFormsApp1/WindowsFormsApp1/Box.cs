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

			System.Windows.Forms.ToolStripMenuItem freeze = new ToolStripMenuItem();
			System.Windows.Forms.ToolStripMenuItem connect = new ToolStripMenuItem();
			System.Windows.Forms.ToolStripMenuItem boxSpecificOptionToolStripMenuItem = new ToolStripMenuItem();

			contextMenu = new ContextMenuStrip();
			// 
			// boxContextMenu
			// 
			contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			freeze,
			connect,
			boxSpecificOptionToolStripMenuItem});

			contextMenu.Name = "boxContextMenu";
			contextMenu.Size = new System.Drawing.Size(178, 70);
			// 
			// freeze
			// 
			freeze.Name = "freeze";
			freeze.Size = new System.Drawing.Size(177, 22);
			freeze.Text = "Freeze";
			// 
			// toolStripMenuItem2
			// 
			connect.Name = "connect";
			connect.Size = new System.Drawing.Size(177, 22);
			connect.Text = "Connect To ...";
			//connect.Click += new System.EventHandler(surface.);

			//TODO
			/*
			 * Find a way to make clicking the "Connect To ..." option in the context menu actually do something helpful. If we're going with my plan 
			 * to have the user then click on the shape they want to connect to, then we'll need to communicate with DrawingSurface1. DrawingSurface1
			 * should remember the selected shape (the one the user right-clicked on), so we'll need to tell it that the user is now trying to connect
			 * that shape with an as-yet unknown other shape. Will need to implement the Action interface and replace the current system of boolean "moving"
			 * variable and associated actions before doing this.
			*/


			
			// 
			// boxSpecificOptionToolStripMenuItem
			// 
			boxSpecificOptionToolStripMenuItem.Name = "boxSpecificOptionToolStripMenuItem";
			boxSpecificOptionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			boxSpecificOptionToolStripMenuItem.Text = "Box Specific Option";
			// 
			// freeze
			// 
		}
		public int height { get; set; }
		public int width { get; set; }
		public Point TLCorner { get; set; } //Top Left Corner of box
		public Color color { get; set; }
		public int thickness { get; set; } //thickness of border lines
		public TextBox text;

		private DrawingSurface surface;

		public ContextMenuStrip contextMenu;

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
		}

		public ContextMenuStrip getContextMenu()
		{
			return contextMenu;
		}
	}
}
