using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    // Вся аналитика с акциями
    public class Stock
    {
        public Stock(/*List<string> exchanges, decimal profitability,*/decimal price, CompanyInfo company,
            Volatility volatility = Volatility.Low, bool isDividends = false)
        {
            //Exchanges = exchanges;
            //Profitability = profitability;
            Price = price;
            Company = company;
            VolatilityRate = volatility;
            IsDividends = isDividends;
        }
        // Рассчитывается при IPO
        public decimal Profitability { get; private set; }
        public CompanyInfo Company { get; private set; }
        // Определяет, какие бодаются больше всего.
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
