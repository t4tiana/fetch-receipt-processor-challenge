using Microsoft.AspNetCore.Mvc;
using receipt_processor.DAO;
using receipt_processor.Models;
using System.Collections.Generic;

namespace receipt_processor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {

        private readonly IReceiptsDao dao;

        public ReceiptsController()
        {
            dao = new ReceiptsMemoryDao();
        }

        [HttpGet]
        public ActionResult<List<Receipt>> Ready()
        {
            List<Receipt> receipts = dao.ListReceipts();
            return Ok(receipts);
        }

        // Accept JSON receipt object and return JSON id of receipt
        [HttpPost("process")]
        public ActionResult<string> ProcessReceipt(ReceiptDto dto)
        {
            Receipt newReceipt = dao.CreateReceipt(dto);

            return Ok(newReceipt); //How to return a JSON object that only has 1 property visible?
        }

        [HttpGet("{id}/points")]
        public ActionResult<Receipt> GetPoints(string id)
        { 
            Receipt currentReceipt = dao.GetReceiptById(id);
            Receipt receiptWithPoints = dao.CalculatePoints(currentReceipt);

            return Ok(receiptWithPoints);

        }




    }
}
