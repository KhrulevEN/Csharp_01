namespace Lesson07
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
            this.counterControl1 = new Lesson07.CounterControl();
            this.SuspendLayout();
            // 
            // counterControl1
            // 
            this.counterControl1.Counter = 0;
            this.counterControl1.EndNumber = 0;
            this.counterControl1.Location = new System.Drawing.Point(12, 12);
            this.counterControl1.Name = "counterControl1";
            this.counterControl1.Play = false;
            this.counterControl1.Size = new System.Drawing.Size(635, 156);
            this.counterControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 200);
            this.Controls.Add(this.counterControl1);
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);

        }

        #endregion

        private CounterControl counterControl1;
    }
}

