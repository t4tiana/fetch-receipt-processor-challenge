using receipt_processor.Models;

namespace receipt_processor.DAO
{
    public interface IReceiptsDao
    {
        //Receipt ProcessReceipts(Receipt receipt);

        string GetPoints(Receipt receipt);

        Receipt CreateReceipt(Receipt receipt);

    }
}
