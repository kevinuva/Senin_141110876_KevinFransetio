using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace volleyball_problem_own_work_score_19._23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnHitung_Click(object sender, EventArgs e)
        {
            long a, b, c, modulus = 1000000007, hasilA = 1, hasilB = 1, faktorial, temp;
            a = Convert.ToInt64(Txt1.Text);
            b = Convert.ToInt64(Txt2.Text);
            if (a < 24 && b == 25)
            {
                temp = a;
                a += (b - 1);
                b = temp;
                c = Math.Abs(a - b);

                for (long i = (c + 1); i <= a; i++)
                {
                    hasilA *= i;
                }

                for (int i = 1; i <= b; i++)
                {
                    hasilB *= i;
                }

                faktorial = hasilA / hasilB;
                TxtHasil.Text = faktorial.ToString();
            }
            else if (a == 25 && b < 24)
            {
                a += (b - 1);
                c = Math.Abs(a - b);

                for (long i = (c + 1); i <= a; i++)
                {
                    hasilA *= i;
                }

                for (int i = 1; i <= b; i++)
                {
                    hasilB *= i;
                }

                faktorial = hasilA / hasilB;
                TxtHasil.Text = faktorial.ToString();
            }
            else
            {
                TxtHasil.Text = "0";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Gak sempat buat pak. Masih berusaha untuk mengerjakan.
        }
    }
}


    