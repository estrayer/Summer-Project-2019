using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public interface Action
		/*
		 * This is an abstraction of the different "actions" that the user can be doing. At time of writing, the only action that this is meant to
		 * encompass is moving shapes around the drawing surface. I have plans to add connecting one shape to another. These are ongoing actions which the
		 * drawing surface needs to be aware of, because wheter the user is moving a shape or not changes what happens when the user moves the mouse, or releases
		 * the left mouse button. These sorts of actions will be represented as classes that implement the Action interface. This will allow the drawing surface to
		 * simply know that it is taking an action, and then use polymorphism to replace a series of if statements and boolean variables for the different actions
		 * it could be taking (and it can only be doing one at a time).
		*/ 
	{
		bool mouseMove(DrawingSurface d, MouseEventArgs e);
		bool mouseDown(DrawingSurface d, MouseEventArgs e);
		bool mouseUp(DrawingSurface d, MouseEventArgs e);
	}
}
