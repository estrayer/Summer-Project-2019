using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public class DrawingSurface : Control
	{

		public List<Item> Shapes { get; private set; }
		//Shapes could be organized to minimize search times. For example: top to bottom. So when searching, if the top-left corner of shape being tested is 
		//below the cursor position, we know that the cursor didn't touch anything.
		public Item selectedShape;
		public bool takingAction { get; private set; }
		public Action action;
		Point previousPoint = Point.Empty;
		public ContextMenuStrip contextMenu;

		public DrawingSurface()
		{
			DoubleBuffered = true;
			Shapes = new List<Item>();
			takingAction = false;
			action = null;
			contextMenu = new ContextMenuStrip();
			this.ContextMenuStrip = null;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{

			for (var i = Shapes.Count - 1; i >= 0; i--)
			{
				if (Shapes[i].HitTest(e.Location))
				{
					selectedShape = Shapes[i];
					break;
				}
			}

			if (selectedShape != null)
			{
				if (e.Button == MouseButtons.Left)
				{
					//Moving

					takingAction = true;
					action = new Moving();

					action.mouseDown(this, e);
					
				}
				else if (e.Button == MouseButtons.Right)
				{
					this.ContextMenuStrip = selectedShape.getContextMenu();
					return;
				}
			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(takingAction)
			{
				takingAction = action.mouseMove(this, e);
			}

			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if(takingAction)
				{
					takingAction = action.mouseUp(this, e);
				}

				base.OnMouseUp(e);
			}
			else if (e.Button == MouseButtons.Right)
			{
				base.OnMouseUp(e);
				this.ContextMenuStrip = null;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			foreach (var shape in Shapes)
			{
				shape.Draw(e.Graphics);
			}

			base.OnPaint(e);
		}
	}
}
