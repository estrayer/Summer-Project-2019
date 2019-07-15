using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	class Moving : Action
	{
		public Point previousPoint;

		public Moving()
		{
			previousPoint = Point.Empty;
		}

		public bool mouseDown(DrawingSurface d, MouseEventArgs e)
		{
			previousPoint = e.Location;
			return true;
		}

		public bool mouseUp(DrawingSurface d, MouseEventArgs e)
		{
			d.selectedShape = null;
			return false;
		}

		public bool mouseMove(DrawingSurface d, MouseEventArgs e)
		{
			var p = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
			d.selectedShape.Move(p);
			previousPoint = e.Location;
			d.Invalidate();

			return true;
		}
	}
}
