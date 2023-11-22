using System;
using System.Collections.Generic;

namespace DL
{
    public partial class DataTest
    {
        public string Profit { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public string Deparment { get; set; } = null!;
        public string JobOparator { get; set; } = null!;
        public DateTime JobRevRecog { get; set; }
        public decimal Revenue { get; set; }
        public int Wip { get; set; }
        public decimal Cost { get; set; }
        public int Accrual { get; set; }
        public decimal JobProfit { get; set; }
        public string Stat { get; set; } = null!;
        public string? HoldReason { get; set; }
        public string Reason { get; set; } = null!;
        public long LocalClientCode { get; set; }
        public string LocalClientName { get; set; } = null!;
        public string Rep { get; set; } = null!;
    }
}
