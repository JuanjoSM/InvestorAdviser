using InvestorAdviser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestorAdviser.ViewModels
{
    public class ShareViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public decimal MarketPrice { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public decimal TotalShares { get; set; }
    }
}