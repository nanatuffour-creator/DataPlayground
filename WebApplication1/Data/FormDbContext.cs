using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class FormDbContext : DbContext
{
    public FormDbContext(DbContextOptions<FormDbContext> options): base(options)
    {
    }

    public DbSet<FormModel> FormModels { get; set; }
}


