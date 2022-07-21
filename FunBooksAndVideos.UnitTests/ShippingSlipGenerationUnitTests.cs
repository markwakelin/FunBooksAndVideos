using FunBooksAndVideos.BusinessLogic;
using FunBooksAndVideos.Contracts.Entities;
using FunBooksAndVideos.Contracts.Interfaces;

namespace FunBooksAndVideos.UnitTests
{
    [TestClass]
    public class ShippingSlipGenerationUnitTests
    {
        [TestMethod]
        public void GivenAPurchaseOrder_WhenIHavePhysicalProductThenGenerateShippingSlip()
        {
            //Arrange
            var shippingSlipGenerator = new ShippingSlipGeneration();

            //Act
            var actual = shippingSlipGenerator.Generate(BuildPurchaseOrderWithProductOrderItems());

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenAPurchaseOrder_WhenIHaveMembershipThenDoNotGenerateShippingSlip()
        {
            //Arrange
            var shippingSlipGenerator = new ShippingSlipGeneration();

            //Act
            var actual = shippingSlipGenerator.Generate(BuildPurchaseOrderWithMembershipOrderItems());

            //Assert
            Assert.IsFalse(actual);
        }



        #region Build Entities for tests
        private PurchaseOrder BuildPurchaseOrderWithProductOrderItems()
        {
            return new PurchaseOrder
            {
                OrderItems = new List<IProduct>
                {
                    new Book{ProductId = 2, ProductName = "Girl on the train"}
                }
            };
        }

        private PurchaseOrder BuildPurchaseOrderWithMembershipOrderItems()
        {
            return new PurchaseOrder
            {
                OrderItems = new List<IProduct>
                {
                    new VideoMembership{ProductId = 1, ProductName = "Comprehensive First Aid Training"}
                }
            };
        }
        #endregion
    }
}