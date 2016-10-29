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

namespace Latihan_4_1
{
    public partial class Form1 : Form
    {
        public bool isSave = true;
        public string saveFileDirectory = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //referensi Denny Ho
            Color clr = new Color();
            PropertyInfo[] colors = clr.GetType().GetProperties();
            for (int i = 8; i <= 72; i++)
            {
                toolStripComboBox1.Items.Add(i);
            }

            InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
            foreach (FontFamily font in fontFamilies)
            {
                toolStripComboBox2.Items.Add(font.Name);
            }

            this.toolStripComboBox4.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.toolStripComboBox3.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo color in colors)
            {
                if (color.PropertyType == typeof(System.Drawing.Color))
                {
                    toolStripComboBox4.Items.Add(color.Name);
                    toolStripComboBox3.Items.Add(color.Name);
                }
            }

            //inisiasi
            toolStripComboBox1.SelectedIndex = 3;
            toolStripComboBox2.Text = "Calibri";
            toolStripComboBox3.Text = "Black";
            toolStripComboBox4.Text = "White";
            changeText();
            //event
            this.toolStripComboBox4.ComboBox.DrawItem += new DrawItemEventHandler(toolStripComboBox3_DrawItem);
            this.toolStripComboBox3.ComboBox.DrawItem += new DrawItemEventHandler(toolStripComboBox3_DrawItem);
        }

        private void toolStripComboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.toolStripComboBox4.Items[e.Index].ToString();
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

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            if (richTextBox1.SelectionFont != null)
            {
                toolStripComboBox2.Text = richTextBox1.SelectionFont.FontFamily.Name;
                toolStripComboBox1.Text = richTextBox1.SelectionFont.Size.ToString();
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold") >= 0)
                {
                    toolStripButton1.Checked = true;
                }
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") >= 0)
                {
                    toolStripButton2.Checked = true;
                }
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") >= 0)
                {
                    toolStripButton3.Checked = true;
                }
            }
            else
            {
                toolStripComboBox2.Text = "";
                toolStripComboBox1.Text = "";
            }

            if (richTextBox1.SelectionColor.Name == "0")
            {
                toolStripComboBox3.Text = "Black";
            }
            else
            {
                toolStripComboBox3.Text = richTextBox1.SelectionColor.Name;
            }

            toolStripComboBox4.Text = richTextBox1.BackColor.Name;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int length = richTextBox1.SelectionLength;
            int start = richTextBox1.SelectionStart;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            richTextBox1.SelectionColor = Color.FromName(toolStripComboBox3.Text);
            richTextBox1.Select(start, length);
        }
        private void toolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int length = richTextBox1.SelectionLength;
            int start = richTextBox1.SelectionStart;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            richTextBox1.SelectionBackColor = Color.FromName(toolStripComboBox4.Text);
            richTextBox1.Select(start, length);
        }
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void toolStripComboBox1_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void toolStripComboBox3_LostFocus(object sender, EventArgs e)
        {
            int length = richTextBox1.SelectionLength;
            int start = richTextBox1.SelectionStart;
            richTextBox1.SelectionColor = Color.FromName(toolStripComboBox3.Text);
            richTextBox1.Select(start, length);
        }
        private void toolStripComboBox4_LostFocus(object sender, EventArgs e)
        {
            int length = richTextBox1.SelectionLength;
            int start = richTextBox1.SelectionStart;
            richTextBox1.SelectionBackColor = Color.FromName(toolStripComboBox4.Text);
            richTextBox1.Select(start, length);
        }
        private void toolStripComboBox2_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked ^= true;
            changeText(sender);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2.Checked ^= true;
            changeText(sender);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton3.Checked ^= true;
            changeText(sender);
        }

        private void saveFile()
        {
            DialogResult dr;
            if (saveFileDirectory == "")
            {
                saveFileDialog1.Filter = "Text File | *.txt";
                dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                    saveFileDirectory = saveFileDialog1.FileName;
                    this.Text = "Form1 - " + saveFileDialog1.FileName;
                }
            }
            else
            {
                dr = MessageBox.Show("File ini telah pernah disimpan. Apakah anda ingin menimpanya?", "Simpan File", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    richTextBox1.SaveFile(saveFileDirectory);
                }
            }
            isSave = true;
        }
        private void changeText(object sender = null)
        {
            bool isBold, isItalic, isUnderline;
            int length = richTextBox1.SelectionLength;
            int start = richTextBox1.SelectionStart;
            float fontSize;
            string fontFamily;
            System.Drawing.FontStyle currentStyle;
            this.richTextBox1.SelectionChanged -= new System.EventHandler(this.richTextBox1_SelectionChanged);
            if (length == 0)
            {
                fontFamily = (toolStripComboBox2.Text == "") ? richTextBox1.SelectionFont.FontFamily.Name : toolStripComboBox2.Text;
                fontSize = (toolStripComboBox1.Text == "") ? richTextBox1.SelectionFont.Size : Convert.ToSingle(toolStripComboBox1.Text);

                isBold = richTextBox1.SelectionFont.Bold;
                isItalic = richTextBox1.SelectionFont.Italic;
                isUnderline = richTextBox1.SelectionFont.Underline;

                if (sender != null && sender.ToString() == "toolStripButton1")
                {
                    isBold = toolStripButton1.Checked;
                }
                else if (sender != null && sender.ToString() == "toolStripButton2")
                {
                    isItalic = toolStripButton2.Checked;
                }
                else if (sender != null && sender.ToString() == "toolStripButton3")
                {
                    isUnderline = toolStripButton3.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                richTextBox1.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }
            for (int i = start; i < start + length; i++)
            {
                richTextBox1.SelectionChanged -= new System.EventHandler(this.richTextBox1_SelectionChanged);
                richTextBox1.Select(i, 1);
                fontFamily = (toolStripComboBox2.Text == "") ? richTextBox1.SelectionFont.FontFamily.Name : toolStripComboBox2.Text;
                fontSize = (toolStripComboBox1.Text == "") ? richTextBox1.SelectionFont.Size : Convert.ToSingle(toolStripComboBox1.Text);

                isBold = richTextBox1.SelectionFont.Bold;
                isItalic = richTextBox1.SelectionFont.Italic;
                isUnderline = richTextBox1.SelectionFont.Underline;

                if (sender != null && sender.ToString() == "toolStripButton1")
                {
                    isBold = toolStripButton1.Checked;
                }
                else if (sender != null && sender.ToString() == "toolStripButton2")
                {
                    isItalic = toolStripButton2.Checked;
                }
                else if (sender != null && sender.ToString() == "toolStripButton3")
                {
                    isUnderline = toolStripButton3.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                richTextBox1.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }

            richTextBox1.Focus();
            richTextBox1.Select(start, length);

            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (!isSave)
            {
                dr = MessageBox.Show("Apakah Anda ingin menyimpan file terlebih dahulu?", "Simpan file", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    saveFile();
                }
            }
            dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
                saveFileDirectory = openFileDialog1.FileName;
                this.Text = "Form1 - " + openFileDialog1.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isSave = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (!isSave)
            {
                dr = MessageBox.Show("Apakah Anda ingin menyimpan file terlebih dahulu?", "Simpan file", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    saveFile();
                }
            }
            isSave = true;
            saveFileDirectory = "";
            this.Text = "Form1";
            richTextBox1.Rtf = "";
        }
    }
}
