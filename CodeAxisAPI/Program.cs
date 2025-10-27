using CodeAxisAPI.Entities.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<CodeAxisContext>((o) =>
{
    o.UseSqlServer("server=.\\SQLSERVER_2019;database=demo;user id=sa;password=password1.com;TrustServerCertificate=true;");
});

// GetNetWorth((d) =>
// {
//     d += 4566748399477585;
//     Console.WriteLine($"This is my net worth ${d}");
// });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dashboard", () => "Hello my dashboard!");

app.Run();



// string GetNetWorth(Action<decimal> worthAction)
// {

//     worthAction.Invoke(78);

//     return "";
// }