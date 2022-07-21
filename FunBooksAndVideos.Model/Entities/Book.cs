
using FunBooksAndVideos.Contracts.Interfaces;

namespace FunBooksAndVideos.Contracts.Entities
{
    public class Book : IPhysicalProduct
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductCost { get; set; }
    }
}
