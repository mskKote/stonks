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
            var apple = new Company(new CompanyInfo("Apple Inc", 1190742820000, null, null));
            Console.WriteLine(apple);
            apple.GoIPO(10, 4443240000);

            Console.ReadLine();
        }
    }
}
