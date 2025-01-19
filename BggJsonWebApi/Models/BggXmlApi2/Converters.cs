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

   public static BggJsonWebApi.Models.Item ConvertToItem(HotItem item)
    {
        return new BggJsonWebApi.Models.Item
        {
            ObjectId = item.Id,
            // TODO: This is a bit of a hack, since the HotItem doesn't have a CollectionId
            CollectionId = item.Id,
            Name = item.Name.Value,
            YearPublished = item.YearPublished.Value,
            Thumbnail = item.Thumbnail.Value,
        };
    } 
}