namespace BggJsonWebApi.Models;

public class Item
{
    public int ObjectId { get; set; }

    public int CollectionId { get; set; }

    public required string Name { get; set; }
    
    public int YearPublished { get; set; }
    
    public required string Thumbnail { get; set; }
}