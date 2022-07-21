using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.BusinessLogic.Factories
{
    public interface IMembershipFactory
    {
        bool DecideMembership(PurchaseOrder purchaseOrder);
    }
}
