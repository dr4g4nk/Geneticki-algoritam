using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2((int)precision.Value, -3, 3, (int)size.Value, probCo.Value, probMut.Value, (int)iterations.Value, min.Checked);
            form2.Show();
        }

        private void probCo_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = probCo.Value;
                if(value < 0 || value > 1)
                {
                    probCo.Value = 1;
                }
            }
            catch (Exception)
            {
                probCo.Value = 1;
            }
            
        }

        private void probMut_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = probMut.Value;
                if (value < 0 || value > 1)
                {
                    probMut.Value = 1;
                }
            }
            catch (Exception)
            {
                probMut.Value = 1;
            }
        }
    }   
}
