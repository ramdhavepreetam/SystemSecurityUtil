namespace CheckSystemSecurity
{
    partial class ProcessUtility
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
            this.cmdVarifysys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdVarifysys
            // 
            this.cmdVarifysys.Location = new System.Drawing.Point(62, 78);
            this.cmdVarifysys.Name = "cmdVarifysys";
            this.cmdVarifysys.Size = new System.Drawing.Size(166, 73);
            this.cmdVarifysys.TabIndex = 0;
            this.cmdVarifysys.Text = "button1";
            this.cmdVarifysys.UseVisualStyleBackColor = true;
            this.cmdVarifysys.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProcessUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 329);
            this.Controls.Add(this.cmdVarifysys);
            this.Name = "ProcessUtility";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdVarifysys;
    }
}

