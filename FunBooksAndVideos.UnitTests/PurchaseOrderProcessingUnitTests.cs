using FunBooksAndVideos.BusinessLogic;
using FunBooksAndVideos.BusinessLogic.Factories;
using FunBooksAndVideos.BusinessLogic.Interfaces;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace FunBooksAndVideos.UnitTests;

[TestClass]
public class PurchaseOrderProcessingUnitTests
{
    Mock<ILogger> _mockLogger;
    Mock<IPurchaseOrderGeneration> _mockPurchaseOrderGeneration;
    Mock<IShippingSlipGeneration> _mockShippingSlipGeneration;
    Mock<ICreateMembershipFactory> _mockCreateMembershipFactory;

    [TestInitialize]
    public void SetUp()
    {
        _mockLogger = new Mock<ILogger>();
        _mockPurchaseOrderGeneration = new Mock<IPurchaseOrderGeneration>();
        _mockShippingSlipGeneration = new Mock<IShippingSlipGeneration>();
        _mockCreateMembershipFactory = new Mock<ICreateMembershipFactory>();

        _mockPurchaseOrderGeneration.Setup(a => a.Generate(It.IsAny<PurchaseOrder>()))
            .Returns(It.IsAny<bool>());

        _mockShippingSlipGeneration.Setup(a => a.Generate(It.IsAny<PurchaseOrder>()))
            .Returns(It.IsAny<bool>());

        _mockCreateMembershipFactory.Setup(a => a.Create()).Returns(It.IsAny<IMembershipFactory>());
    }

    [TestMethod]
    public void GivenPurchaseOrder_WhenProcessPurchaseOrderThenInvokeAllActions()
    {
        //Arrange
        var testData = BuildPurchaseOrderTestData();

        var purchaseOrderProcessing = new PurchaseOrderProcessing(_mockLogger.Object, _mockCreateMembershipFactory.Object, _mockPurchaseOrderGeneration.Object, _mockShippingSlipGeneration.Object);

        //Act
        purchaseOrderProcessing.Process(testData);

        //Assert
        _mockCreateMembershipFactory.Verify(a => a.Create(), Times.Exactly(1));
        _mockPurchaseOrderGeneration.Verify(a => a.Generate(It.IsAny<PurchaseOrder>()), Times.Exactly(1));
        _mockShippingSlipGeneration.Verify(a => a.Generate(It.IsAny<PurchaseOrder>()), Times.Exactly(1));

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