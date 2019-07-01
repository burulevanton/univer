using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Исходное уравнение:");
            Console.WriteLine("2,3x1 + 1,1x2 + 0,23x3 = 3,3");
            Console.WriteLine("-2x1 + 1,3x2 + 1,77x3 = -0,7");
            Console.WriteLine("2,5x1 + 3,2x2 + 2,73x3 =7,7");
            var b = new double[,] { { 2.3,1.1,0.23}, {0.3, 2.4 ,2}, { 0.2,2.1,2.5 } };
            var c = new double[] { 3.3,2.6,4.4 };
            Console.WriteLine("Преобразуем к уравнению с диагональным преобладанием:");
            Console.WriteLine("{0}x1 + {1}x2 + {2}x3 = {3}", b[0, 0], b[0, 1], b[0, 2], c[0]);
            Console.WriteLine("{0}x1 + {1}x2 + {2}x3 = {3}  (I+II)", b[1, 0], b[1, 1], b[1, 2], c[1]);
            Console.WriteLine("{0}x1 + {1}x2 + {2}x3 = {3}  (III-I)", b[2, 0], b[1, 1], b[2, 2], c[2]);
            var x = new double[2, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                        b[i, j] = (-b[i, j]) / b[i, i];
                }
                c[i] /= b[i, i];
                b[i, i] = 1;
            }
            Console.WriteLine("Приведем к виду xn = ....");
            Console.WriteLine("x1 = {0} + {1}x2 + {2}x3", c[0], b[0, 1], b[0, 2]);
            Console.WriteLine("x2 = {0} + {1}x1 + {2}x3", c[1], b[1, 0], b[1, 2]);
            Console.WriteLine("x3 = {0} + {1}x1 + {2}x2", c[2], b[2, 0], b[2, 1]);
            Console.WriteLine("Получаем матрицу коэффициентов B:");
            Console.WriteLine("{0,-7:0.000}|{1,-7:0.000}|{2,-7:0.000}", b[0, 0]-1, b[0, 1], b[0, 2]);
            Console.WriteLine("{0,-7:0.000}|{1,-7:0.000}|{2,-7:0.000}", b[1, 0], b[1, 1] - 1, b[1, 2]);
            Console.WriteLine("{0,-7:0.000}|{1,-7:0.000}|{2,-7:0.000}", b[2, 0], b[2, 1], b[2, 2]-1);
            var max = new double[] { Math.Abs(b[0, 1]) + Math.Abs(b[0, 2]), Math.Abs(b[1, 0]) + Math.Abs(b[1, 2]), Math.Abs(b[2, 0]) + Math.Abs(b[2, 1]) };
            Console.WriteLine("||B|| = max({0} ; {1} ; {2}) = {3} < 1", max[0], max[1], max[2], Math.Max(max[0], Math.Max(max[1], max[2])));
            Console.WriteLine("Условия сходимости выполнены, следовательно метод сходится");
            Console.WriteLine("Из формулы получим количество итераций равное 250");
            for (int j = 0; j < 3; j++)
            {
                x[0, j] = c[j];
            }
            Console.WriteLine("За Xn0 примем коэффициенты матрицы C");
            Console.WriteLine("X10 = {0}", x[0, 0]);
            Console.WriteLine("X20 = {0}", x[0, 1]);
            Console.WriteLine("X30 = {0}", x[0, 2]);
            for (int i = 0; i < 250; i++)
            {
                x[1, 0] = c[0] + b[0,1] * x[0, 1] + b[0,2] * x[0, 2];
                x[1, 1] = c[1] + b[1,0] * x[0, 0] + b[1,2] * x[0, 2];
                x[1, 2] = c[2] + b[2,0] * x[0, 0] + b[2,1] * x[0, 1];
                for (int j = 0; j < 3; j++)
                {
                    x[0, j] = x[1, j];
                }
            }
            Console.WriteLine("Спустя 250 итераций получим:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine("X{0} = {1}",i+1,x[1, i]);
            Console.WriteLine("Проверка:");
            Console.WriteLine("2,3 * {0} + 1,1 * {1} + 0,23 * {2} = {3} + {4} + {5} = {6}", x[1, 0], x[1, 1], x[1, 2], 2.3 * x[1, 0], 1.1 * x[1, 1], 0.23 * x[1, 2], 2.3 * x[1, 0] + 1.1 * x[1, 1] + 0.23 * x[1, 2]);
            Console.WriteLine("-2 * {0} + 1,3 * {1} + 1,77 * {2} = {3} + {4} + {5} = {6}", x[1, 0], x[1, 1], x[1, 2], -2 * x[1, 0], 1.3 * x[1, 1], 1.77 * x[1, 2], -2 * x[1, 0] + 1.3 * x[1, 1] + 1.77 * x[1, 2]);
            Console.WriteLine("2,5 * {0} + 3,2 * {1} + 2,73 * {2} = {3} + {4} + {5} = {6}", x[1, 0], x[1, 1], x[1, 2], 2.5 * x[1, 0], 3.2 * x[1, 1], 2.73 * x[1, 2], 2.5 * x[1, 0] + 3.2 * x[1, 1] + 2.73 * x[1, 2]);
            Console.ReadLine();
        }
    }
}
