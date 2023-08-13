using FilmeAPI_NET6.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI_NET6.Data;
public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {
        
    }
    //criando um relacionamento muitos pra muitos
    protected override void OnModelCreating(ModelBuilder Builder)
    {
        Builder.Entity<Sessao>()
            .HasKey(sessao => new { sessao.FilmeId,
                sessao.CinemaId });

        Builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        Builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        //alterando o tipo de delação
        Builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes{ get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}

