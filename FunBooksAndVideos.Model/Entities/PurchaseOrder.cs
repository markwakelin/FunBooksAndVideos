using FunBooksAndVideos.Contracts.Interfaces;

namespace FunBooksAndVideos.Contracts.Entities;

public class PurchaseOrder
{
    public int OrderId { get; set; }
    public Customer? Customer { get; set; }
    public IEnumerable<IProduct> OrderItems { get; set; }
}