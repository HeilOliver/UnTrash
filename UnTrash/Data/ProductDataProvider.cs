using System.Text.Json;
using Bogus;

namespace UnTrash.Data;

public class ProductDataProvider
{
    private readonly List<Product> list;
    public ProductDataProvider()
    {
        //var ruleFor = new Faker<Product>()
        //    .RuleFor(e => e.Name, f => f.Name.JobTitle())
        //    .RuleFor(e => e.PrimaryFeature0, f => f.Company.CompanyName())
        //    .RuleFor(e => e.PrimaryFeature1, f => f.Database.Type())
        //    .RuleFor(e => e.ImageUrl, f => f.Image.PicsumUrl())
        //    .RuleFor(e => e.Score, f => f.Random.Int(0, 10))
        //    .RuleFor(e => e.Id, f => Guid.NewGuid());

        //list = ruleFor.Generate(500);


        string text = File.ReadAllText("combined_data.json");
        list = JsonSerializer.Deserialize<List<Product>>(text);
    }


    public async Task<List<Product>> GetProductFrom(string searchTerm)
    {
        var products = list
            .Where(e => e.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        await Task.Delay(100);

        return products;
    }

    public async Task<Product> GetSingle(Guid id)
    {
        var firstOrDefault = list
            .FirstOrDefault(e => e.Id == id);

        await Task.Delay(100);
        return firstOrDefault;
    }
}