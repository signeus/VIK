
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbPalabrasReconocidas = new System.Windows.Forms.ListBox();
            this.txbVolume = new System.Windows.Forms.TextBox();
            this.txbRate = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rec";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Rec_Click);
            // 
            // lbPalabrasReconocidas
            // 
            this.lbPalabrasReconocidas.FormattingEnabled = true;
            this.lbPalabrasReconocidas.Location = new System.Drawing.Point(12, 12);
            this.lbPalabrasReconocidas.Name = "lbPalabrasReconocidas";
            this.lbPalabrasReconocidas.Size = new System.Drawing.Size(260, 173);
            this.lbPalabrasReconocidas.TabIndex = 1;
            // 
            // txbVolume
            // 
            this.txbVolume.Location = new System.Drawing.Point(12, 200);
            this.txbVolume.Name = "txbVolume";
            this.txbVolume.Size = new System.Drawing.Size(100, 20);
            this.txbVolume.TabIndex = 2;
            // 
            // txbRate
            // 
            this.txbRate.Location = new System.Drawing.Point(172, 200);
            this.txbRate.Name = "txbRate";
            this.txbRate.Size = new System.Drawing.Size(100, 20);
            this.txbRate.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Launch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txbRate);
            this.Controls.Add(this.txbVolume);
            this.Controls.Add(this.lbPalabrasReconocidas);
            this.Controls.Add(this.button1);
            this.Name = "Launch";
            this.Text = "VIK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbPalabrasReconocidas;
        private System.Windows.Forms.TextBox txbVolume;
        private System.Windows.Forms.TextBox txbRate;
        private System.Windows.Forms.Button button2;
    }
}

