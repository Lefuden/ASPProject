using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController(ApplicationDbContext context) : ControllerBase
{

    [HttpPost("AddAddress")]
    public async Task<IActionResult> AddAddress(UpdateAddress updateAddress)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == updateAddress.Email);

            if (user == null)
            {
                return BadRequest();
            }

            context.Add(updateAddress.Address);
            await context.SaveChangesAsync();

            user.Address = updateAddress.Address;
            user.AddressId = updateAddress.Address.AddressId;

            context.Update(user);

            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost("EditAddress/{id}")]
    public async Task<IActionResult> EditAddress(int id, UpdateAddress updateAddress)
    {
        try
        {
            var address = await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);

            if (address == null)
            {
                return NotFound();
            }

            address.Country = updateAddress.Address.Country;
            address.City = updateAddress.Address.City;
            address.StreetAddress = updateAddress.Address.StreetAddress;
            address.ZipCode = updateAddress.Address.ZipCode;

            context.Update(address);
            await context.SaveChangesAsync();
            return Ok();
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }
    }

    [HttpGet("Address")]
    public async Task<ActionResult<IEnumerable<Address>>> GetAllAddresses()
    {
        return await context.Addresses.ToListAsync();
    }

    [HttpGet("Address/{id}")]
    public async Task<ActionResult<Address>> GetAddress(int id)
    {
        var address = await context.Addresses.FindAsync(id);

        if (address == null)
        {
            return NotFound();
        }

        return address;
    }

    [HttpGet("Users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet("Users/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}
