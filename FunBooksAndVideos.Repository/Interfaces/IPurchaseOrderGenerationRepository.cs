using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.Repository.Interfaces;

public interface IPurchaseOrderGenerationRepository
{
    bool Generate(PurchaseOrder purchaseOrder);
}