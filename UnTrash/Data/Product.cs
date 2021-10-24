namespace UnTrash.Data;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } // Mac Book Air 256GB

    public string PrimaryFeature0 { get; set; } // Core I5

    public string PrimaryFeature1 { get; set; } // 256GB HDD

    public List<Entry> Features { get; set; }

    public List<Entry> Material { get; set; }

    public List<Entry> Components { get; set; }

    public string ImageUrl { get; set; }
    public double Score => Calculate();

    private double Calculate()
    {
        double a = double.Parse(Lifespan);
        double b = double.Parse(Repairability);
        double c = double.Parse(Recoverability);

        return (a + b + c) / 3;
    }

    public string LastTradeFor { get; set; }
    public string ProductsOnMarkedPlace { get; set; }
    public string CarbonFootprint { get; set; }
    public string Lifespan { get; set; }
    public string Repairability { get; set; }
    public string Recoverability { get; set; }
    public string MaterialOrigin { get; set; }

    public double TotalMaterialPrice => CalculateMaterialPrice();
    public double TotalComponentsPrice => CalculateComponentsPrice();

    private double CalculateMaterialPrice()
    {
        return Material.Select(e => double.Parse(e.Value)).Sum();
    }

    private double CalculateComponentsPrice()
    {
        return Components.Select(e => double.Parse(e.Value)).Sum();
    }
}