using System;
using System.Collections.Generic;

namespace Stonks
{
    public class CompanyInfo
    {
        public CompanyInfo(string name, decimal assets,
          Dictionary<Company, ulong> shareholderEntity = null,
          Dictionary<string, ulong> shareholderIndividual = null)
        {
            Name = name;
            Foundation = DateTime.Now;
            Assets = assets;
            InnerCapital = assets;
            ShareholderEntity = shareholderEntity;
            ShareholderIndividual = shareholderIndividual;
        }
        public string Name { get; private set; }
        // Держатели акций.
        public Dictionary<Company, ulong> ShareholderEntity;
        public Dictionary<string, ulong> ShareholderIndividual;

        public ulong ShareAmount { get; set; }
        public decimal Value { get; set; }
        public decimal InnerCapital { get; set; }
        public decimal Assets { get; set; }


        // Абстрактный потенциал
        public enum Potential
        {
            Decay = -1,
            Hold = 0,
            Low = 1,
            High = 2
        }
        public Potential RaisePotential { get; private set; }
        public string INN { get; private set; }
        public DateTime Foundation { get; private set; }
        public bool License { get; set; } = true;
    }
}
