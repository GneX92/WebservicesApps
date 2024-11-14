namespace WarenKatalog;

public class RootProducts
{
    public Meta? Meta { get; set; }
    public List<Products>? Products { get; set; }
}

public class Meta
{
    public string? Next_link { get; set; }
}

public class Products
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Self_link { get; set; }
    public ProductDetails? Details { get; set; }

    public override string? ToString() => Name;
}

public class ProductDetails
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public float Price { get; set; }
    public List<Vendors>? Vendors { get; set; }
    public string? Image_link { get; set; }
    public DateTime Modified_at { get; set; }
}

public class Vendors
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Self_link { get; set; }
}