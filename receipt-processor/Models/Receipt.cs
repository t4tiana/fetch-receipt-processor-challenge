using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace receipt_processor.Models
{
    public class Receipt
    {
        private string id;
        private int points;
        public string Retailer { get; set; }

        public string PurchaseDate { get; set; }

        public string PurchaseTime { get; set; }

        public Item[] Items { get; set; }

        public string Total { get; set; }

        public string Id 
        {
            get
            {
                return id;
            }

        }

        public int Points
        {
            get
            {
                return points; //don't I need a setter to set points after method calculates it?
            }
        }

        public Receipt()
        {
            id = Guid.NewGuid().ToString();
        }
    }

    public class ReceiptDto
    {
        public string Retailer { get; set; }

        public string PurchaseDate { get; set; }

        public string PurchaseTime { get; set; }

        public Item[] Items { get; set; }

        public string Total { get; set; }
    }

    public class ReceiptId
    {
        string Id 
        {
            get
            {
                return this.Id;
            }
        }
    }
}
