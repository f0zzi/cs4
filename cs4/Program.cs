using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task1 ============================");
            Vector v1 = new Vector(1, 2);
            Vector v2 = new Vector(2, 0);
            Console.WriteLine("ToString v1:\t" + v1);
            Console.WriteLine("ToString v2:\t" + v2);
            Console.WriteLine("Length v1:\t" + v1.Length);
            Console.WriteLine("Length v2:\t" + v2.Length);
            Console.WriteLine("v1 + v2:\t" + (v1 + v2));
            Console.WriteLine("v1 - v2:\t" + (v1 - v2));
            Console.WriteLine("v1 * 5.5:\t" + (v1 * 5.5));
            Console.WriteLine("5.5 * v1:\t" + (5.5 * v1));
            Console.WriteLine("v1 * v2:\t" + (v1 * v2));
            Console.WriteLine("v1 == v2:\t" + (v1 == v2));
            Console.WriteLine("v1 != v2:\t" + (v1 != v2));
            Console.WriteLine("(double)v1:\t" + ((double)v1));
            Console.WriteLine("(Vector)5.5:\t" + ((Vector)5.5));
            Console.WriteLine("++v1:\t" + (++v1));
            Console.WriteLine("--v1:\t" + (--v1));
            Console.WriteLine("-v1:\t" + (-v1));
            Console.WriteLine("v1:\t" + (v1 ? "True" : "False"));
            Console.WriteLine("v2:\t" + (v2 ? "True" : "False"));
            Console.WriteLine("ToString v1:\t" + v1);
            Console.WriteLine("v1[0]:\t" + v1[0]);
            Console.WriteLine("v1[1]:\t" + v1[1]);
            Console.WriteLine("v1 += v2:\t" + (v1 += v2));
            Console.WriteLine("v1 -= v2:\t" + (v1 -= v2));
            Console.WriteLine("v1 *= v2:\t" + (v1 *= v2));

            Console.WriteLine();
            Console.WriteLine("Task2 ============================");
            Student student = new Student("Ivan", "Ivanov", "Ivanovich");
            student.Group = "223KD";
            student.SetAdm(1, 2, 3, 4, 5);
            student.SetProg(1, 2, 3, 4, 5);
            student.SetDes(1, 2, 3, 4, 5);
            student[(int)Subject.Programming, 2] = 12;
            student["programming", 0] = 11;
            student.Info();
            Console.WriteLine($"Averag: {student.Average()}");

            Console.WriteLine();
            Console.WriteLine("Task3 ============================");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Task4 ============================");
            List<Article> art = new List<Article>(new Article[]{
                new Article(1, "art1", 1.1),
                new Article(2, "art2", 2.2),
                new Article(3, "art3", 3.3),
                new Article(4, "art4", 4.4),
                new Article(5, "art5", 5.5),
                new Article(6, "art6", 6.6),
                new Article(7, "art7", 7.7), });
            Client cl1 = new Client("client1");
            Request req1 = new Request(ref cl1);
            Console.WriteLine(cl1);
            req1.Add(new RequestItem(art[1], 2));
            Console.WriteLine(cl1);
            req1.Add(new RequestItem(art[2], 1));
            req1.Add(new RequestItem(art[0], 3));
            req1.Add(new RequestItem(art[5], 1));
            Console.WriteLine(cl1);
            req1.Remove(0);
            Console.WriteLine("0 orderlist item removed");
            Console.WriteLine(req1);
            Console.WriteLine(cl1);

            Console.WriteLine();
            Client cl2 = new Client("client2");
            Request req2 = new Request(ref cl2);
            Console.WriteLine(req2);
            Console.WriteLine(cl2);
            req2.Add(new RequestItem(art[2], 1));
            req2.Add(new RequestItem(art[0], 3));
            req2.Add(new RequestItem(art[0], 3));
            req2.Add(new RequestItem(art[5], 1));
            Console.WriteLine(req2);
            Console.WriteLine(cl2);
        }
    }
}
