using System.Xml.Serialization;

namespace BggJsonWebApi.Models.BggXmlApi2;

[XmlRoot("items")]
public class Collection 
{
    [XmlAttribute("totalitems")]
    public int TotalItems { get; set; }

    [XmlAttribute("pubdate")]
    public required string PubDate { get; set; }

    [XmlElement("item")]
    public required List<Item> Items { get; set; }    
}

public class Item
{
    [XmlAttribute("objectid")]
    public int ObjectId { get; set; }

    [XmlAttribute("collid")]
    public int CollectionId { get; set; }

    [XmlElement("name")]
    public required string Name { get; set; }
    
    [XmlElement("yearpublished")]
    public int YearPublished { get; set; }
    
    [XmlElement("thumbnail")]
    public required string Thumbnail { get; set; }
}