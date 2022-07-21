using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.BusinessLogic;

public class PurchaseOrderGeneration : IPurchaseOrderGeneration
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public PurchaseOrderGeneration(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public bool Generate(PurchaseOrder purchaseOrder)
    {
        return _purchaseOrderRepository.Save(purchaseOrder);
    }
}