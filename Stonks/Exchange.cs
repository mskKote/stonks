using System.Collections.Generic;

namespace Stonks
{
    static class Exchange
    {
        // Компания и её активы.
        public static Dictionary<ICompany, List<Stock>> MarginStoks =
                  new Dictionary<ICompany, List<Stock>>()
                  {
                      [new Company(new CompanyInfo("Google", 1927525m))] = new List<Stock>() { new Stock(1000000, new CompanyInfo("Google", 1927525m)) },
                      [new Company(new CompanyInfo("Facebook", 957338m))] = new List<Stock>() { new Stock(1000000, new CompanyInfo("Facebook", 957338m)) },
                      [new Company(new CompanyInfo("Sberbank", 12455m))] = new List<Stock>() { new Stock(1000000, new CompanyInfo("Sberbank", 12455m)) },
                  };

        #region StockSales
        public static void SaleStocks(Broker broker, ICompany company, ICompany buyCompany, decimal capital)
        {
            // Здесь нужно менять состояние акционеров, пересчитывать капитал и тд

            var buyAssets = new List<Stock>();

            for (int i = 0; i < MarginStoks[buyCompany].Count; i++)
            {
                var stock = MarginStoks[buyCompany][i];

                ulong sharesAmount = (ulong)(capital / stock.Price) > stock.SharesAmount ?
                        stock.SharesAmount :
                        (ulong)(capital / stock.Price);

                buyAssets.Add(new Stock(sharesAmount, stock.Company));
                MarginStoks[buyCompany][i].SharesAmount -= sharesAmount;
                // Если купили полностью, то удаляем актив из списка.
                if (MarginStoks[buyCompany][i].SharesAmount == 0)
                    MarginStoks[buyCompany].RemoveAt(i);

                capital -= sharesAmount * stock.Price;
            }

            MarginStoks[company].AddRange(buyAssets);
        }
        #endregion StockSales
        #region IPO
        public static bool MakeIPO(ICompany company, ulong stockAmount)
        {
            if (CheckCompany(company))
            {
                // Активов больше, чем средств в принципе!!
                // Возможно криминал, по коням!
                return false;
            }

            // Передаём в биржу компанию и экземпляр её акции
            MarginStoks.Add(company, new List<Stock>() { new Stock(stockAmount, company.CompanyInfo) });
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
