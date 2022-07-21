using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.Repository.Interfaces;

public interface IPurchaseOrderRepository
{
    bool Save(PurchaseOrder purchaseOrder);
}