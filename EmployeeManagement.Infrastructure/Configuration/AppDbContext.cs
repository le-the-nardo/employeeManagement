using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Configuration;

public class AppDbContext : DbContext
{
    
    public DbSet<Employee> Employess { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da relação entre Employee e Department
        modelBuilder.Entity<Employee>()
            .HasOne<Department>() // Um funcionário tem um departamento
            .WithMany() // Um departamento pode ter muitos funcionários
            .HasForeignKey(e => e.DepartmentId) // Chave estrangeira
            .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata
    }
}