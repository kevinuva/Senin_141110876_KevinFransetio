namespace Latihan_5_1
{
    partial class Form2
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Background Color");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Theme", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_bg_color = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cmb_box_bg_color = new System.Windows.Forms.ComboBox();
            this.lblBgColor = new System.Windows.Forms.Label();
            this.panel_bg_color.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "bg_color";
            treeNode3.Text = "Background Color";
            treeNode4.Name = "theme";
            treeNode4.Text = "Theme";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(140, 310);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel_bg_color
            // 
            this.panel_bg_color.BackColor = System.Drawing.SystemColors.Window;
            this.panel_bg_color.Controls.Add(this.btn_cancel);
            this.panel_bg_color.Controls.Add(this.btn_ok);
            this.panel_bg_color.Controls.Add(this.cmb_box_bg_color);
            this.panel_bg_color.Controls.Add(this.lblBgColor);
            this.panel_bg_color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bg_color.Location = new System.Drawing.Point(140, 0);
            this.panel_bg_color.Name = "panel_bg_color";
            this.panel_bg_color.Size = new System.Drawing.Size(418, 310);
            this.panel_bg_color.TabIndex = 1;
            this.panel_bg_color.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(331, 275);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(250, 275);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cmb_box_bg_color
            // 
            this.cmb_box_bg_color.FormattingEnabled = true;
            this.cmb_box_bg_color.Location = new System.Drawing.Point(196, 27);
            this.cmb_box_bg_color.Name = "cmb_box_bg_color";
            this.cmb_box_bg_color.Size = new System.Drawing.Size(121, 21);
            this.cmb_box_bg_color.TabIndex = 1;
            // 
            // lblBgColor
            // 
            this.lblBgColor.AutoSize = true;
            this.lblBgColor.Location = new System.Drawing.Point(86, 30);
            this.lblBgColor.Name = "lblBgColor";
            this.lblBgColor.Size = new System.Drawing.Size(92, 13);
            this.lblBgColor.TabIndex = 0;
            this.lblBgColor.Text = "Background Color";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 310);
            this.Controls.Add(this.panel_bg_color);
            this.Controls.Add(this.treeView1);
            this.Name = "Form2";
            this.Text = "Form_Editor";
            this.Load += new System.EventHandler(this.form_editor_Load);
            this.panel_bg_color.ResumeLayout(false);
            this.panel_bg_color.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel_bg_color;
        private System.Windows.Forms.ComboBox cmb_box_bg_color;
        private System.Windows.Forms.Label lblBgColor;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;

    }
}