using Microsoft.AspNetCore.Mvc;
using receipt_processor.DAO;
using receipt_processor.Models;

namespace receipt_processor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {

        private readonly IReceiptsDao dao;

        public ReceiptsController(IReceiptsDao receiptsDao = null)
        {
            if (receiptsDao == null)
            {
                dao = new ReceiptsMemoryDao();
            }
            else
            {
                dao = receiptsDao;
            }
        }

        // Accept JSON receipt object and return JSON id of receipt
        [HttpPost("process")]
        public ActionResult<Receipt> ProcessReceipt(Receipt receipt)
        {
            Receipt newReceipt = dao.CreateReceipt(receipt);

            return Ok(newReceipt);
        }

        //[HttpGet("{id}/points")]
        //public ActionResult<Receipt> GetPoints(int id)
        //{
        //    Receipt receipt = dao.GetReceiptById(id);
        //}




    }
}
