using FunBooksAndVideos.BusinessLogic.Factories;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;
using FunBooksAndVideos.Repository.Interfaces;
using Moq;

namespace FunBooksAndVideos.UnitTests;

[TestClass]
public class VideoMembershipFactoryUnitTests
{
    Mock<IMembershipFactory> _mockMembershipFactory;
    Mock<IMembershipActivationRepository> _mockMembershipActivationRepository;

    [TestInitialize]
    public void SetUp()
    {
        _mockMembershipFactory = new Mock<IMembershipFactory>();
        _mockMembershipActivationRepository = new Mock<IMembershipActivationRepository>();

        _mockMembershipFactory.Setup(a => a.DecideMembership(It.IsAny<PurchaseOrder>())).Returns(It.IsAny<bool>());
        _mockMembershipActivationRepository.Setup(a => a.Activate(It.IsAny<PurchaseOrder>())).Returns(It.IsAny<bool>());
    }


    [TestMethod]
    public void GivenPurchaseOrder_OrderItemsContainVideoMembershipActivateMembership()
    {
        //Arrange
        var purchaseOrderGeneration = new VideoMembershipFactory(_mockMembershipFactory.Object, _mockMembershipActivationRepository.Object);
        var purchaseOrder = BuildPurchaseOrderWithVideoMembership();

        //Act
        purchaseOrderGeneration.DecideMembership(purchaseOrder);

        //Assert
        _mockMembershipActivationRepository.Verify(a => a.Activate(It.IsAny<PurchaseOrder>()), Times.Exactly(1));
    }

    [TestMethod]
    public void GivenPurchaseOrder_OrderItemsDoNotContainVideoMembershipDoNotActivateMembership()
    {
        //Arrange
        var purchaseOrderGeneration = new VideoMembershipFactory(_mockMembershipFactory.Object, _mockMembershipActivationRepository.Object);
        var purchaseOrder = BuildPurchaseOrderWithBook();

        //Act
        purchaseOrderGeneration.DecideMembership(purchaseOrder);

        //Assert
        _mockMembershipActivationRepository.Verify(a => a.Activate(It.IsAny<PurchaseOrder>()), Times.Exactly(0));
    }

    #region Build Entities for tests
    private PurchaseOrder BuildPurchaseOrderWithVideoMembership()
    {
        return new PurchaseOrder
        {
            OrderItems = new List<IProduct>
            {
                new VideoMembership{ProductId = 1, ProductName = "Comprehensive First Aid Training"}
            }
        };
    }

    private PurchaseOrder BuildPurchaseOrderWithBook()
    {
        return new PurchaseOrder
        {
            OrderItems = new List<IProduct>
            {
                new Book{ProductId = 2, ProductName = "The Girl on the train"}
            }
        };
    }
    #endregion
}