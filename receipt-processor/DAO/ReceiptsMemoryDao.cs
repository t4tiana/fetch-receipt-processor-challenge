using receipt_processor.Models;
using System;

namespace receipt_processor.DAO
{
    public class ReceiptsMemoryDao : IReceiptsDao
    {

        //GetReceiptById


        public Receipt CreateReceipt(Receipt receipt)
        {
            receipt.Id = Guid.NewGuid().ToString();

            return receipt;
        }

        //public Receipt ProcessReceipts(Receipt receipt)
        //{
        //    Receipt newReceipt = new Receipt();

        //    return newReceipt;
        //}

        public string GetPoints(Receipt receipt)
        {
            string points = "0";

            return points;
        }






    }
}
