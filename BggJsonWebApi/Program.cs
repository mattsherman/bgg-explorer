using System.Net;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

var httpClientHandler = new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
};

var httpClient = new HttpClient(httpClientHandler);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.MapGet("/hot-items", async () => 
{
    var bggApiUrl = "https://boardgamegeek.com/xmlapi2/hot?type=boardgame";

    var response = await httpClient.GetAsync(bggApiUrl);

    if (!response.IsSuccessStatusCode)
    {
        return Results.Problem("Failed to retrieve hot items from BGG", statusCode: (int)response.StatusCode);
    }

    var xmlData = await response.Content.ReadAsStringAsync();

    var serializer = new XmlSerializer(typeof(HotItems));

    HotItems? hotItems;

    try
    {
        using var stringReader = new StringReader(xmlData);
        hotItems = (HotItems?)serializer.Deserialize(stringReader);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return Results.Problem($"Failed to deserialize hot items from BGG: {ex.Message}");
    }

    if (hotItems is null)
    {
        return Results.Problem("No data found in XML response from BGG");
    }

    var items = hotItems.Items;

    var result = new HotItemsResponse
    {
        Count = items.Count,
        Items = items,
    };

    return Results.Ok(result);
}).WithName("GetHotItems");

app.MapGet("/users/{userName}/collection", async (string userName, int? minYearPublished) =>
{
    var bggApiUrl = $"https://boardgamegeek.com/xmlapi2/collection?username={userName}";

    var response = await httpClient.GetAsync(bggApiUrl);

    if (!response.IsSuccessStatusCode)
    {
        return Results.Problem("Failed to retrieve collection from BGG", statusCode: (int)response.StatusCode);
    }

    var xmlData = await response.Content.ReadAsStringAsync();

    var serializer = new XmlSerializer(typeof(Collection));

    Collection? collection;

    try
    {
        using var stringReader = new StringReader(xmlData);
        collection = (Collection?)serializer.Deserialize(stringReader);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Failed to deserialize collection from BGG: {ex.Message}");
    }

    if (collection is null)
    {
        return Results.Problem("No data found in XML response from BGG");
    }

    var items = collection.Items;

    if (minYearPublished.HasValue)
    {
        items = items.Where(i => i.YearPublished >= minYearPublished).ToList();
    }

    var result = new CollectionResponse
    {
        Count = items.Count,
        Items = items,
    };

    return Results.Ok(result);
}).WithName("GetCollection");

app.Run();

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

public class HotItemsResponse
{
    public int Count { get; set; }
    public List<HotItem>? Items { get; set; }
}

public class CollectionResponse
{
    public int Count { get; set; }
    public List<Item>? Items { get; set; }
}