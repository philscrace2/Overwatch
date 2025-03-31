namespace Overwatch.Winforms.Net48
{
    partial class TabbedWindow
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
            this.tabBar = new Overwatch.Winforms.Net48.TabBar();
            this.canvas = new Overwatch.Winforms.Net48.Canvas();
            this.SuspendLayout();
            // 
            // tabBar
            // 
            this.tabBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBar.Location = new System.Drawing.Point(0, 0);
            this.tabBar.Name = "tabBar";
            this.tabBar.Size = new System.Drawing.Size(150, 27);
            this.tabBar.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 27);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(150, 123);
            this.canvas.TabIndex = 1;
            // 
            // TabbedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.tabBar);
            this.Name = "TabbedWindow";
            this.ResumeLayout(false);

        }

        #endregion
        
        private Canvas canvas;
        private TabBar tabBar;
    }
}
