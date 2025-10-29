using System;
using Microsoft.EntityFrameworkCore;

namespace USSDConsole.Entities.Data;
public class UssdContext : DbContext
{   
    public DbSet<AdvansioUser> AdvansioUser { get; set; }
    public DbSet<AdvisoryUser> AdvisoryUser { get; set; }
    public UssdContext(DbContextOptions<UssdContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

