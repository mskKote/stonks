using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    // Отвечает за манипуляции с компанией
    // То есть создаётся компания, 
    // а затем она хочет сделать эмиссию акций
    // А может купить другую компанию. Может обанкротиться итд
    // А в обще этот класс, от которого наследуются все компании. 
    // Хотя лучше бы сделать пару интерфейсов
    public class Company : ICompany
    {
        #region ShadowEcomonics
        private decimal shadowCapital;

        /// <summary>
        /// Отвечает за набор сотрудников на серую/тёмную ЗП, 
        /// махинации с налогами и сокрытие активов.
        /// </summary>
        /// <param name="amount">Количество грязных денег.</param>
        private void makeIllegal(decimal amount)
        {
            shadowCapital += amount;
        }

        #endregion ShadowEcomonics

        public bool IPO = false;
        public CompanyInfo CompanyInfo { get; set; }


        // Первым делом нужно прописать конструкторы всех классов.
        public Company(string name, decimal assets,
          Dictionary<Company, ulong> shareholderEntity,
          Dictionary<string, ulong> shareholderIndividual,
          CompanyInfo.Potential potential = CompanyInfo.Potential.High)
        {
            CompanyInfo = new CompanyInfo(name, potential, assets,
                                shareholderEntity, shareholderIndividual);
        }

        /// <summary>
        /// Выводит компанию на IPO
        /// </summary>
        /// <param name="percent"></param>
        public void GoIPO(double percent, ulong sharesAmount)
        {
            shadowCapital = 0;
            IPO = Exchange.MakeIPO(this, percent, sharesAmount);
        }

        public void BuyStocks(decimal capital)
        {
            if (capital > CompanyInfo.InnerCapital)
            {
                throw new Exception("No money");
            }
            var broker = Broker.ChoiceBroker();

            if (broker.BuyStock(this, capital))
            {
                if (shadowCapital - capital > 0)
                {
                    shadowCapital -= capital;
                }
                else
                {
                    CompanyInfo.InnerCapital -= (capital - shadowCapital);
                    shadowCapital = 0;
                }
            }
        }

        public override string ToString()
        {
            string res = $"Company {CompanyInfo.Name} with {CompanyInfo.InnerCapital} capitalisation";

            try
            {
                res += "\nCompany has:\n";
                foreach (var asset in Broker.CompanyStatistic(this))
                    res += $"{asset.Key.Company.Name}'s stocks. " +
                           $"Amount: {asset.Value}/{asset.Key.Company.ShareAmount}";
            }
            catch (Exception) { }

            return res;
        }
        // Перегрузка оператора + будет означать слияние.
        // Тк покупка всё равно через брокера, то проверяю на капитал, который будет проверять

        // Перегрузка += будет поглощением. Надо вызвать деструктор у компании 
    }
}