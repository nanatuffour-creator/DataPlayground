using System;
using Microsoft.EntityFrameworkCore;

namespace CodeAxisAPI.Entities.Data;

public class CodeAxisContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    public CodeAxisContext(DbContextOptions<CodeAxisContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
