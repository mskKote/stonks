using System;
using System.Collections.Generic;

namespace Stonks
{
    public class CompanyInfo
    {
        public CompanyInfo(string name, Potential potential, decimal assets,
          Dictionary<Company, ulong> shareholderEntity,
          Dictionary<string, ulong> shareholderIndividual)
        {
            Name = name;
            Foundation = DateTime.Now;
            RaisePotential = potential;
            Assets = assets;
            InnerCapital = assets;
            ShareholderEntity = shareholderEntity;
            ShareholderIndividual = shareholderIndividual;
        }
        public string Name { get; private set; }
        // Держатели акций.
        public Dictionary<Company, ulong> ShareholderEntity;
        public Dictionary<string, ulong> ShareholderIndividual;

        public ulong ShareAmount { get; private set; }
        public decimal Value { get; set; }
        public decimal InnerCapital { get; set; }
        public decimal Assets { get; set; }


        // Абстрактный потенциал. Чем
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
