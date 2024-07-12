using System.ComponentModel;

namespace ASPProjectFrontend.Models;

public class Product
{
    public int ProductId { get; set; }

    [DisplayName("Product Name")]
    public string Name { get; set; }
    public string Description { get; set; }

    [DisplayName("Amount In Stock")]
    public byte Stock { get; set; }
    public decimal Price { get; set; }
    public float Discount { get; set; } = 1.00f;
    public int? AppId { get; set; }
    public string? ImageUrl { get; set; }
}
