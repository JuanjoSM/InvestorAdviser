using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestorAdviser.Models
{
    public enum OperationType { purchase, sell};
    public class Purchase
    {
        public int ID { get; set; }
        public int NumberOfShares { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal OperationCost { get; set; }
        public OperationType operationType { get; set; }
        public virtual int ShareID { get; set; }
        public Share Share { get; set; }

    }
}