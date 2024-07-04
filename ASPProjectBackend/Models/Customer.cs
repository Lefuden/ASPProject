using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPProjectBackend.Models;

public class Customer : IdentityUser<int>
{
    [Required]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 30 characters")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 30 characters")]
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
