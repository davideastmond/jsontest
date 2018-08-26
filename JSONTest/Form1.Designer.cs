namespace JSONTest
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
            this.cmdStartServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdStartServer
            // 
            this.cmdStartServer.Location = new System.Drawing.Point(471, 0);
            this.cmdStartServer.Name = "cmdStartServer";
            this.cmdStartServer.Size = new System.Drawing.Size(329, 38);
            this.cmdStartServer.TabIndex = 0;
            this.cmdStartServer.Text = "Start Server";
            this.cmdStartServer.UseVisualStyleBackColor = true;
            this.cmdStartServer.Click += new System.EventHandler(this.startserver_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdStartServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdStartServer;
    }
}

