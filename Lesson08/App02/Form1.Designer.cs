namespace App02
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
            this.txtbNumber = new System.Windows.Forms.TextBox();
            this.numudNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbNumber
            // 
            this.txtbNumber.Location = new System.Drawing.Point(51, 40);
            this.txtbNumber.Name = "txtbNumber";
            this.txtbNumber.Size = new System.Drawing.Size(100, 20);
            this.txtbNumber.TabIndex = 0;
            // 
            // numudNumber
            // 
            this.numudNumber.Location = new System.Drawing.Point(157, 40);
            this.numudNumber.Name = "numudNumber";
            this.numudNumber.Size = new System.Drawing.Size(42, 20);
            this.numudNumber.TabIndex = 1;
            this.numudNumber.ValueChanged += new System.EventHandler(this.numudNumber_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 152);
            this.Controls.Add(this.numudNumber);
            this.Controls.Add(this.txtbNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbNumber;
        private System.Windows.Forms.NumericUpDown numudNumber;
    }
}

