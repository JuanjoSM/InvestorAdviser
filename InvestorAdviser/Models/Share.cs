using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvestorAdviser.Models
{
    public class Share
    {
        
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Code { get; set; }
        public decimal MarketPrice { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }

    public class DbContextShares : DbContext
    {
        public DbSet<Share> Shares { get; set; }
        public DbSet<Purchase> Purchases { get; set; }  
        
             
    }
}