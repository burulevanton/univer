using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {   public static double shag(double a, double b)
        {
            Console.WriteLine("Вторая производная от cos(x) = -cos(x)");
            Console.WriteLine("М будет максимальна при x = 3Pi/4");
            double M = -Math.Cos(b);
            Console.WriteLine("M  = {0}", M);
            Console.WriteLine("Найдём величину шага:");
            double h = Math.Sqrt(0.001 * 12 / (M * (b - a)));
            Console.WriteLine(h);
            return h;
        }
        public static double count(double a, double b, double h)
        {
            double n = (int)Math.Floor((b-a)/h);
            Console.WriteLine("Количество шагов равно: {0}", n);
            return n;
        }
        private static double metod(double a, double b, double h, double n)
        {
            double sum = 0;
            for(int i = 0; i <= n; i++)
            {
                if (i == 0 || i == n)
                {
                    sum += 0.5 * Math.Cos(a);
                }
                else
                {
                    sum += Math.Cos(a);
                }
                a += h;
            }
            return sum * h;
        }
        static void Main(string[] args)
        {
            double a = Math.PI / 4;
            double b = 3 * Math.PI / 4;
            double h = shag(a,b);
            double n = count(a, b, h);
            Console.WriteLine("Полученное значение:");
            Console.WriteLine(metod(a, b, h, n));
            Console.WriteLine("Реальное значение интеграла = 0");
            Console.ReadLine();
        }
    }
}
