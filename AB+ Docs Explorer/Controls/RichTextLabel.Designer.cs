namespace AB__Docs_Explorer.Controls
{
    partial class RichTextLabel
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
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.BackColor = System.Drawing.SystemColors.Control;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(145, 39);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            this.rtbText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rtbText_MouseMove);
            this.rtbText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rtbText_MouseUp);
            // 
            // RichTextLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbText);
            this.Name = "RichTextLabel";
            this.Size = new System.Drawing.Size(145, 39);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbText;
    }
}
