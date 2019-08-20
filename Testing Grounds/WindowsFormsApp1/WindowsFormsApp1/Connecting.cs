using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	class Connecting : Action
	{
		private Box firstBox;

		public bool mouseDown(DrawingSurface d, MouseEventArgs e)
		{
			//The user has just chosen the second shape they want to connect to.
			bool success = d.selectedShape.handleConnection(firstBox);

			if (success)
			{
				d.Invalidate();
			}

			return !success;
		}

		public bool mouseMove(DrawingSurface d, MouseEventArgs e)
		{
			//throw new NotImplementedException();
			return true;
		}

		public bool mouseUp(DrawingSurface d, MouseEventArgs e)
		{
			//throw new NotImplementedException();

			return true;
		}

		public void startConnection(DrawingSurface d, Box box)
			//this is called when the user right-clicks on a shape and clicks the "Connect To..." option from the context menu
		{
			firstBox = box;
		}
	}
}