
namespace Yazlab_1_2
{
    partial class Form_Main
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
            this.button_5_threadli = new System.Windows.Forms.Button();
            this.button_10_threadli = new System.Windows.Forms.Button();
            this.listBox_hamleler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_5_threadli
            // 
            this.button_5_threadli.Location = new System.Drawing.Point(1281, 12);
            this.button_5_threadli.Name = "button_5_threadli";
            this.button_5_threadli.Size = new System.Drawing.Size(91, 23);
            this.button_5_threadli.TabIndex = 0;
            this.button_5_threadli.Text = "5 Threadli Çöz";
            this.button_5_threadli.UseVisualStyleBackColor = true;
            this.button_5_threadli.Click += new System.EventHandler(this.button_5_threadli_Click);
            // 
            // button_10_threadli
            // 
            this.button_10_threadli.Location = new System.Drawing.Point(1281, 41);
            this.button_10_threadli.Name = "button_10_threadli";
            this.button_10_threadli.Size = new System.Drawing.Size(91, 23);
            this.button_10_threadli.TabIndex = 1;
            this.button_10_threadli.Text = "10 Threadli Çöz";
            this.button_10_threadli.UseVisualStyleBackColor = true;
            this.button_10_threadli.Click += new System.EventHandler(this.button_10_threadli_Click);
            // 
            // listBox_hamleler
            // 
            this.listBox_hamleler.FormattingEnabled = true;
            this.listBox_hamleler.Location = new System.Drawing.Point(802, 73);
            this.listBox_hamleler.Name = "listBox_hamleler";
            this.listBox_hamleler.Size = new System.Drawing.Size(570, 576);
            this.listBox_hamleler.TabIndex = 2;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.listBox_hamleler);
            this.Controls.Add(this.button_10_threadli);
            this.Controls.Add(this.button_5_threadli);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_5_threadli;
        private System.Windows.Forms.Button button_10_threadli;
        private System.Windows.Forms.ListBox listBox_hamleler;
    }
}

