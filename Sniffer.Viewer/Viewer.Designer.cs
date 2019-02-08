namespace Sniffer.Viewer
{
    partial class Viewer
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
            this.viewDicom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dicomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hL7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDicom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewDicom
            // 
            this.viewDicom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.viewDicom.Name = "viewDicom";
            this.viewDicom.Size = new System.Drawing.Size(181, 26);
            this.viewDicom.Text = "&Dicom";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dicomToolStripMenuItem,
            this.hL7ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dicomToolStripMenuItem
            // 
            this.dicomToolStripMenuItem.Name = "dicomToolStripMenuItem";
            this.dicomToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.dicomToolStripMenuItem.Text = "&Dicom";
            this.dicomToolStripMenuItem.Click += new System.EventHandler(this.dicomToolStripMenuItem_Click);
            // 
            // hL7ToolStripMenuItem
            // 
            this.hL7ToolStripMenuItem.Name = "hL7ToolStripMenuItem";
            this.hL7ToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.hL7ToolStripMenuItem.Text = "&HL7";
            this.hL7ToolStripMenuItem.Click += new System.EventHandler(this.hL7ToolStripMenuItem_Click);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Viewer";
            this.Text = "Viewer";
            this.viewDicom.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ContextMenuStrip viewDicom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dicomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hL7ToolStripMenuItem;
    }
}



