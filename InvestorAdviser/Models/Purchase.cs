using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestorAdviser.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int NumberOfShares { get; set; }
        public decimal PurchasePrice { get; set; }
        public int ShareID { get; set; }
        public Share Share { get; set; }

    }
}