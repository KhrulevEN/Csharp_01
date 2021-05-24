
namespace Lesson07
{
    partial class formInput
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
            this.btnInput = new System.Windows.Forms.Button();
            this.txtbInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInput.Location = new System.Drawing.Point(275, 65);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(100, 40);
            this.btnInput.TabIndex = 19;
            this.btnInput.Text = "Ввод";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtbInput
            // 
            this.txtbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbInput.Location = new System.Drawing.Point(278, 33);
            this.txtbInput.Name = "txtbInput";
            this.txtbInput.Size = new System.Drawing.Size(97, 26);
            this.txtbInput.TabIndex = 20;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInput.Location = new System.Drawing.Point(27, 33);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(245, 20);
            this.lblInput.TabIndex = 21;
            this.lblInput.Text = "Введите число от 1 до 100:";
            // 
            // formInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 143);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtbInput);
            this.Controls.Add(this.btnInput);
            this.Name = "formInput";
            this.Text = "Ввод числа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtbInput;
        private System.Windows.Forms.Label lblInput;
    }
}