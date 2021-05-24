namespace Lesson07
{
    partial class GuessNumber
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtbInput = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnPlayNewWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.Location = new System.Drawing.Point(459, 56);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 47);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "Игра";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.Location = new System.Drawing.Point(459, 109);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 45);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInput.Location = new System.Drawing.Point(77, 71);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(245, 20);
            this.lblInput.TabIndex = 16;
            this.lblInput.Text = "Введите число от 1 до 100:";
            // 
            // txtbInput
            // 
            this.txtbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbInput.Location = new System.Drawing.Point(328, 66);
            this.txtbInput.Name = "txtbInput";
            this.txtbInput.Size = new System.Drawing.Size(97, 26);
            this.txtbInput.TabIndex = 17;
            // 
            // btnInput
            // 
            this.btnInput.Enabled = false;
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInput.Location = new System.Drawing.Point(328, 109);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(100, 40);
            this.btnInput.TabIndex = 18;
            this.btnInput.Text = "Ввод";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnPlayNewWindow
            // 
            this.btnPlayNewWindow.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayNewWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlayNewWindow.Location = new System.Drawing.Point(459, 160);
            this.btnPlayNewWindow.Name = "btnPlayNewWindow";
            this.btnPlayNewWindow.Size = new System.Drawing.Size(143, 47);
            this.btnPlayNewWindow.TabIndex = 19;
            this.btnPlayNewWindow.Text = "Игра в новом окне";
            this.btnPlayNewWindow.UseVisualStyleBackColor = false;
            this.btnPlayNewWindow.Click += new System.EventHandler(this.btnPlayNewWindow_Click);
            // 
            // GuessNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlayNewWindow);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtbInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPlay);
            this.Name = "GuessNumber";
            this.Size = new System.Drawing.Size(656, 258);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtbInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnPlayNewWindow;
    }
}
