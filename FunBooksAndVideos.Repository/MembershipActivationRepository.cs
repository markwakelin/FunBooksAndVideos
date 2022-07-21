using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository
{
    public class MembershipActivationRepository : IMembershipActivationRepository
    {
        public bool Activate(PurchaseOrder purchaseOrder)
        {
            return true;
        }
    }
}
