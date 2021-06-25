
namespace KmMusicPlayer.Forms
{
    partial class LrcForm
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
            this.lrcPanl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lrcPanl
            // 
            this.lrcPanl.BackColor = System.Drawing.Color.Black;
            this.lrcPanl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrcPanl.Location = new System.Drawing.Point(0, 0);
            this.lrcPanl.Name = "lrcPanl";
            this.lrcPanl.Size = new System.Drawing.Size(582, 398);
            this.lrcPanl.TabIndex = 0;
            // 
            // LrcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 398);
            this.Controls.Add(this.lrcPanl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LrcForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "歌词";
            this.Load += new System.EventHandler(this.LrcForm_Load);
            this.SizeChanged += new System.EventHandler(this.LrcForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lrcPanl;
    }
}