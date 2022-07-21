using FunBooksAndVideos.BusinessLogic;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;
using FunBooksAndVideos.Repository.Interfaces;
using Moq;

namespace FunBooksAndVideos.UnitTests;

[TestClass]
public class PurchaseOrderGenerationUnitTests
{
    Mock<IPurchaseOrderRepository> _mockPurchaseOrderRepository;

    [TestInitialize]
    public void SetUp()
    {
        _mockPurchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
        _mockPurchaseOrderRepository.Setup(a => a.Save(It.IsAny<PurchaseOrder>())).Returns(It.IsAny<bool>());
    }

    [TestMethod]
    public void GivenPurchaseOrder_WhenIPassPurchaseOrderThenItShouldSaveTheOrder()
    {
        //Arrange
        var purchaseOrderGeneration = new PurchaseOrderGeneration(_mockPurchaseOrderRepository.Object);
        var purchaseOrder = BuildPurchaseOrderTestData();

        //Act
        purchaseOrderGeneration.Generate(purchaseOrder);

        //Assert
        _mockPurchaseOrderRepository.Verify(a => a.Save(It.IsAny<PurchaseOrder>()), Times.Exactly(1));
    }

    #region Build Entities for tests
    private PurchaseOrder BuildPurchaseOrderTestData()
    {
        return new PurchaseOrder
        {
            OrderItems = new List<IProduct>
            {
                new VideoMembership{ProductId = 1, ProductName = "PremiumMembership"},
                new Book{ProductId = 2, ProductName = "Girl on the train"}
            }
        };
    }
    #endregion
}