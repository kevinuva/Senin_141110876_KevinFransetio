namespace Latihan_3_1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tsbItalic = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.tscbFontFamily = new System.Windows.Forms.ToolStripComboBox();
            this.tscbFontColor = new System.Windows.Forms.ToolStripComboBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbFontSize,
            this.tsbBold,
            this.tsbItalic,
            this.tsbUnderline,
            this.tscbFontFamily,
            this.tscbFontColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(413, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbFontSize
            // 
            this.tscbFontSize.Name = "tscbFontSize";
            this.tscbFontSize.Size = new System.Drawing.Size(75, 27);
            this.tscbFontSize.SelectedIndexChanged += new System.EventHandler(this.tscbFontSize_SelectedIndexChanged);
            this.tscbFontSize.LostFocus += new System.EventHandler(this.tscbFontSize_LostFocus);
            // 
            // tsbBold
            // 
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = ((System.Drawing.Image)(resources.GetObject("tsbBold.Image")));
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(23, 22);
            this.tsbBold.Text = "tsbBold";
            this.tsbBold.Click += new System.EventHandler(this.tsbBold_Click);
            // 
            // tsbItalic
            // 
            this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsbItalic.Image")));
            this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItalic.Name = "tsbItalic";
            this.tsbItalic.Size = new System.Drawing.Size(23, 24);
            this.tsbItalic.Text = "tsbItalic";
            this.tsbItalic.Click += new System.EventHandler(this.tsbItalic_Click);
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnderline.Image")));
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 24);
            this.tsbUnderline.Text = "tsbUnderline";
            this.tsbUnderline.Click += new System.EventHandler(this.tsbUnderline_Click);
            // 
            // tscbFontFamily
            // 
            this.tscbFontFamily.Name = "tscbFontFamily";
            this.tscbFontFamily.Size = new System.Drawing.Size(125, 27);
            this.tscbFontFamily.SelectedIndexChanged += new System.EventHandler(this.tscbFontFamily_SelectedIndexChanged);
            this.tscbFontFamily.LostFocus += new System.EventHandler(this.tscbFontFamily_LostFocus);
            // 
            // tscbFontColor
            // 
            this.tscbFontColor.Name = "tscbFontColor";
            this.tscbFontColor.Size = new System.Drawing.Size(125, 23);
            this.tscbFontColor.SelectedIndexChanged += new System.EventHandler(this.tscbFontColor_SelectedIndexChanged);
            this.tscbFontColor.LostFocus += new System.EventHandler(this.tscbFontColor_LostFocus);
            // 
            // rtbNote
            // 
            this.rtbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNote.Location = new System.Drawing.Point(0, 25);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(413, 367);
            this.rtbNote.TabIndex = 1;
            this.rtbNote.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 392);
            this.Controls.Add(this.rtbNote);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbFontSize;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private System.Windows.Forms.ToolStripButton tsbItalic;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripComboBox tscbFontFamily;
        private System.Windows.Forms.ToolStripComboBox tscbFontColor;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.RichTextBox rtbNote;
    }
}

