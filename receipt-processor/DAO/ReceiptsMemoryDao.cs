using Microsoft.AspNetCore.Http.Features;
using receipt_processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace receipt_processor.DAO
{
    public class ReceiptsMemoryDao : IReceiptsDao
    {

        private readonly List<Receipt> listOfReceipts;

        public ReceiptsMemoryDao() : base()
        {
            if (listOfReceipts == null)
            {
                listOfReceipts = new List<Receipt>
                {
                    new Receipt() {Retailer = "Target", PurchaseDate = "2022-01-01", PurchaseTime="13:01",
                        Items = new Item[]{
                            new Item {ShortDescription = "Mountain Dew 12PK", Price = "6.49" },
                            new Item {ShortDescription = "Emils Cheese Pizza", Price = "12.25"},
                            new Item {ShortDescription = "Knorr Creamy Chicken", Price = "1.26"},
                            new Item {ShortDescription = "Doritos Nacho Cheese", Price = "3.35"},
                            new Item {ShortDescription = "   Klarbrunn 12-PK 12 FL OZ  ", Price = "12.00"}
                        },
                        Total = "35.35"},
                    new Receipt() {Retailer = "M&M Corner Market", PurchaseDate = "2022-03-20", PurchaseTime = "14:33",
                    Items = new Item[]{
                    new Item {ShortDescription = "Gatorade", Price = "2.25"},
                    new Item {ShortDescription = "Gatorade", Price = "2.25"},
                    new Item {ShortDescription = "Gatorade", Price = "2.25"},
                    new Item {ShortDescription = "Gatorade", Price = "2.25"},
                    },
                    Total = "9.00" }
                };
            }
        }



        public Receipt GetReceiptById(string id)
        {
            foreach (Receipt receipt in listOfReceipts)
            {
                if (receipt.Id == id)
                {
                    return receipt;
                }
            }
            return null;
        }

        public List<Receipt> ListReceipts()
        {
            return listOfReceipts;
        }


        public Receipt CreateReceipt(ReceiptDto dto)
        {


            return receipt;
        }

        public Receipt CalculatePoints(Receipt receipt)
        {
            //Receipt receipt = GetReceiptById(id);
            int totalPoints = 0;
            int retailerPoints = 0;
            int itemCount = receipt.Items.Count();

            //One point for every alphanumeric character in the retailer name.
            foreach (char letter in receipt.Retailer)
            {
                if (Regex.IsMatch(letter.ToString(), "^[a-zA-Z0-9]*$"))
                {
                    retailerPoints++;
                }
            }

            //50 points if the total is a round dollar amount with no cents.
            if (receipt.Total.EndsWith(".00"))
            {
                totalPoints += 50;
            }

            //25 points if the total is a multiple of 0.25.
            if (decimal.Parse(receipt.Total) % 0.25M == 0.0M)
            {
                totalPoints += 25;
            }

            //5 points for every two items on the receipt.
            int pairsOfItemsPoints = 5 * (itemCount / 2);
            totalPoints += pairsOfItemsPoints;

            //If the trimmed length of the item description is a multiple of 3,
            //multiply the price by 0.2 and round up to the nearest integer.
            //The result is the number of points earned.
            foreach (Item item in receipt.Items)
            {
                if (item.ShortDescription.Trim().Length % 3 == 0)
                {
                    int additionalPoints = (int)Math.Round(decimal.Parse(item.Price) * 0.2M);
                    totalPoints += additionalPoints;
                }
            }

            //6 points if the day in the purchase date is odd.
            int day = int.Parse(receipt.PurchaseDate.Substring(8));
            if (day % 2 == 1)
            {
                totalPoints += 6;
            }

            //10 points if the time of purchase is after 2:00pm and before 4:00pm.
            if (receipt.PurchaseTime.StartsWith("14") || receipt.PurchaseTime.StartsWith("15"))
            {
                totalPoints += 10;
            }

            totalPoints += retailerPoints;

            return receipt;
        }



    }
}
