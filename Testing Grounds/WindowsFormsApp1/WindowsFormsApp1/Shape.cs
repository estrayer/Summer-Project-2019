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
	abstract class Shape : Item
	{
		public abstract void Draw(Graphics g);

		public abstract ContextMenuStrip GetContextMenu();

		public abstract GraphicsPath getPath();

		public abstract bool HitTest(Point p);

		public abstract void Move(Point p);

		public abstract bool handleConnection(Box b);
	}
}
