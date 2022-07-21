using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.BusinessLogic.Factories;

public class VideoMembershipFactory : IMembershipFactory
{
    private readonly IMembershipActivationRepository _membershipActivationRepository;

    public VideoMembershipFactory(IMembershipFactory next, IMembershipActivationRepository membershipActivationRepository)
    {
        _membershipActivationRepository = membershipActivationRepository;
        Next = next;
    }

    public IMembershipFactory Next { get; }


    public bool DecideMembership(PurchaseOrder purchaseOrder)
    {
        if (purchaseOrder.OrderItems.Any(a => a is VideoMembership))
        {
            return _membershipActivationRepository.Activate(purchaseOrder);
        }

        return Next.DecideMembership(purchaseOrder);
    }
}