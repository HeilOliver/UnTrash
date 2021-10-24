using Bogus;

namespace UnTrash.Data;

public class IndividualProductDataProvider
{
    private readonly List<IndividualProduct> list = new();

    public IndividualProductDataProvider()
    {
        list.Add(new IndividualProduct()
        {
            Id = Guid.Parse("d1f13355-c74a-4e12-9f3d-71a7272a7249"),
            Product = Guid.Parse("18a35770-3965-4959-a840-1b386e4f5379"),
            Serial = "1234567890",
            Transactions = new List<ProductTranslation>()
            {
                new()
                {
                    DateTime = $"{DateTime.Now.AddYears(-3):D}",
                    Action = "Initial purchase"
                },
                new()
                {
                    DateTime = $"{DateTime.Now.AddYears(-2).AddDays(10):D}",
                    Action = "Repaired"
                },
                new()
                {
                    DateTime = $"{DateTime.Now.AddYears(-1).AddDays(-50):D}",
                    Action = "Sold"
                },
                new()
                {
                    DateTime = $"{DateTime.Now:D}",
                    Action = "Recycled"
                }
            }
        });
    }

    public async Task<Guid> Add(Guid product, string serial)
    {
        var firstOrDefault = list
            .FirstOrDefault(e => e.Product == product && e.Serial.Equals(serial, StringComparison.InvariantCultureIgnoreCase));

        if (firstOrDefault != null)
        {
            return firstOrDefault.Id;
        }

        var individualProduct = new IndividualProduct
        {
            Id = Guid.NewGuid(),
            Serial = serial,
            Product = product,
            Transactions = new List<ProductTranslation>()
            {
                new()
                {
                    DateTime = $"{DateTime.Now:D}",
                    Action = "Initial purchase"
                }
            }
        };
        list.Add(individualProduct);
        await Task.Delay(100);
        return individualProduct.Id;
    }

    public async Task<List<IndividualProduct>> GetAll()
    {
        await Task.Delay(100);
        return list;
    }

    public async Task<bool> CheckSerial(Guid product, string serial)
    {
        if (string.IsNullOrEmpty(serial))
            return false;

        if (serial.Length != 10)
            return false;

        await Task.Delay(100);
        return true;
    }

    public async Task<IndividualProduct> Get(Guid id)
    {
        var firstOrDefault = list
            .FirstOrDefault(e => e.Id == id);

        await Task.Delay(200);

        return firstOrDefault;

    }
}