using System;
using Microsoft.EntityFrameworkCore;

namespace JoinConsole.Entities.Data;

public class JoinContext : DbContext
{
    public DbSet<CourseDetails> CourseDetails { get; set; }
    public DbSet<StudentDetails> StudentDetails { get; set; }
    public JoinContext(DbContextOptions<JoinContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
