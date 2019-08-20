using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class ConnectionLine : Line
	{

		public ConnectionLine(Point a, Point b, ref DrawingSurface d)
			: base(a, b, ref d)
		{

		}

		public ConnectionLine(Point a, Point b, ref DrawingSurface d, ref Box shapeA, ref Box shapeB)
			: base(a, b, ref d, ref shapeA, ref shapeB)
		{

		}

		public override bool HitTest(Point p)
		{
			return false;
		}
	}
}
