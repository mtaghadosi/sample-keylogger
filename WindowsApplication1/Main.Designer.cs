namespace key_loger
{
    partial class frm_main
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
            this.components = new System.ComponentModel.Container();
            this.tmr_load_GAKS = new System.Windows.Forms.Timer(this.components);
            this.txt_keyrecorder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_keyrecorder
            // 
            this.txt_keyrecorder.Enabled = false;
            this.txt_keyrecorder.Location = new System.Drawing.Point(7, 6);
            this.txt_keyrecorder.MaxLength = 100000000;
            this.txt_keyrecorder.Multiline = true;
            this.txt_keyrecorder.Name = "txt_keyrecorder";
            this.txt_keyrecorder.ReadOnly = true;
            this.txt_keyrecorder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_keyrecorder.ShortcutsEnabled = false;
            this.txt_keyrecorder.Size = new System.Drawing.Size(237, 112);
            this.txt_keyrecorder.TabIndex = 0;
            this.txt_keyrecorder.Text = "[";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 126);
            this.Controls.Add(this.txt_keyrecorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_load_GAKS;
        private System.Windows.Forms.TextBox txt_keyrecorder;
    }
}

