using System.Xml.Serialization;

namespace BggJsonWebApi.Models.BggXmlApi2;

[XmlRoot("items")]
public class HotItems
{
    [XmlElement("item")]
    public required List<HotItem> Items { get; set; }
}

public class HotItem
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("rank")]
    public int Rank { get; set; }

    [XmlElement("name")]
    public required HotItemName Name { get; set; }
    
    [XmlElement("yearpublished")]
    public required HotItemYearPublished YearPublished { get; set; }
    
    [XmlElement("thumbnail")]
    public required HotItemThumbnail Thumbnail { get; set; }
}

public class HotItemName
{
    [XmlAttribute("value")]
    public required string Value { get; set; }
}

public class HotItemYearPublished
{
    [XmlAttribute("value")]
    public required int Value { get; set; }
}

public class HotItemThumbnail
{
    [XmlAttribute("value")]
    public required string Value { get; set; }
}