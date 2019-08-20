namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.DiagramsDropDownBox = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.arrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insert_Line = new System.Windows.Forms.ToolStripMenuItem();
			this.insert_Rectangle = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.UMLDropDownBox = new System.Windows.Forms.ToolStripDropDownButton();
			this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relationshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.boxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.freezeBox = new System.Windows.Forms.ToolStripMenuItem();
			this.connect = new System.Windows.Forms.ToolStripMenuItem();
			this.boxSpecificOption = new System.Windows.Forms.ToolStripMenuItem();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.drawingSurface1 = new WindowsFormsApp1.DrawingSurface();
			this.lineContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.freezeLine = new System.Windows.Forms.ToolStripMenuItem();
			this.lineSpecificOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			this.boxContextMenu.SuspendLayout();
			this.lineContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.DiagramsDropDownBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.UMLDropDownBox,
            this.toolStripSeparator2,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1429, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
			this.toolStripLabel1.Text = "Diagrams";
			this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
			// 
			// DiagramsDropDownBox
			// 
			this.DiagramsDropDownBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DiagramsDropDownBox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.arrayToolStripMenuItem,
            this.insert_Line,
            this.insert_Rectangle});
			this.DiagramsDropDownBox.Image = ((System.Drawing.Image)(resources.GetObject("DiagramsDropDownBox.Image")));
			this.DiagramsDropDownBox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DiagramsDropDownBox.Name = "DiagramsDropDownBox";
			this.DiagramsDropDownBox.Size = new System.Drawing.Size(49, 22);
			this.DiagramsDropDownBox.Text = "Insert";
			this.DiagramsDropDownBox.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
			this.toolStripTextBox1.Text = "Tree";
			// 
			// arrayToolStripMenuItem
			// 
			this.arrayToolStripMenuItem.Name = "arrayToolStripMenuItem";
			this.arrayToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.arrayToolStripMenuItem.Text = "Array";
			this.arrayToolStripMenuItem.Click += new System.EventHandler(this.arrayToolStripMenuItem_Click);
			// 
			// insert_Line
			// 
			this.insert_Line.Name = "insert_Line";
			this.insert_Line.Size = new System.Drawing.Size(160, 22);
			this.insert_Line.Text = "Line";
			this.insert_Line.Click += new System.EventHandler(this.insert_Line_Click);
			// 
			// insert_Rectangle
			// 
			this.insert_Rectangle.Name = "insert_Rectangle";
			this.insert_Rectangle.Size = new System.Drawing.Size(160, 22);
			this.insert_Rectangle.Text = "Rectangle";
			this.insert_Rectangle.Click += new System.EventHandler(this.insert_Rectangle_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(32, 22);
			this.toolStripLabel2.Text = "UML";
			// 
			// UMLDropDownBox
			// 
			this.UMLDropDownBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.UMLDropDownBox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classToolStripMenuItem,
            this.relationshipToolStripMenuItem});
			this.UMLDropDownBox.Image = ((System.Drawing.Image)(resources.GetObject("UMLDropDownBox.Image")));
			this.UMLDropDownBox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.UMLDropDownBox.Name = "UMLDropDownBox";
			this.UMLDropDownBox.Size = new System.Drawing.Size(164, 22);
			this.UMLDropDownBox.Text = "toolStripDropDownButton1";
			// 
			// classToolStripMenuItem
			// 
			this.classToolStripMenuItem.Name = "classToolStripMenuItem";
			this.classToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.classToolStripMenuItem.Text = "Class";
			// 
			// relationshipToolStripMenuItem
			// 
			this.relationshipToolStripMenuItem.Name = "relationshipToolStripMenuItem";
			this.relationshipToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.relationshipToolStripMenuItem.Text = "Relationship";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(35, 22);
			this.toolStripButton1.Text = "Save";
			// 
			// boxContextMenu
			// 
			this.boxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeBox,
            this.connect,
            this.boxSpecificOption});
			this.boxContextMenu.Name = "boxContextMenu";
			this.boxContextMenu.Size = new System.Drawing.Size(178, 70);
			// 
			// freezeBox
			// 
			this.freezeBox.Name = "freezeBox";
			this.freezeBox.Size = new System.Drawing.Size(177, 22);
			this.freezeBox.Text = "Freeze";
			// 
			// connect
			// 
			this.connect.Name = "connect";
			this.connect.Size = new System.Drawing.Size(177, 22);
			this.connect.Text = "Connect To ...";
			this.connect.Click += new System.EventHandler(this.connectTo);
			// 
			// boxSpecificOption
			// 
			this.boxSpecificOption.Name = "boxSpecificOption";
			this.boxSpecificOption.Size = new System.Drawing.Size(177, 22);
			this.boxSpecificOption.Text = "Box Specific Option";
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.hScrollBar1.Location = new System.Drawing.Point(0, 452);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(1429, 21);
			this.hScrollBar1.TabIndex = 3;
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar1.Location = new System.Drawing.Point(1412, 25);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 427);
			this.vScrollBar1.TabIndex = 4;
			// 
			// drawingSurface1
			// 
			this.drawingSurface1.BackColor = System.Drawing.SystemColors.HotTrack;
			this.drawingSurface1.ContextMenuStrip = this.boxContextMenu;
			this.drawingSurface1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawingSurface1.Location = new System.Drawing.Point(0, 25);
			this.drawingSurface1.Name = "drawingSurface1";
			this.drawingSurface1.Size = new System.Drawing.Size(1412, 427);
			this.drawingSurface1.TabIndex = 2;
			this.drawingSurface1.takingAction = false;
			this.drawingSurface1.Text = "drawingSurface1";
			this.drawingSurface1.Click += new System.EventHandler(this.drawingSurface1_Click);
			// 
			// lineContextMenu
			// 
			this.lineContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeLine,
            this.lineSpecificOptionToolStripMenuItem});
			this.lineContextMenu.Name = "lineContextMenu";
			this.lineContextMenu.Size = new System.Drawing.Size(181, 48);
			// 
			// freezeLine
			// 
			this.freezeLine.Name = "freezeLine";
			this.freezeLine.Size = new System.Drawing.Size(180, 22);
			this.freezeLine.Text = "Freeze";
			// 
			// lineSpecificOptionToolStripMenuItem
			// 
			this.lineSpecificOptionToolStripMenuItem.Name = "lineSpecificOptionToolStripMenuItem";
			this.lineSpecificOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.lineSpecificOptionToolStripMenuItem.Text = "Line Specific Option";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1429, 473);
			this.Controls.Add(this.drawingSurface1);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.boxContextMenu.ResumeLayout(false);
			this.lineContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton DiagramsDropDownBox;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem arrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insert_Line;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton UMLDropDownBox;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relationshipToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem insert_Rectangle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.ComponentModel.BackgroundWorker backgroundWorker2;
		private DrawingSurface drawingSurface1;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private System.Windows.Forms.ContextMenuStrip boxContextMenu;
		private System.Windows.Forms.ToolStripMenuItem freezeBox;
		private System.Windows.Forms.ToolStripMenuItem connect;
		private System.Windows.Forms.ToolStripMenuItem boxSpecificOption;
		private System.Windows.Forms.ContextMenuStrip lineContextMenu;
		private System.Windows.Forms.ToolStripMenuItem freezeLine;
		private System.Windows.Forms.ToolStripMenuItem lineSpecificOptionToolStripMenuItem;
	}
}

