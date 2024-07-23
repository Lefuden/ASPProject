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
    private readonly ApplicationDbContext _context = context;

    [HttpPost("AddAddress")]
    public async Task<IActionResult> AddAddress(UpdateAddress updateAddress)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == updateAddress.Email);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return BadRequest();
            }
            Console.WriteLine("User found!");

            _context.Add(updateAddress.Address);
            await context.SaveChangesAsync();

            user.Address = updateAddress.Address;
            user.AddressId = updateAddress.Address.AddressId;

            _context.Update(user);

            await _context.SaveChangesAsync();
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
                Console.WriteLine("Address not found");
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

    //Fixa AddressDto
    [HttpGet("Address")]
    public async Task<ActionResult<IEnumerable<Address>>> GetAllAddresses()
    {
        return await _context.Addresses.ToListAsync();
    }

    [HttpGet("Address/{id}")]
    public async Task<ActionResult<Address>> GetAddress(int id)
    {
        var address = await context.Addresses.FindAsync(id);

        if (address == null)
        {
            Console.WriteLine("Address not found");
            return NotFound();
        }

        return address;
    }

    //Fixa UserDto
    [HttpGet("Users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("Users/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            Console.WriteLine("User not found");
            return NotFound();
        }

        return user;
    }
}
