using receipt_processor.Models;
using System.Collections.Generic;

namespace receipt_processor.DAO
{
    public interface IReceiptsDao
    {
        Receipt CreateReceipt(ReceiptDto dto);
        List<Receipt> ListReceipts();
        Receipt GetReceiptById(string id);
        Receipt CalculatePoints(Receipt receipt);
    }
}
