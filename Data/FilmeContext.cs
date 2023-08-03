using FilmeAPI_NET6.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI_NET6.Data;
public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {
        
    }

    public DbSet<Filme> Filmes{ get; set; }
}

