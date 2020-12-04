using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path ="indata.txt";

            var lines = File.ReadLines(path, Encoding.UTF8).Select(x => Convert.ToDecimal(x)).ToList();

            foreach(decimal i in lines)
            {
                foreach(decimal j in lines)
                {
                    if (i + j == 2020) {
                        Console.WriteLine($"{i} + {j} = 2020");
                        Console.WriteLine($"value och i * j = {i * j}");
                    }
                    foreach(decimal k in lines)
                    {
                        if (i + j + k == 2020) {
                            Console.WriteLine($"{i} + {j} + {k} = 2020");
                            Console.WriteLine($"value och i * j * k = {i * j * k}");
                        }
                    }
                }
            }
        }
    }
}
