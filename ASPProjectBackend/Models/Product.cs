using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Item name must be between 1 and 50 characters")]
    [DisplayName("Product Name")]
    public string Name { get; set; }

    [StringLength(100, MinimumLength = 0, ErrorMessage = "Description can maximum be of 100 characters")]
    public string Description { get; set; }

    [Required]
    [Range(0, 256, ErrorMessage = "Stock must be between 0 and 256")]
    [DisplayName("Amount In Stock")]
    public byte Stock { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    [Range(0, 2, ErrorMessage = "Discount must be between 0 and 2")]
    public float Discount { get; set; } = 1.00f;

    public int? AppId { get; set; }
    public string? ImageUrl { get; set; }
}
