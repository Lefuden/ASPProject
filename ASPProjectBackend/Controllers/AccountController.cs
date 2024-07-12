using ASPProjectBackend.Data;
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
}
