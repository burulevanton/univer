using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static double F(double x)
        {
            return Math.Pow(x, 4) - 20 * Math.Pow(x, 3) + 101 * Math.Pow(x, 2) - 20 * x + 1;
        }
        static double df(double x)
        {
            return 4 * Math.Pow(x, 3) - 60 * Math.Pow(x, 2) + 202 * x - 20;
        }
        static double df2(double x)
        {
            return 12*Math.Pow(x,2)-120*x + 202;
        }
        static void Main(string[] args)
        {
            double a = -1;
            double b = 1;
            Console.WriteLine("Возьмём x0 = 0.11");
            double x0 = 0.09;
            Console.WriteLine("B=f\'(x0) = {0}", df(x0));
            Console.WriteLine("n = f(x0) = {0}", F(x0));
            Console.WriteLine("K = f\'\'(x0) = {0}", df2(x0));
            double h = F(x0) * df(x0) * df2(x0);
            Console.WriteLine("h = B*n*k = {0} <0.5", h);
            double ah = (1 - Math.Sqrt(1 - 2*h)) / h * F(x0);
            Console.WriteLine("a(h) = {0} < {1}", ah, x0);
            double xn = x0 - F(x0) / df(x0);
            int i = 1;
            Console.WriteLine("{0} итерация = {1}", i, xn);
            while (Math.Abs(x0-xn) > 0.0001) // пока не достигнем необходимой точности, будет продолжать вычислять
            {
                x0 = xn;
                xn = x0 - F(x0) / df(x0); // непосредственно формула Ньютона
                Console.WriteLine("{0} итерация = {1}", i, xn);
                i++;
            }
            Console.WriteLine("{0:0.00000}", F(xn));
            Console.ReadKey();
        }
    }
}
//http://mathhelpplanet.com/static.php?p=metody-resheniya-nelineynykh-uravneniy
//http://statistica.ru/branches-maths/chislennye-metody-resheniya-uravneniy/#s3b
