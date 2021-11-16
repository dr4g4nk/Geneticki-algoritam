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
    public partial class Form2 : Form
    {

        private int prec, gd, gg;
        private int size, iterations;
        private double probCo, probMut;
        private bool min;
        public Form2(int prec, int gd, int gg, int size, decimal probCo, decimal probMut, int iterations, bool findMin)
        {
            InitializeComponent();
            this.prec = prec;
            this.prec = prec;
            this.gd = gd;
            this.gg = gg;
            this.probCo = Convert.ToDouble(probCo);
            this.probMut = Convert.ToDouble(probMut);
            this.iterations = iterations;
            this.size = size;
            min = findMin;
        }

        private async void Form2_Shown(object sender, EventArgs e)
        {
            GenAlg genAlg = new GenAlg(prec, -3, 3, size, probCo, probMut, iterations, min);
            TimeSpan timeSpan = new TimeSpan();
            Point p = await Task.Run(() => genAlg.Start(progressBar, textBox1, out timeSpan));
            
            string s = String.Format("Z({0:N5}, {1:N5}) = {2:N5}", p.X, p.Y, p.Z); // Formatiranje konacnog rezultata
            textBox2.Visible = true;
            textBox2.Text = "Vrijeme izvrsavanja: " + timeSpan.ToString(); // Ispis vremena izvrsavanja
            result.Visible = true;
            result.Text = s; // Ispis koncnog rezultata
        }
    }
}
