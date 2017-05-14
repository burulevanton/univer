using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static double[][] matrixPerebor(double[][] matrix)
        {
            var tmp = new double[6][];
            double y = 0, alpha = 0, betta = 0;
            double[] c = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                var m = new double[matrix.Length + 1];
                if (i == 0)
                {
                    y = matrix[i][i];
                    alpha = -matrix[i][i + 1] / y;
                    betta = matrix[i][matrix.Length] / y;
                }
                if (i > 0 && i < matrix.Length - 1)
                {
                    y = matrix[i][i] + matrix[i][i - 1] * alpha;
                    alpha = -matrix[i][i + 1] / y;
                    betta = (matrix[i][matrix.Length] - matrix[i][i - 1] * betta) / y;
                }
                if (i == matrix.Length - 1)
                {
                    y = matrix[i][i] + matrix[i][i - 1] * alpha;
                    betta = (matrix[i][matrix.Length] - matrix[i][i - 1] * betta) / y;
                }
                m[i] = 1;
                m[i + 1] = alpha;
                m[matrix.Length] = betta;
                tmp[i] = m;
            }
            return tmp;
        }
        static double [] arrayD(double[]c, double[]h)
        {
            var d = new double[c.Length];
            for (int i = 1; i < c.Length; i++)
                d[i] = (c[i] - c[i - 1]) / h[i];
            return d;
        }
        static double[] arrayB(double[]c, double[]d,double[]f,double[]h)
        {
            var b = new double[c.Length];
            for (int i = 1; i < c.Length; i++)
                b[i] = h[i] / 2 * c[i] - Math.Pow(h[i], 2) / 6 * d[i] + (f[i] - f[i - 1]) / h[i];
            return b;
        }
        static double[] arrayC(double[][]matrix)
        {
            var tmp = matrixPerebor(matrix);
            Console.WriteLine("Применив метод перебора получим матрицу:");
            foreach (var array in tmp)
            {
                foreach (var element in array)
                    Console.Write("{0,-7:0.000} |", element);
                Console.WriteLine();
            }
            var c = new double[matrix.Length];
            var k = 0;
            for(int i = matrix.Length-1; i>=0; i--)
            {
                var x = tmp[i][matrix.Length];
                if(k>0)
                {
                    for (int j = 0; j < k; j++)
                    {
                        x += tmp[i][matrix.Length - 1 - j] * c[matrix.Length - 1 - j];
                   }
                }
                c[i] = x;
                k++;
            }
            return c;
        }
        static int getI(double[] x, double X)
        {
            for (int i = 1; i < x.Length-1; i++)
                if (x[i] > X && x[i - 1] < X)
                    return i;
            return 0;
        }
        static double FunctionValue(double[]a, double[]b, double[] c, double[] d,double[]x,double X, int index)
        {
            return a[index] + b[index] * (X - x[index]) + 1 / 2 * c[index] * Math.Pow(X - x[index], 2) + 1 / 6 * d[index] * Math.Pow(X - x[index], 3);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Имеем:");
            Console.Write("i     |");
            for (int i = 0; i < 6; i++)
                Console.Write("{0,-7} |", i);
            Console.WriteLine();
            Console.Write("x     |");
            var x = new double[] { 0.2, 0.24, 0.27, 0.30, 0.32, 0.38 };
            foreach (var xi in x)
                Console.Write("{0,-7} |", xi);
            Console.WriteLine();
            Console.Write("f(x)  |");
            var f = new double[] { 1.2214, 1.2712, 1.3100, 1.3499, 1.3771, 1.4623 };
            foreach (var fi in f)
                Console.Write("{0,-7} |", fi);
            Console.WriteLine();
            var h = new double[6];
            var X = 0.25;
            for(int i = 1; i < h.Length; i++)
            {
                h[i] = x[i] - x[i - 1];
            }
            Console.WriteLine("Найдём Ci:");
            Console.WriteLine("Для этого построим трёхдиагональную матрицу и решим её с помощью метода правого перебора");
            Console.WriteLine("Матрица:");
            var threeDiagonalMartix = new double[6][];
            threeDiagonalMartix[0] = new double[] { 2, 0.1, 0, 0, 0, 0, 2.5699 };
            threeDiagonalMartix[5] = new double[] { 0, 0, 0, 0, 0.3, 2, 3.3378 };
            for (int i = 1; i < threeDiagonalMartix.Length - 1; i++)
            {
                double[] tmp = new double[7];
                tmp[i - 1] = h[i];
                tmp[i] = 2 * (h[i + 1] + h[i]);
                tmp[i + 1] = h[i + 1];
                tmp[threeDiagonalMartix.Length] = 6 * ((f[i + 1] - f[i]) / h[i + 1] - (f[i] - f[i - 1]) / h[i]);
                threeDiagonalMartix[i] = tmp;
            }
            foreach(var array in threeDiagonalMartix)
            {
                foreach(var element in array)
                    Console.Write("{0,-7:0.000} |", element);
                Console.WriteLine();
            }
            var c = arrayC(threeDiagonalMartix);
            Console.WriteLine("Решив полученную систему уравнений получим:");
            Console.Write("Ci  |");
            foreach (var ci in c)
                Console.Write("{0,-7:0.000} |", ci);
            Console.WriteLine();
            Console.WriteLine("Найдём оставшиееся коэффициенты a,b,d");
            var a = f;
            var d = arrayD(c, h);
            var b = arrayB(c, d, f, h);
            Console.WriteLine("Получим таблицу коэффициентов сплайна:");
            Console.Write("   i    |   Ai   |   Bi   |   Ci   |   Di   |");
            Console.WriteLine();
            for(int i = 0;i<threeDiagonalMartix.Length;i++)
            {
                Console.Write("{0,-7} |", i);
                Console.Write("{0,-7:0.000} |", a[i]);
                if (i > 0)
                    Console.Write("{0,-7:0.000} |", b[i]);
                else
                    Console.Write("        |");
                Console.Write("{0,-7:0.000} |", c[i]);
                if (i > 0)
                    Console.Write("{0,-7:0.000} |", d[i]);
                else
                    Console.Write("        |");
                Console.WriteLine();
            }
            Console.WriteLine("Найдём i, такое, чтобы удовлетворяло условию:");
            Console.WriteLine("Xi-1<X<Xi");
            var index = getI(x, X);
            Console.WriteLine("Получим i = {0}", index);
            Console.WriteLine("Составим сплайн, используя наши коэффициенты и найдём значение:");
            var value = FunctionValue(a, b, c, d, x, X, index);
            Console.Write("S(x) = {0:0.0000} + {1:0.0000}*(X - Xi) + {2:0.0000}*(X-Xi)^2 + {3:0.0000}*(X-Xi)^3 = {4}", a[index], b[index], c[index] / 2, d[index] / 6, value);
            Console.WriteLine();
            Console.WriteLine("Проверка:");
            Console.WriteLine("{0} < {1} < {2} - верно", f[index - 1], value, f[index]);
            Console.ReadKey();
        }
    }
}
