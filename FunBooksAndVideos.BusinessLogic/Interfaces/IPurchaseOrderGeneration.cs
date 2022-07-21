using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.BusinessLogic.Interfaces;

public interface IPurchaseOrderGeneration
{ 
    bool Generate(PurchaseOrder purchaseOrder);
}