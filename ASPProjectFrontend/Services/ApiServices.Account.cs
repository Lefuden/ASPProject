using ASPProjectFrontend.Models;
using ASPProjectFrontend.Models.DTO;
using System.Security.Claims;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
    public async Task<bool> AddAddressToNewUser(Address address, ClaimsPrincipal user)
    {
        var updateAddress = new UpdateAddress { Address = address, Email = user.FindFirstValue(ClaimTypes.Email) };
        var response = await _client.PostAsJsonAsync("Account/AddAddress", updateAddress);
        return response.IsSuccessStatusCode;
    }
}

