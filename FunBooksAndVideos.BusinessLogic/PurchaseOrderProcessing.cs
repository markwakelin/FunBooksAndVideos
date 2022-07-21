using FunBooksAndVideos.BusinessLogic.Factories;
using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.BusinessLogic;

public class PurchaseOrderProcessing : IPurchaseOrderProcessing
{
    private readonly ILogger _logger;
    private readonly ICreateMembershipFactory _createMembershipFactory;
    private readonly IPurchaseOrderGeneration _purchaseOrderGeneration;
    private readonly IShippingSlipGeneration _shippingSlipGeneration;

    public PurchaseOrderProcessing(ILogger logger, ICreateMembershipFactory createMembershipFactory, 
        IPurchaseOrderGeneration purchaseOrderGeneration,
        IShippingSlipGeneration shippingSlipGeneration)
    {
        _logger = logger;
        _createMembershipFactory = createMembershipFactory;
        _purchaseOrderGeneration = purchaseOrderGeneration;
        _shippingSlipGeneration = shippingSlipGeneration;
    }

    public void Process(PurchaseOrder purchaseOrder)
    {
        try
        {
            // BR1. If the purchase order contains a membership, it has to be activated in the customer account immediately.
            _createMembershipFactory.Create();

            _purchaseOrderGeneration.Generate(purchaseOrder);

            // BR2. If the purchase order contains a physical product a shipping slip has to be generated.
            _shippingSlipGeneration.Generate(purchaseOrder);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

    }
}