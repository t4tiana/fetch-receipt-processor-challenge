using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace receipt_processor.Models
{
    public class Receipt
    {

        private string points;
        public string Retailer { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime PurchaseTime { get; set; }

        public Dictionary<string, string>[] Items { get; set; }

        public string Total { get; set; }

        public string Id { get; set; }

        public string Points
        {
            get
            {
                return points; //don't I need a setter to set points after method calculates it?
            }
        }

        public Receipt()
        {
            
        }

        
    }
}
