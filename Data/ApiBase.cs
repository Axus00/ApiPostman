using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data;

public class ApiBase : DbContext
{
    public ApiBase(DbContextOptions<ApiBase> options) : base(options)
    {

    }

    //modelos
    public DbSet<User> Users { get; set; }
}