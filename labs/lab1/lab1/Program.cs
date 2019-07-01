using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        const int n = 4;
        static double[,] matrix = new double[n - 1, n];
        static double[,] checkmatrix = new double[n - 1, n];
        static double[] answers = new double[n - 1];
        private static void inputTreat()
        {
            string[] input;
            string userInput;
            for (int i = 0; i < n - 1; i++)
            {
                userInput = Console.ReadLine();
                input = userInput.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToDouble(input[j]);
                    checkmatrix[i, j] = Convert.ToDouble(input[j]);
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                string output = "";
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                        output += Convert.ToString(matrix[i, j]) + "x" + Convert.ToString(j + 1) + " ";
                    else output += " = " + Convert.ToString(matrix[i, j]);
                }
                Console.WriteLine(output);
            }
        }
        private static void del(int i, double help)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] /= help;
            }
        }
        private static void minus(double temp, int i, int j)
        {
            for (int t = 0; t < n; t++)
            {
                matrix[j, t] -= temp * matrix[i, t];
            }
        }
        private static void showMatrix()
        {
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < n - 1; i++)
            {
                string output = "";
                for (int j = 0; j < n; j++)
                {       
                        output += "| " + Convert.ToString(matrix[i,j]) + "|";
                }
                Console.WriteLine(output);
            }
        }
        private static void answer()
        {
            answers[2] = matrix[2, 3];
            answers[1] = matrix[1, 3] - matrix[1, 2] * answers[2];
            answers[0] = matrix[0, 3] - matrix[0, 2] * answers[2] - matrix[0, 1] * answers[1];
            Console.WriteLine("Ответ:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("x{0} = {1}",i+1,answers[i]);
            }
        }
        private static void check()
        {
            Console.WriteLine("Проверка:");
            for (int i = 0; i < n - 1; i++)
            {
                string output = null;
                output += Convert.ToString(checkmatrix[i, 0]) + " * " + Convert.ToString(answers[0]);
                output += " + " + Convert.ToString(checkmatrix[i, 1]) + " * " + Convert.ToString(answers[1]);
                output += " + " + Convert.ToString(checkmatrix[i, 2]) + " * " + Convert.ToString(answers[2]);
                output += " = " + Convert.ToString(checkmatrix[i, 0] * answers[0]);
                output += " + " + Convert.ToString(checkmatrix[i, 1] * answers[1]);
                output += " + " + Convert.ToString(checkmatrix[i, 2] * answers[2]);
                output += " = " + Convert.ToString(checkmatrix[i, 3]);
                Console.WriteLine(output);
            }
        }
        private static void metod()
        {
            for (int i = 0; i < n - 1; i++)
            {
                int k = i;
                for (int j = i + 1; j < n - 1; j++)
                {
                    if (Math.Abs(matrix[k, i]) < Math.Abs(matrix[j, i]))
                        k = j;
                }
                if (k != i)
                {
                    for (int c = 0; c < n; c++)
                    {
                        double temp = matrix[i, c];
                        matrix[i, c] = matrix[k, c];
                        matrix[k, c] = temp;
                    }
                }
                double help = matrix[i, i];
                del(i, help);
                for (int t = i + 1; t < n - 1; t++)
                {
                    minus(matrix[t, i], i, t);
                }
                showMatrix();
            }
        }
        static void Main(string[] args)
        {
            inputTreat();
            metod();
            answer();
            check();
            Console.ReadLine();
        }
    }
}
