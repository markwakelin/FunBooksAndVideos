using FunBooksAndVideos.Api.Controllers;
using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;
using Moq;

namespace FunBooksAndVideos.UnitTests;

[TestClass]
public class PurchaseOrderProcessControllerUnitTests
{
    Mock<IPurchaseOrderProcessing> _mockPurchaseOrderProcessing;

    [TestInitialize]
    public void SetUp()
    {
        _mockPurchaseOrderProcessing = new Mock<IPurchaseOrderProcessing>();
        
        _mockPurchaseOrderProcessing.Setup(a => a.Process(It.IsAny<PurchaseOrder>()));
    }

    [TestMethod]
    public void GivenPurchaseOrder_ApiProcessesPurchaseOrder()
    {
        //Arrange
        var purchaseOrderProcessController = new PurchaseOrderProcessController(_mockPurchaseOrderProcessing.Object);
        var purchaseOrder = BuildPurchaseOrderTestData();

        //Act
        purchaseOrderProcessController.Process(purchaseOrder);

        //Assert
        _mockPurchaseOrderProcessing.Verify(a => a.Process(It.IsAny<PurchaseOrder>()), Times.Exactly(1));
    }

    #region Build Entities for tests
    private PurchaseOrder BuildPurchaseOrderTestData()
    {
        return new PurchaseOrder
        {
            OrderItems = new List<IProduct>
            {
                new VideoMembership{ProductId = 1, ProductName = "VideoMembership"},
                new Book{ProductId = 2, ProductName = "Girl on the train"}
            }
        };
    }
    #endregion
}