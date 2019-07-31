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

		//	d.selectedShape

			return false;
		}

		public bool mouseMove(DrawingSurface d, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public bool mouseUp(DrawingSurface d, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void startConnection(DrawingSurface d, Box box)
			//this is called when the user right-clicks on a shape and clicks the "Connect To..." option from the context menu
		{
			firstBox = box;
		}
	}
}

/*
 * The problem:
 *		I need to know if the selectedShape is a Box or not.
 *		
 *		The process of connection only works if the selectedShape is a box.
 *		
 *		Solutions:
 *			1.) add a function to the Item interface that could function as a screen.
 *				Boxes will continue on, while Lines will do nothing.
 *				
 *				Pros:
 *					a.) It would be quick and easy to implement.
 *				
 *				Cons:
 *					a.) It isn't good practice to have a class include a function that doesn't do anything.
 *					
 *			2.) Edit DrawingSurface so that Lines can't be selected.
 *					Do we really need to let users have unconnected lines?
 *			
 *				Pros:
 *					a.) Would solve the problem of users trying to move lines that have been connected on both sides (now lines could only be moved by moving the shapes
 *						they are attached to).
 *				
 *				Cons:
 *					a.) Less functionality
 *					
 *					b.) What if we run into a similar problem with another shape that we don't want users connecting to later down the line?
 *						This could cause future problems.
 *					
 *					c.) Would need to find a way to prevent users from selecting lines, while also allowing DrawingSurface to redraw them as/when their
 *						connected Boxes are moved around.
 *					
 *			3.) Allow Lines to be connected to other Lines
 *			
 *				Pros:
 *					a.) Theoretically the most elegant solution
 *					
 *					b.) Fully commits to Polymorphism, potentially simplifying future problems
 *					
 *				Cons:
 *					a.) It could be a lot of work.
 *					b.) Would be a can of worms
 *						EX: do we allow multiple lines to connect at one endpoint? What happens when the user tries to click on that joint and starts to drag it?
 *						Do we allow Boxes to directly connect to eachother? 
 *					c.) Why would a user want to do that?
 *					
 *	
 *	OK, I'm going for #1.
 *		Not only is it the quickest solution (at least I think so), but it will maintain the ability to select Lines, and dodges a lot questions that could add even more work.
 *		
 *		So how will I do it?
 *			
 *	
 */
