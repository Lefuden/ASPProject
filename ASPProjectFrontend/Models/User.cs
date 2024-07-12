using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace ASPProjectFrontend.Models;

public class User : IdentityUser<int>
{
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
