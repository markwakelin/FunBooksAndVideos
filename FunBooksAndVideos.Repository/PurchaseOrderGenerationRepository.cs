using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository;

public class PurchaseOrderGenerationRepository : IPurchaseOrderGenerationRepository
{
    public bool Generate(PurchaseOrder purchaseOrder)
    {
        return true;
    }
}