using FunBooksAndVideos.Contracts.Entities;

namespace FunBooksAndVideos.BusinessLogic.Factories;

public class PremiumMembershipFactory : IMembershipFactory
{
    public bool DecideMembership(PurchaseOrder purchaseOrder)
    {
        return default;
    }
}