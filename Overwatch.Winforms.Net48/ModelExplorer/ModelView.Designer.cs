namespace Overwatch.Winforms.Net48.ModelExplorer
{
    partial class ModelView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblAddProject = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSepOpen = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddProject
            // 
            this.lblAddProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddProject.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAddProject.Location = new System.Drawing.Point(0, 0);
            this.lblAddProject.Name = "lblAddProject";
            this.lblAddProject.Size = new System.Drawing.Size(100, 23);
            this.lblAddProject.TabIndex = 0;
            this.lblAddProject.Text = "« Double click here to add new project »";
            this.lblAddProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddProject.DoubleClick += new System.EventHandler(this.lblAddProject_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuOpen,
            this.mnuSepOpen,
            this.mnuSaveAll,
            this.mnuCloseAll,
            this.mnuOpenFile});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 120);
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.Size = new System.Drawing.Size(180, 22);
            this.mnuNewProject.Text = "mnuNewProject";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(180, 22);
            this.mnuOpen.Text = "mnuOpen";
            // 
            // mnuSepOpen
            // 
            this.mnuSepOpen.Name = "mnuSepOpen";
            this.mnuSepOpen.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuSaveAll
            // 
            this.mnuSaveAll.Name = "mnuSaveAll";
            this.mnuSaveAll.Size = new System.Drawing.Size(180, 22);
            this.mnuSaveAll.Text = "toolStripMenuItem1";
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(180, 22);
            this.mnuCloseAll.Text = "mnuSaveAll";
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.Size = new System.Drawing.Size(180, 22);
            this.mnuOpenFile.Text = "toolStripMenuItem1";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ModelView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAddProject;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator mnuSepOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAll;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
    }
}
