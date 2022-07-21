using FunBooksAndVideos.Contracts.Interfaces;

namespace FunBooksAndVideos.Contracts.Entities;

public class VideoMembership : IMembership
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double ProductCost { get; set; }
}