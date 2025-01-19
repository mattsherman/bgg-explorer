using System.Net;
using System.Xml.Serialization;

using BggJsonWebApi.Models;
using BggXmlApi2 = BggJsonWebApi.Models.BggXmlApi2;

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

    var serializer = new XmlSerializer(typeof(BggXmlApi2.HotItems));

    BggXmlApi2.HotItems? hotItems;

    try
    {
        using var stringReader = new StringReader(xmlData);
        hotItems = (BggXmlApi2.HotItems?)serializer.Deserialize(stringReader);
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

    var serializer = new XmlSerializer(typeof(BggXmlApi2.Collection));

    BggXmlApi2.Collection? collection;

    try
    {
        using var stringReader = new StringReader(xmlData);
        collection = (BggXmlApi2.Collection?)serializer.Deserialize(stringReader);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Failed to deserialize collection from BGG: {ex.Message}");
    }

    if (collection is null)
    {
        return Results.Problem("No data found in XML response from BGG");
    }

    var items = collection.Items.Select(BggXmlApi2.Converters.ConvertToItem).ToList();

    if (minYearPublished.HasValue)
    {
        items = items.Where(i => i.YearPublished >= minYearPublished).ToList();
    }

    var result = new Collection
    {
        Count = items.Count,
        Items = items,
    };

    return Results.Ok(result);
}).WithName("GetCollection");

app.Run();

public class HotItemsResponse
{
    public int Count { get; set; }
    public List<BggXmlApi2.HotItem>? Items { get; set; }
}