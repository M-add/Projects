namespace Evalution2._2
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
            this.calender1 = new Evalution2._2.Calender();
            this.SuspendLayout();
            // 
            // calender1
            // 
            this.calender1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.calender1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.calender1.Location = new System.Drawing.Point(199, 49);
            this.calender1.Name = "calender1";
            this.calender1.Size = new System.Drawing.Size(542, 455);
            this.calender1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 542);
            this.Controls.Add(this.calender1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Calender calender1;
    }
}

