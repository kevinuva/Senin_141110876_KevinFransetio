using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime waktu = new DateTime(2016, 1, 1);
            for (DateTime i = waktu; i.Year < 2017; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    monthCalendar1.AddBoldedDate(i);
                    monthCalendar1.UpdateBoldedDates();
                }
            }
            numericUpDown1.Maximum = DateTime.DaysInMonth(2016, (int)numericUpDown2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime waktu = new DateTime(2016, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            monthCalendar1.AddAnnuallyBoldedDate(waktu);
            monthCalendar1.UpdateBoldedDates();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = DateTime.DaysInMonth(2016, (int)numericUpDown2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime hapus = new DateTime(2016, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            if (hapus.DayOfWeek.ToString() != "Saturday" && hapus.DayOfWeek.ToString() != "Sunday" && numericUpDown1.Value != 22 && numericUpDown2.Value != 12)
            {
                monthCalendar1.RemoveAnnuallyBoldedDate(hapus);
            }
            monthCalendar1.UpdateBoldedDates();
            for (DateTime i = monthCalendar1.SelectionRange.Start; i <= monthCalendar1.SelectionRange.End; i = i.AddDays(1))
            {
                if (i.DayOfWeek.ToString() != "Saturday" && i.DayOfWeek.ToString() != "Sunday" && i.Day != 22 && i.Month != 12) 
                {
                     monthCalendar1.RemoveAnnuallyBoldedDate(i);
                }
            }
            monthCalendar1.UpdateBoldedDates();
        }
    }
}
