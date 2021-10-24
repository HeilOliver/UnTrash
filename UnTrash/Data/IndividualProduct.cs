namespace UnTrash.Data;

public class IndividualProduct
{
    public Guid Id { get; set; }

    public string Serial { get; set; }
    public Guid Product { get; set; }

    public List<ProductTranslation> Transactions { get; set; }
}