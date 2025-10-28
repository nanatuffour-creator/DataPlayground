using CodeAxisAPI.Entities.Data;
using Microsoft.EntityFrameworkCore;
using CodeAxisAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<CodeAxisContext>((o) =>
{
    o.UseSqlServer("server=.\\SQLSERVER_2019;database=demo;user id=sa;password=password1.com;TrustServerCertificate=true;");
});

var app = builder.Build();

using var scoped = app.Services.CreateScope();
var db = scoped.ServiceProvider.GetRequiredService<CodeAxisContext>();
// CodeAxisContext db = app.Services.GetRequiredService<CodeAxisContext>();

// Console.Write("Enter your lastname : ");
// var n = Console.ReadLine();
// Console.Write("Enter your firstname : ");
// var b = Console.ReadLine();
// Console.Write("Enter your age : ");
// var a = Console.ReadLine();
// var parsed = int.TryParse(a, out int s);

// var person = new Person
// {
//     OtherNames = n,
//     LastName = b,
//     Age = s
// };

// db.Add(person);
// db.SaveChanges();

Console.Write("Enter name of person you are searching : ");
string? per = Console.ReadLine();

var queri = from p in db.Persons
            where p.OtherNames == per
            select new {p.LastName , p.Age, p.OtherNames};  //db.Persons.Where(p => p.LastName == "Qofi");

db.Persons.Where(m => m.OtherNames != per);

foreach (var output in queri)
{
    Console.WriteLine();
    Console.WriteLine("User Details.");
    Console.WriteLine($"LastName : {output.LastName}");
    Console.WriteLine($"Age : {output.Age}");
    Console.WriteLine();
}

    // app.MapGet("/", () => "Hello World!");
    // app.MapGet("/dashboard", () => "Hello my dashboard!");

    app.Run();

