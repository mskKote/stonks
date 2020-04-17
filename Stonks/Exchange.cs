using System.Collections.Generic;

namespace Stonks
{
    static class Exchange
    {
        // Компания и её активы.
        public static Dictionary<ICompany, Dictionary<Stock, ulong>> MarginStoks =
                  new Dictionary<ICompany, Dictionary<Stock, ulong>>()
                  {

                  };

        #region StockSales
        public static void SaleStocks(Broker broker, ICompany company, ICompany buyCompany, decimal capital)
        {
            // Здесь нужно менять состояние акционеров, пересчитывать капитал и тд

        }
        #endregion StockSales
        #region IPO
        public static bool MakeIPO(ICompany company, double CapitalPercent, ulong stockAmount)
        {
            if (CheckCompany(company))
            {
                // Активов больше, чем средств в принципе!!
                // Возможно криминал, по коням!
                return false;
            }

            decimal price = company.CompanyInfo.InnerCapital * (decimal)CapitalPercent / 100 / stockAmount;
            var stocks = new List<Stock>();

            // А тут надо заплатить предыдущему владельцу и перевести акции новому.
            MarginStoks.Add(company, new Dictionary<Stock, ulong>() { [new Stock(price, company.CompanyInfo)] = stockAmount });

            return true;
        }
        private static bool CheckCompany(ICompany company)
        {
            return company.CompanyInfo.Assets > company.CompanyInfo.InnerCapital
                && company.CompanyInfo.InnerCapital > 0;
        }
        #endregion IPO
    }
}
