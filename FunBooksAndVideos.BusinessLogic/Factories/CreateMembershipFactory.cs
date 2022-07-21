using FunBooksAndVideos.Repository;

namespace FunBooksAndVideos.BusinessLogic.Factories;

public class CreateMembershipFactory : ICreateMembershipFactory
{

    public IMembershipFactory Create()
    {
        return new BookMembershipFactory(
            new VideoMembershipFactory(
                new PremiumMembershipFactory(), new MembershipActivationRepository()
                ), new MembershipActivationRepository());
    }
}