using FunBooksAndVideos.BusinessLogic.Factories;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;
using FunBooksAndVideos.Repository.Interfaces;
using Moq;

namespace FunBooksAndVideos.UnitTests;

[TestClass]
public class BookMembershipFactoryUnitTests
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
    public void GivenPurchaseOrder_OrderItemsContainBookMembershipActivateMembership()
    {
        //Arrange
        var purchaseOrderGeneration = new BookMembershipFactory(_mockMembershipFactory.Object, _mockMembershipActivationRepository.Object);
        var purchaseOrder = BuildPurchaseOrderWithBookMembership();

        //Act
        purchaseOrderGeneration.DecideMembership(purchaseOrder);

        //Assert
        _mockMembershipActivationRepository.Verify(a => a.Activate(It.IsAny<PurchaseOrder>()), Times.Exactly(1));
    }

    [TestMethod]
    public void GivenPurchaseOrder_OrderItemsDoNotContainBookMembershipDoNotActivateMembership()
    {
        //Arrange
        var purchaseOrderGeneration = new BookMembershipFactory(_mockMembershipFactory.Object, _mockMembershipActivationRepository.Object);
        var purchaseOrder = BuildPurchaseOrderWithBook();

        //Act
        purchaseOrderGeneration.DecideMembership(purchaseOrder);

        //Assert
        _mockMembershipActivationRepository.Verify(a => a.Activate(It.IsAny<PurchaseOrder>()), Times.Exactly(0));
    }

    #region Build Entities for tests
    private PurchaseOrder BuildPurchaseOrderWithBookMembership()
    {
        return new PurchaseOrder
        {
            OrderItems = new List<IProduct>
            {
                new BookMembership{ProductId = 3, ProductName = "Book Club Membership"}
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