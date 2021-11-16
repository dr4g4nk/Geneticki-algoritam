using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvi
{
    class Point
    {
        private double x, y, ff, z, p, q;             //x i y koordinata, ocjena kvaliteta rjesenja, vrijednost funcije u tacki (x, y), vjerovatnoca izbora, kumulativna vjerovatnoca
        private int codedX, codedY;                         //Kodovane vrijednosti x i y koordinate
        private int n, gd, gg;                              //Broj bita potreban za kodovanje, donja i gornja granica intervala
        private System.Collections.BitArray xBits, yBits;   //Bitska rekrezentacija koordinata

        public double X
        {
            get => x;
            set => x = value;
        }
        public double Y
        {
            get => y;
            set => y = value;
        }
        public int CodedX
        {
            get => codedX;
            set => codedX = value;
        }
        public int CodedY
        {
            get => codedY;
            set => codedY = value;
        }

        public double FF
        {
            get => ff;
            set => ff = value;
        }
        public double Z
        {
            get => z;
            set => z = value;
        }

        public System.Collections.BitArray XBits
        {
            get => xBits;
            set => xBits = value;
        }
        public System.Collections.BitArray YBits
        {
            get => yBits;
            set => yBits = value;
        }

        public double P
        {
            get => p;
            set => p = value;
        }

        public double Q
        {
            get => q;
            set => q = value;
        }

        public Point(int n, int gd, int gg)
        {
            this.n = n;
            this.gd = gd;
            this.gg = gg;
            XBits = new System.Collections.BitArray(n, false);
            YBits = new System.Collections.BitArray(n, false);
        }

        public Point(int n, int gd, int gg, double x, double y) : this(n, gd, gg)
        {
            X = x;
            Y = y;
            Z = Func();
            CodedX = (int)Code(x);
            CodedY = (int)Code(y);
            ToBits(CodedX, XBits);
            ToBits(CodedY, YBits);
        }

        public Point(Point point) : this(point.n, point.gd, point.gg, point.x, point.y)
        {
            P = point.P;
            Q = point.Q;
            FF = point.FF;
        }

        public Double Code(double d) //Kodovanja
        {
            return Math.Floor((d - gd) / (gg - gd) * (Math.Pow(2, n) - 1));
        }

        public Double Decode(double i) //Dekodovanje
        {
            return gd + (gg - gd) / (Math.Pow(2, n) - 1) * i;
        }

        public void Mutation() //Mutacija
        {
            Random random = new Random();
            int index = random.Next(XBits.Length + YBits.Length);
            if (index >= YBits.Length) 
                XBits.Set(index - YBits.Length, !XBits.Get(index - YBits.Length));
            else
                YBits.Set(index, !YBits.Get(index));
            Update();
        }

        private void Update()
        {
            CodedY = ToInt(YBits);
            Y = Decode(CodedY);
            CodedX = ToInt(XBits);
            X = Decode(CodedX);
            Z = Func();
        }

        public void Crossover(Point point) //Rekombinacija
        {
            if (point != null)
            {
                Random rand = new Random();
                int index = rand.Next(2 * XBits.Length);
                bool tmp;

                for (int i = 0; i <= index; i++)
                {
                    if (i < YBits.Length)
                    {
                        tmp = YBits[i];
                        YBits[i] = point.YBits[i];
                        point.YBits[i] = tmp;
                    }
                    else
                    {
                        tmp = XBits[i - XBits.Length];
                        XBits[i - XBits.Length] = point.XBits[i - XBits.Length];
                        point.XBits[i - XBits.Length] = tmp;
                    }
                }
                Update();
                point.Update();
            }
        }

        public static void ToBits(int num, System.Collections.BitArray arr) //Konverzija cijelog broja u bitsku reprezentaciju
        {
            int i = 0, tmp;
            while (num > 0)
            {
                tmp = num % 2;
                arr.Set(i++, tmp == 0 ? false : true);
                num /= 2;
            }
        }

        public static int ToInt(System.Collections.BitArray arr) //Konverzija bita u cijeli broj
        {
            double tmp = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr.Get(i))
                    tmp += Math.Pow(2, i);
            }
            return (int)tmp;
        }

        private double Func() //Funkcija ciji se minimum i maksimum traze
        {
            return (3 * Math.Pow(1 - x, 2) * Math.Pow(Math.E, -(Math.Pow(x, 2) + Math.Pow(y + 1, 2))))
                - (10 * (x / 5 - Math.Pow(x, 3) - Math.Pow(y, 5)) * Math.Pow(Math.E, -(Math.Pow(x, 2) + Math.Pow(y, 2))))
                - (1 / 3 * Math.Pow(Math.E, -(Math.Pow(x + 1, 2) + Math.Pow(y, 2))));
        }
    }
}
