using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    // Нужен для работы биржи.
    public interface ICompany
    {
        CompanyInfo CompanyInfo { get; set; }

    }
}
