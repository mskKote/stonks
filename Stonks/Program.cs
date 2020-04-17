using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Company("Apple Inc", 1190742820000, null, null);
            Console.WriteLine(apple);
            apple.GoIPO(10, 4443240000);
            foreach (var company in Exchange.MarginStoks[apple])
            {
                Console.WriteLine(company.Key.Company.Name + "\t" + company.Value);
            }

            Console.ReadLine();
        }
    }
}
