using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Latihan_1_2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = new DateTime(2016 - vScrollBar1.Value, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(2016 + vScrollBar2.Value, 12, 31);
            label1.Text = vScrollBar1.Value.ToString();
            label2.Text = vScrollBar2.Value.ToString();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = vScrollBar1.Value.ToString();
            dateTimePicker1.MinDate = new DateTime(2016 - vScrollBar1.Value, 1, 1);
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = vScrollBar2.Value.ToString();
            dateTimePicker1.MaxDate = new DateTime(2016 + vScrollBar2.Value, 12, 31);
        }

    }
}
