using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;

namespace FunBooksAndVideos.BusinessLogic;

public class ShippingSlipGeneration : IShippingSlipGeneration
{
    public bool Generate(PurchaseOrder purchaseOrder)
    {
        if (purchaseOrder.OrderItems.Any(w => w is IPhysicalProduct))
        {
            //TODO: Shipping slip generation code
            return true;
        }

        return default;
    }
}