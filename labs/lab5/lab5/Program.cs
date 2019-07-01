using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new double[] { 2, 2.3, 2.5, 3.0, 3.5, 3.8, 4.0 };
            var y = new double[] { 5.848, 6.127, 6.300, 6.694, 7.047, 7.243, 7.368 };
            double f1, f2, L=0;
            double X = 2.41;
            for (int i = 0; i < x.Length; i++)
            {
                f1 = 1;
                f2 = 1;
                for (int j = 0; j < x.Length; j++)
                    if (i != j)
                    {
                        f1 *= X - x[j];
                        f2 *= x[i] - x[j];
                    }
                L += y[i] * f1 / f2;
            }
            Console.WriteLine(L);
            //Console.WriteLine(-0.0052706552706656 * Math.Pow(2.41, 5) + 0.072321937322258 * Math.Pow(2.41, 4) - 0.3709871794897 * Math.Pow(2.41, 3) + 0.77626139601898 * Math.Pow(2.41, 2) + 0.42463176638057 * 2.41 + 3.87309829060041);
            Console.ReadLine();
        }
    }
}
