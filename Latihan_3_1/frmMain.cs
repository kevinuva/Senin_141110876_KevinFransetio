﻿using System;
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

namespace Latihan_3_1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color clr = new Color();
            PropertyInfo[] colors = clr.GetType().GetProperties();
            for (int i = 8; i <= 72; i++)
            {
                tscbFontSize.Items.Add(i);
            }
            
            InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
            foreach (FontFamily font in fontFamilies)
            {
                tscbFontFamily.Items.Add(font.Name);
            }

            this.tscbFontColor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo color in colors)
            {
                 if(color.PropertyType == typeof(System.Drawing.Color))
                 {
                     tscbFontColor.Items.Add(color.Name);
                 }
            }

            //inisiasi
            tscbFontSize.SelectedIndex = 3;
            tscbFontFamily.Text = "Calibri";
            tscbFontColor.Text = "Black";
            changeText();
            //event
            this.tscbFontColor.ComboBox.DrawItem += new DrawItemEventHandler(tscbFontColor_DrawItem);
        }

        private void tscbFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.tscbFontColor.Items[e.Index].ToString();
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

        private void rtbNote_SelectionChanged(object sender, EventArgs e)
        {
            tsbBold.Checked = false;
            tsbItalic.Checked = false;
            tsbUnderline.Checked = false;
            if(rtbNote.SelectionFont != null)
            {
                tscbFontFamily.Text = rtbNote.SelectionFont.FontFamily.Name;
                tscbFontSize.Text = rtbNote.SelectionFont.Size.ToString();
                if(rtbNote.SelectionFont.Style.ToString().IndexOf("Bold") >= 0)
                {
                    tsbBold.Checked = true;
                }
                if (rtbNote.SelectionFont.Style.ToString().IndexOf("Italic") >= 0)
                {
                    tsbItalic.Checked = true;
                }
                if (rtbNote.SelectionFont.Style.ToString().IndexOf("Underline") >= 0)
                {
                    tsbUnderline.Checked = true;
                }
            }
            else
            {
                tscbFontFamily.Text = "";
                tscbFontSize.Text = "";
            }
            
            if(rtbNote.SelectionColor.Name == "0")
            {
                tscbFontColor.Text = "Black";
            }
            else
            {
                tscbFontColor.Text = rtbNote.SelectionColor.Name;
            }

        }
        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void tscbFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            rtbNote.SelectionColor = Color.FromName(tscbFontColor.Text);
        }
        private void tscbFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void tscbFontSize_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void tscbFontColor_LostFocus(object sender, EventArgs e)
        {
            rtbNote.SelectionColor = Color.FromName(tscbFontColor.Text);
        }
        private void tscbFontFamily_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void tsbBold_Click(object sender, EventArgs e)
        {
            tsbBold.Checked ^= true;
            changeText(sender);
        }

        private void tsbItalic_Click(object sender, EventArgs e)
        {
            tsbItalic.Checked ^= true;
            changeText(sender);
        }

        private void tsbUnderline_Click(object sender, EventArgs e)
        {
            tsbUnderline.Checked ^= true;
            changeText(sender);
        }

        private void changeText(object sender = null)
        {
            bool isBold, isItalic, isUnderline;
            int length = rtbNote.SelectionLength;
            int start = rtbNote.SelectionStart;
            float fontSize;
            string fontFamily;
            System.Drawing.FontStyle currentStyle;
            this.rtbNote.SelectionChanged -= new System.EventHandler(this.rtbNote_SelectionChanged);
            if (length == 0)
            {
                fontFamily = (tscbFontFamily.Text == "") ? rtbNote.SelectionFont.FontFamily.Name : tscbFontFamily.Text;
                fontSize = (tscbFontSize.Text == "") ? rtbNote.SelectionFont.Size : Convert.ToSingle(tscbFontSize.Text);

                isBold = rtbNote.SelectionFont.Bold;
                isItalic = rtbNote.SelectionFont.Italic;
                isUnderline = rtbNote.SelectionFont.Underline;

                if (sender != null && sender.ToString() == "tsbBold")
                {
                    isBold = tsbBold.Checked;
                }
                else if (sender != null && sender.ToString() == "tsbItalic")
                {
                    isItalic = tsbItalic.Checked;
                }
                else if (sender != null && sender.ToString() == "tsbUnderline")
                {
                    isUnderline = tsbUnderline.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                rtbNote.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }
            for (int i = start; i < start + length; i++)
            {
                rtbNote.SelectionChanged -= new System.EventHandler(this.rtbNote_SelectionChanged);
                rtbNote.Select(i, 1);
                fontFamily = (tscbFontFamily.Text == "") ? rtbNote.SelectionFont.FontFamily.Name : tscbFontFamily.Text;
                fontSize = (tscbFontSize.Text == "") ? rtbNote.SelectionFont.Size : Convert.ToSingle(tscbFontSize.Text);

                isBold = rtbNote.SelectionFont.Bold;
                isItalic = rtbNote.SelectionFont.Italic;
                isUnderline = rtbNote.SelectionFont.Underline;
                
                if (sender != null && sender.ToString() == "tsbBold")
                {
                    isBold = tsbBold.Checked;
                }
                else if (sender != null && sender.ToString() == "tsbItalic")
                {
                    isItalic = tsbItalic.Checked;
                }
                else if (sender != null && sender.ToString() == "tsbUnderline")
                {
                    isUnderline = tsbUnderline.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                rtbNote.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }
            
            rtbNote.Focus();
            rtbNote.Select(start, length);

            this.rtbNote.SelectionChanged += new System.EventHandler(this.rtbNote_SelectionChanged);
        }
    }
}
