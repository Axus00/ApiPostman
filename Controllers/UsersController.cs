using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly ApiBase _context;

    public UsersController(ApiBase context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<User>>>  GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    //por id
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUsersId(int? id)
    {
        var user = await _context.Users.FirstAsync();

        if(user == null)
        {
            return NotFound();
        }

        return user;
    }

    //Crear usuario
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Users", new { id = user.id }, user);
    }

    //Eliminar
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int? id)
    {
        var user = await _context.Users.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        //eliminamos
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //Actualizar
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> PutUser(int id, User updateUser)
    {
        var userExist = await _context.Users.FindAsync(id);

        if(userExist == null)
        {
            return NotFound("El usuario no ha sido encontrado");
        }

        if(userExist != updateUser)
        {
            return BadRequest("El usuario no ha sido posible encontrarlo o no existe");
        }

        //actualizamos
        _context.Entry(userExist).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return userExist;
    }
}