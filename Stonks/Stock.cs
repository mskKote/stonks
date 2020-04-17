using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    public class Stock
    {
        public ulong SharesAmount { get; set; }

        public Stock(ulong sharesAmount, CompanyInfo company,
            Volatility volatility = Volatility.Low, bool isDividends = false)
        {
            SharesAmount = sharesAmount;
            Price = company.Value / sharesAmount;
            Company = company;
            VolatilityRate = volatility;
            IsDividends = isDividends;
        }
        // Рассчитывается при IPO
        public decimal Profitability { get; private set; }
        public CompanyInfo Company { get; private set; }
        // Определяет, какие акции бодаются больше всего.
        public enum Volatility
        {
            Low,
            High
        }
        public Volatility VolatilityRate { get; private set; }
        public decimal Price { get; private set; }
        public bool IsDividends { get; set; }
        //Биржи, на которых она торгуется
        public List<string> Exchanges { get; private set; }
    }
}
