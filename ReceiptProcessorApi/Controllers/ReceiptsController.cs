using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceiptProcessorApi.Services;
using ReceiptProcessorApi.Models;

namespace ReceiptProcessorApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        // GET: Receipts/5/points
        [HttpGet("{id}/points")]
        public async Task<ActionResult<GetPointsResponse>> GetPoints(Guid id)
        {
            var response = await _receiptService.GetPoints(id);

            if (response == null)
            {
                return NotFound("No receipt found for that ID.");
            }

            return Ok(response);
        }

        // POST: Receipts
        [HttpPost("process")]
        public async Task<ActionResult<ProcessReceiptResponse>> ProcessReceipt(ReceiptPayload receipt)
        {
            try
            {
                var response = await _receiptService.ProcessReceipt(receipt);
                
                if (response == null)
                {
                    return BadRequest("The receipt is invalid.");
                }

                return CreatedAtAction(nameof(ProcessReceipt), response);
            }
            catch (Exception ex)
            {
                return BadRequest("The receipt is invalid.");
            }
        }
    }
}
