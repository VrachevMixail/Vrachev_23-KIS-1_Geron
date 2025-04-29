using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Врачев_формула_Герона_через_классы_с_помощью_одном_мас
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[3];
            int i = 0;
            do
            {
                try
                {
                    Console.Write("Введите {0:} сторону: ", i+1);
                    a[i] = Convert.ToDouble(Console.ReadLine());
                    if (a[i] <= 0)
                        throw new InvalidCastException("Длина стороны не может быть меньше или равна нулю");
                    i++;
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex);
                    i = 0;
                }
            } while (i < a.Length);
            Triangle triangle = new Triangle(a, i);
            if(a.Length == 3)
                triangle.ProvTrian();
            else
                triangle.Square();
            Console.ReadKey();
        }
    }
    public class Triangle
    {
        public double[] a1;
        public int i1;
        public Triangle(double[] a, int i)
        {
            a1 = a;
            i1 = i;
        }
        public void ProvTrian()
        {
            double o = 0;
            double s = 0;
            double d = 0;
            int r = 0;
            while (r < i1)
            {
                if (o < a1[r])
                    o = a1[r];
                if (s > a1[a1.Length - 1 - r] || s == 0)
                    s = a1[r];
                if (a1[r] <= o && a1[r] >= s)
                    d = a1[r];
                r++;
            }
            Triangle triangle = new Triangle(a1, i1);
            if (o < s + d)
            {
                triangle.Square();
            }
            else
            {
                Console.WriteLine("Такого треугольника не существует");
            }
        }
        public void Square()
        {
            i1 = 0;
            double p = 0;
            while (i1 < a1.Length)
            {
               p += a1[i1];
               i1++;
            }
            i1 = 0;
            p /= 2;
            double u = p;
            while (i1 < a1.Length)
            {
               u *= p - a1[i1];
               i1++;
            }
            u = Math.Sqrt(u);
            Console.WriteLine("Площадь заданного многоугольника, найденного по формуле Герона, равна " + u);
        }
    }
}
