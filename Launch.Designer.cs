
namespace VIK
{
    partial class Launch
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
            this.btnActive = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxPerfiles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(12, 98);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(75, 23);
            this.btnActive.TabIndex = 0;
            this.btnActive.Text = "Active";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.Rec_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxPerfiles
            // 
            this.cbxPerfiles.FormattingEnabled = true;
            this.cbxPerfiles.Location = new System.Drawing.Point(12, 12);
            this.cbxPerfiles.Name = "cbxPerfiles";
            this.cbxPerfiles.Size = new System.Drawing.Size(260, 21);
            this.cbxPerfiles.TabIndex = 5;
            this.cbxPerfiles.SelectedIndexChanged += new System.EventHandler(this.cbxPerfiles_SelectedIndexChanged);
            // 
            // Launch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 133);
            this.Controls.Add(this.cbxPerfiles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActive);
            this.MaximumSize = new System.Drawing.Size(300, 172);
            this.Name = "Launch";
            this.Text = "VIK";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxPerfiles;
    }
}

