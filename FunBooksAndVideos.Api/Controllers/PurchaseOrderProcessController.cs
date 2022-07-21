using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderProcessController : ControllerBase
    {
        private readonly IPurchaseOrderProcessing _purchaseOrderProcessing;

        public PurchaseOrderProcessController(IPurchaseOrderProcessing purchaseOrderProcessing)
        {
            _purchaseOrderProcessing = purchaseOrderProcessing;
        }

        [HttpPost(Name = "Process")]
        public void Process(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderProcessing.Process(purchaseOrder);
        }
    }
}