using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindle.IntegrationUtilities.RMB
{
    public class Balance
    {
        public BalanceType Type { get; internal set; }
        public DebitCreditMark Mark { get; internal set; }
        public DateTime? Date { get; internal set; }
        public string Currency { get; internal set; }
        public decimal? Amount { get; internal set; }
    }
}
