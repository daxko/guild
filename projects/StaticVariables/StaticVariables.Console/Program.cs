using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StaticVariables.ConsoleTester
{
    class Program
    {
        const string URL = "http://localhost:58640/calc/add";
        const int THREAD_COUNT = 5;
        static readonly Random rand = new Random();
        
        // Format a+b=c
        static readonly Tuple<int, int, int>[] EXPECTED_RESULTS = new[]
        {
            new Tuple<int, int, int>(1, 1, 2),
            new Tuple<int, int, int>(2, 2, 4),
            new Tuple<int, int, int>(1, 4, 5),
            new Tuple<int, int, int>(2, 4, 6),
            new Tuple<int, int, int>(1, 6, 7),
            new Tuple<int, int, int>(2, 6, 8),
        };

        static void Main(string[] args)
        {
            for (var i = 0; i < THREAD_COUNT; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        var expected = EXPECTED_RESULTS[rand.Next(0, EXPECTED_RESULTS.Length)];
                        var result = calculate(expected.Item1, expected.Item2);
                        Console.WriteLine("{0}+{1}={2}", expected.Item1, expected.Item2, result);
                        if (result != expected.Item3)
                        {
                            Console.WriteLine("** ERROR: {0}+{1} should equal {2} but returned {3}", expected.Item1,
                                expected.Item2, expected.Item3, result);
                        }
                    }
                });
            }
            Console.ReadKey();
        }

        static int calculate(int a, int b)
        {
            var client = new WebClient();
            var output = client.DownloadString(string.Format("{0}?a={1}&b={2}", URL, a, b));
            return Convert.ToInt32(output);
        }
    }
}
