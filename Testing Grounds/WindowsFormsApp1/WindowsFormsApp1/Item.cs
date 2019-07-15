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
	public interface Item
	{
		GraphicsPath getPath();
		bool HitTest(Point p);
		void Draw(Graphics g);
		void Move(Point p);
		ContextMenuStrip getContextMenu();
	}
}
