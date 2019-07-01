using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static double J(double x, double y)
        {
            return ((6 * x * y) * (3 * x * y * y)) - ((3 * x * x + 2 * y) * (4 * x * x * x + y * y * y));
        }
        static double A(double x, double y)
        {
            return ((3 * x * x * y + y * y - 1) * (3 * x * y * y)) - ((3 * x * x + 2 * y) * (x * x * x * x + x * y * y * y - 1));
        }
        static double B(double x, double y)
        {
            return ((x * x * x * x + x * y * y * y - 1) * (6 * x * y)) - ((3 * x * x * y + y * y - 1) * (4 * x * x * x + y * y * y));
        }
        static void Main(string[] args)
        {
            double x0 = -1.3;
            double y0 = 0.4;
            double xn, yn;
            int i = 0;
            xn = x0 - A(x0, y0) / J(x0, y0);
            yn = y0 - B(x0, y0) / J(x0, y0);
            Console.WriteLine("{0} итерация = {1} {2}", i, xn, yn);
            double eps = 0.0001;
            while(Math.Abs(xn-x0)>eps || Math.Abs(yn-y0)>eps)
            {
                x0 = xn;
                y0 = yn;
                xn = x0 - A(x0, y0) / J(x0, y0);
                yn = y0 - B(x0, y0) / J(x0, y0);
                Console.WriteLine("{0} итерация = {1} {2}", ++i, xn, yn);
            }
            Console.WriteLine("Ответ:");
            Console.WriteLine("x = {0}", xn);
            Console.WriteLine("y = {0}", yn);
            Console.ReadKey();
        }
    }
}
