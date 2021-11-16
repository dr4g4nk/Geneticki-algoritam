using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mvi
{
    class GenAlg
    {
        private int n, gd, gg; //Potreban broj bita za kodovanje, donja granica, gornja granica
        private int size, iterations;//Velicina populacije, broj iteracija
        private double probCo, probMut;//Vjerovatnoca rekombinacije, vjerovatnoca mutacije
        private double min, max;
        delegate double FitnessFunction(double fx);
        private FitnessFunction ff;
        private List<Point> population;//Populacija
        private Random rand;
        private bool findMin;//Da li ce se racunati minimum ili maksimum
        private Point result;

        public GenAlg(int prec, int gd, int gg, int size, double probCo, double probMut, int iterations, bool findMin)
        {
            rand = new Random();
            n = (int)(Math.Log((gg - gd) * Math.Pow(10, prec) + 1, 2) + 1); //Racunanje broja bita za kodovanje
            this.gd = gd;
            this.gg = gg;
            this.size = size;
            this.probCo = probCo;
            this.probMut = probMut;
            this.iterations = iterations;
            this.findMin = findMin;
            population = new List<Point>();

            if (findMin)
                ff = new FitnessFunction(FFMin);
            else
                ff = new FitnessFunction(FFMax);
        }

        string s;

        public Point Start(System.Windows.Forms.ProgressBar progressBar, System.Windows.Forms.TextBox textBox, out TimeSpan timeSpan)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            for (long i = 0; i < size; ++i)
            {
                Point point = new Point(n, gd, gg, Map((double)rand.NextDouble()), Map((double)rand.NextDouble()));
                s += String.Format("{0,-10} {1,-30} ({2,-8:N5}, {3,-8:N5}) {1,-30} ({4,-8:D8}, {5,-8:D8}) {1,-30} {6,-30:N5} {7,-30:N5} {8, -30:N5} {9,-30:N5}" + System.Environment.NewLine, i + 1, "", point.X, point.Y, point.CodedX, point.CodedY, point.Z, point.FF, point.P, point.Q); //Formatiranje ispisa
                population.Add(point);
            }
            progressBar.Invoke(new Action(() =>
            {
                progressBar.Value = 0;
                progressBar.Maximum = iterations;
            }));

            textBox.Invoke(new Action(() =>
            {
                textBox.AppendText("Pocetna populacija:" + System.Environment.NewLine);
                textBox.AppendText(String.Format("{0,-10} {1,-40} ({2}, {3}) {1,-40} ({4,-8}, {5,-8}) {1,-30} {6,-37} {7,-35} {8, -35} {9,-30}" + System.Environment.NewLine, "BR.", "", "x", "y", "Kodovano x", "Kodovano y", "z(x,y)", "ff", "p", "q"));//Formatiranje ispisa
                textBox.AppendText(s);
            }));

            bool stop = false, firstTime = true;
            int num = 1;
            for (long i = 0; !stop && i < iterations; ++i)
            {
                progressBar.Invoke(new Action(() => progressBar.Value++));

                Calculate();

                List<Point> nextGeneration = new List<Point>();
                double maxFF = population.Max(point => point.FF);
                nextGeneration.Add(population.Find(point => point.FF == maxFF)); //Vrsi li se elitisticka selekcija 

                if (firstTime)
                    firstTime = false;
                else
                {
                    s = System.Environment.NewLine + System.Environment.NewLine + String.Format("Populacija u iteraciji: {0}", i + 1) + System.Environment.NewLine;
                    num = 1;
                    population.ForEach(point =>
                     s += String.Format("{0,-10} {1,-30} ({2,-8:N5}, {3,-8:N5}) {1,-30} ({4,-8:D8}, {5,-8:D8}) {1,-30} {6,-30:N5} {7,-30:N5} {8, -30:N5} {9,-30:N5}" + System.Environment.NewLine, num++, "", point.X, point.Y, point.CodedX, point.CodedY, point.Z, point.FF, point.P, point.Q)//Formatiranje ispisa
                    );
                    textBox.Invoke(new Action(() =>
                    {
                        textBox.AppendText(s);      //Ispis
                    }));
                }

                double r;
                for (int j = 0; j < size - 1; ++j)             //Ruletska selekcija
                {
                    r = rand.NextDouble();
                    bool flag = true;
                    int index = 0;
                    while (flag && index < population.Count)
                    {
                        if (r < population[index].Q)
                        {
                            nextGeneration.Add(population[index]);
                            flag = false;
                        }
                        index++;
                    }
                }

                int pairs = nextGeneration.Count / 2 + rand.Next(nextGeneration.Count); //Broj mijesanja
                int index1, index2;
                for (int j = 0; j < pairs; ++j)          //Formiranje parova za moguce ukrstanje
                {
                    index1 = rand.Next(nextGeneration.Count);
                    index2 = rand.Next(nextGeneration.Count);

                    Point tmp = new Point(nextGeneration[index1]);
                    nextGeneration[index1] = nextGeneration[index2];
                    nextGeneration[index2] = tmp;
                }

                for (int j = 0; j + 1 < nextGeneration.Count; j++) //Rekombinacija(ukrstanje)
                {
                    if (rand.NextDouble() < probCo)
                        nextGeneration[j].Crossover(nextGeneration[j + 1]);
                }

                nextGeneration.ForEach(point =>             //Da li ce se vrsiti mutacija
                {
                    if (rand.NextDouble() < probMut)
                        point.Mutation();
                });

                population = nextGeneration;
                Point p = population[0];
                if (population.FindAll(point => point.X == p.X && point.Y == p.Y).Count == population.Count) //Provjera da li su sve tacke u populaciji iste, ako jesu prekida se izvrsavanje
                    stop = true;
            }
            
            Calculate();
            num = 1;
            s = System.Environment.NewLine + System.Environment.NewLine + "Poslednja generacija:" + System.Environment.NewLine;

            population.ForEach(point =>
                s += String.Format("{0,-10} {1,-30} ({2,-8:N5}, {3,-8:N5}) {1,-30} ({4,-8:D8}, {5,-8:D8}) {1,-30} {6,-30:N5} {7,-30:N5} {8, -30:N5} {9,-30:N5}" + System.Environment.NewLine, num++, "", point.X, point.Y, point.CodedX, point.CodedY, point.Z, point.FF, point.P, point.Q)//Formatiranje ispisa
            );

            textBox.Invoke(new Action(() =>
            {
                textBox.AppendText(s);
            }));
            
            double ff = population.Max(point => point.FF);
            result = population.Find(point => point.FF == ff);

            progressBar.Invoke(new Action(() =>
            {
                progressBar.Value = progressBar.Maximum;
            }));

            stopwatch.Stop();
            timeSpan = stopwatch.Elapsed;

            return result;
        }

        private void Calculate()
        {
            if (findMin)
                max = population.Max(point => point.Z);
            else
                min = population.Min(point => point.Z);

            population.ForEach(point => point.FF = ff(point.Z)); //Racunanje fitnes funkcije za svaku jedinku
            double F = population.Sum(point => point.FF);       //Ocijena cijele populacije
            population.ForEach(point => point.P = point.FF / F);//Racunanje vjerovatnoce izbora jedinke

            if (population.Any(point => point.FF != 0))
            {
                int index = population.FindIndex(point => point.P == 0);
                if (index != 0)
                {
                    Point tmp = population[index];
                    population[index] = population[0];
                    population[0] = tmp;
                }
                population.Find(point => point.P == 0).Q = 0;
                for (int j = 1; j < population.Count; ++j)      //Racunanje kumulativne vjerovatnoce za svaku jedinku
                    population[j].Q = population[j].P + population[j - 1].Q;

                population.Sort((point1, point2) =>
                {    //Sortiranje po kumulativnoj vjerovatnoci(priprema za ruletsku selekciju)
                    if (point1.Q > point2.Q)
                        return 1;
                    else if (point1.Q < point2.Q)
                        return -1;
                    return 0;
                });
            }
            else
                population.ForEach(point => point.Q = point.P = 0);
        }

        private double Map(double d) //Mapiranje slucajnog broja sa intervala [0,1] na interval [-3,3]
        {
            return (gg - gd) * d + gd;
        }

        private double FFMin(double fx) //Fitnes funkcija za trazenje minimuma
        {
            return max - fx;
        }

        private double FFMax(double fx) //Fitnes funkcija za trazenje maksimuma
        {
            return fx - min;
        }
    }
}