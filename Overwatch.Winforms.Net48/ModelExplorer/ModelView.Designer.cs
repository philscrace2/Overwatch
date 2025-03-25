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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblAddProject
            // 
            this.lblAddProject.AutoSize = true;
            this.lblAddProject.Location = new System.Drawing.Point(0, 0);
            this.lblAddProject.Name = "lblAddProject";
            this.lblAddProject.Size = new System.Drawing.Size(100, 23);
            this.lblAddProject.TabIndex = 0;
            this.lblAddProject.Text = "label1";
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAddProject;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ImageList imageList;
    }
}
