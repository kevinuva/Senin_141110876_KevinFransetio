using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;

namespace Latihan_5_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void form_editor_Load(object sender, EventArgs e)
        {
            //referensi Denny Ho
            Form1 frm = (Form1) MdiParent;
            Color clr = new Color();
            PropertyInfo[] colors = clr.GetType().GetProperties();
            foreach (PropertyInfo color in colors)
            {
                if (color.PropertyType == typeof(System.Drawing.Color))
                {
                    cmb_box_bg_color.Items.Add(color.Name);
                }
            }
            this.cmb_box_bg_color.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmb_box_bg_color.DrawItem += new DrawItemEventHandler(cmb_box_bg_color_DrawItem);
            this.cmb_box_bg_color.Text = frm.getBackgroundColor();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Background Color")
            {
                panel_bg_color.Show();
            }
        }

        private void cmb_box_bg_color_DrawItem(object sender, DrawItemEventArgs e)
        {
            // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);
                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.cmb_box_bg_color.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                // Draw a rectangle and fill it with the current color
                // and add the name to the right of the color
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Form1 frm = (Form1)MdiParent;
            frm.setBackgroundColor(cmb_box_bg_color.Text);
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Form1 frm = (Form1)MdiParent;
            frm.setBackgroundColor(cmb_box_bg_color.Text);
        }

    }
}
