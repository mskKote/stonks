using System;
using System.Linq;
using System.Collections.Generic;

namespace Stonks
{
    // Также компания.
    // Единственный, кто может взаимодействовать с биржей. 
    // Добавляет к операциям наценку.
    // Отвечает за прогнозы.
    public class Broker : Company
    {
        public static readonly List<Broker> Brokers = new List<Broker>() { };
        public static Broker ChoiceBroker()
        {
            // Надо перенести это в класс брокера.
            Console.WriteLine("It's time to check broker list.");
            int buff = 1, choice;
            Brokers.ForEach(broker =>
            Console.WriteLine($"{buff}] {broker.CompanyInfo.Name} " +
                              $"with markup {broker.BrokersFeePercent:f2}%. " +
                              $"License: {broker.CompanyInfo.License}"));
            do
            {
                Console.WriteLine("Make choice:");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice < 1 || choice > Brokers.Count);
            return Brokers[choice - 1];
        }
        public Broker(string name, decimal assets,
            Dictionary<Company, ulong> shareholderEntity,
            Dictionary<string, ulong> shareholderIndividual,
            double brokersFeePercent,
            CompanyInfo.Potential potential = CompanyInfo.Potential.Hold
          ) : base(name, assets,
                                shareholderEntity, shareholderIndividual)
        {
            BrokersFeePercent = brokersFeePercent;
        }
        public double BrokersFeePercent { get; set; }
        public bool BuyStock(ICompany client, decimal capital)
        {
            if (!CompanyInfo.License)
            {
                throw new Exception("Bad decision. The broker doen't have a license");
            }
            Console.WriteLine("Welcome, customer. Let's see, what we could acquire");
            int i = 1;
            foreach (var company in Exchange.MarginStoks.Keys)
            {
                Console.WriteLine($"{i}] {company.CompanyInfo.Name} with value: {company.CompanyInfo.Value}\n" +
                $"Stocks: {company.CompanyInfo.ShareAmount} with price {company.CompanyInfo.Value / company.CompanyInfo.ShareAmount}");
            }

            int choice;
            do
            {
                Console.WriteLine("Make choice or type 0 to deny:");
                int.TryParse(Console.ReadLine(), out choice);
                if (choice == 0)
                    return false;
            } while (choice < 1 || choice > Exchange.MarginStoks.Keys.Count);

            var companies = new ICompany[Exchange.MarginStoks.Keys.Count];
            Exchange.MarginStoks.Keys.CopyTo(companies, choice - 1);
            Exchange.SaleStocks(this, client, companies[0], capital);
            return true;
        }

        public static Dictionary<Stock, ulong> CompanyStatistic(ICompany client)
        {
            var companies = new ICompany[Exchange.MarginStoks.Keys.Count];
            Exchange.MarginStoks.Keys.CopyTo(companies, 0);


            return Exchange.MarginStoks.ElementAt(companies.ToList().IndexOf(client)).Value;
            //return Exchange.MarginStoks.ContainsKey(client) ?
            //       Exchange.MarginStoks.Values.ElementAt(Exchange.MarginStoks.Keys.) :
            //       new List<Stock>();
        }
    }
}
