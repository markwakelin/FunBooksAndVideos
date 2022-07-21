using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.BusinessLogic.Interfaces;

public interface IPurchaseOrderProcessing
{
    void Process(PurchaseOrder purchaseOrder);
}