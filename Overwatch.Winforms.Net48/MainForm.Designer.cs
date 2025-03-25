namespace Overwatch.Winforms.Net48
{
    partial class MainForm
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.windowClient = new System.Windows.Forms.SplitContainer();
            this.tabbedWindow = new Overwatch.Winforms.Net48.TabbedWindow();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowClient)).BeginInit();
            this.windowClient.Panel1.SuspendLayout();
            this.windowClient.Panel2.SuspendLayout();
            this.windowClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.windowClient);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(800, 401);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(800, 450);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenu);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Location = new System.Drawing.Point(3, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(111, 25);
            this.mainToolStrip.TabIndex = 1;
            // 
            // windowClient
            // 
            this.windowClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowClient.Location = new System.Drawing.Point(0, 0);
            this.windowClient.Name = "windowClient";
            // 
            // windowClient.Panel1
            // 
            this.windowClient.Panel1.Controls.Add(this.tabbedWindow);
            // 
            // windowClient.Panel2
            // 
            this.windowClient.Panel2.Controls.Add(this.splitContainer);
            this.windowClient.Size = new System.Drawing.Size(800, 401);
            this.windowClient.SplitterDistance = 645;
            this.windowClient.TabIndex = 0;
            // 
            // tabbedWindow
            // 
            this.tabbedWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabbedWindow.DocumentManager = null;
            this.tabbedWindow.Location = new System.Drawing.Point(0, 0);
            this.tabbedWindow.Name = "tabbedWindow";
            this.tabbedWindow.Size = new System.Drawing.Size(645, 401);
            this.tabbedWindow.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.splitContainer_Panel1
            // 
            this.splitContainer.Panel1.Text = "Panel1";
            // 
            // splitContainer.splitContainer_Panel2
            // 
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(151, 401);
            this.splitContainer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.windowClient.Panel1.ResumeLayout(false);
            this.windowClient.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowClient)).EndInit();
            this.windowClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.SplitContainer windowClient;
        private TabbedWindow tabbedWindow;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
    }
}

