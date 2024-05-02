using API.Models;
using Microsoft.EntityFrameworkCore;

namespace provaCsharp.Modelos;

    public class AppDataContext : DbContext{


    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
    }
