namespace Lesson07
{
    partial class formMain
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
            this.guessNumber1 = new Lesson07.GuessNumber();
            this.SuspendLayout();
            // 
            // counterControl1
            // 
            this.counterControl1.Counter = 0;
            this.counterControl1.ResNumber = 0;
            this.counterControl1.Location = new System.Drawing.Point(12, 9);
            this.counterControl1.Name = "counterControl1";
            this.counterControl1.Play = false;
            this.counterControl1.Size = new System.Drawing.Size(657, 208);
            this.counterControl1.TabIndex = 0;
            // 
            // guessNumber1
            // 
            this.guessNumber1.Location = new System.Drawing.Point(12, 206);
            this.guessNumber1.Name = "guessNumber1";
            this.guessNumber1.Size = new System.Drawing.Size(656, 227);
            this.guessNumber1.TabIndex = 0;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 461);
            this.Controls.Add(this.guessNumber1);
            this.Controls.Add(this.counterControl1);
            this.Name = "formMain";
            this.Text = "Удвоитель + Угадай число";
            this.ResumeLayout(false);

        }

        #endregion

        private CounterControl counterControl1;
        private GuessNumber guessNumber1;
    }
}

