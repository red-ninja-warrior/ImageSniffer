namespace Sniffer.Viewer
{
    partial class HL7Viewer
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
            this.btnParse = new System.Windows.Forms.Button();
            this.txtHl7Input = new System.Windows.Forms.TextBox();
            this.dgHl7Results = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgHl7Results)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(944, 17);
            this.btnParse.Margin = new System.Windows.Forms.Padding(2);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(44, 23);
            this.btnParse.TabIndex = 6;
            this.btnParse.Text = "&Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtHl7Input
            // 
            this.txtHl7Input.Location = new System.Drawing.Point(16, 17);
            this.txtHl7Input.Margin = new System.Windows.Forms.Padding(2);
            this.txtHl7Input.Multiline = true;
            this.txtHl7Input.Name = "txtHl7Input";
            this.txtHl7Input.Size = new System.Drawing.Size(924, 182);
            this.txtHl7Input.TabIndex = 5;
            // 
            // dgHl7Results
            // 
            this.dgHl7Results.DataMember = "";
            this.dgHl7Results.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgHl7Results.Location = new System.Drawing.Point(16, 205);
            this.dgHl7Results.Name = "dgHl7Results";
            this.dgHl7Results.Size = new System.Drawing.Size(924, 479);
            this.dgHl7Results.TabIndex = 7;
            // 
            // HL7Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 696);
            this.Controls.Add(this.dgHl7Results);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtHl7Input);
            this.Name = "HL7Viewer";
            this.Text = "HealthLevelSevenViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgHl7Results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtHl7Input;
        private System.Windows.Forms.DataGrid dgHl7Results;
    }
}