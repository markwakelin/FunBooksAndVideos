using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.Repository.Interfaces
{
    public interface IMembershipActivationRepository
    {
        bool Activate(PurchaseOrder purchaseOrder);
    }
}
