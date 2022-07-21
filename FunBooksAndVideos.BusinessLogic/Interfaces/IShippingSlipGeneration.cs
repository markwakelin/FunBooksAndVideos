using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.BusinessLogic.Interfaces;

public interface IShippingSlipGeneration
{
    bool Generate(PurchaseOrder purchaseOrder);
}