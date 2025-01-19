namespace BggJsonWebApi.Models.BggXmlApi2;
public static class Converters
{
    public static BggJsonWebApi.Models.Item ConvertToItem(Item item)
    {
        return new BggJsonWebApi.Models.Item
        {
            ObjectId = item.ObjectId,
            CollectionId = item.CollectionId,
            Name = item.Name,
            YearPublished = item.YearPublished,
            Thumbnail = item.Thumbnail,
        };
    }
}