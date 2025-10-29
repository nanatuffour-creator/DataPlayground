using Microsoft.EntityFrameworkCore;
using USSDConsole.Entities;
using USSDConsole.Entities.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<UssdContext>((o) =>
{
    o.UseSqlServer("server=.\\SQLSERVER_2019;database=demo;user id=sa;password=password1.com;TrustServerCertificate=true;");
});


var app = builder.Build();

using var scoped = app.Services.CreateScope();
var db = scoped.ServiceProvider.GetRequiredService<UssdContext>();

Console.WriteLine("Register For Program.");
Console.WriteLine("1.Register For Oakwood Advisory meeting.");
Console.WriteLine("2.Register For Oakwood Advansio meeting.");
Console.WriteLine("3.Verify user's meeting code.");
Console.Write("Choose the meeting you would like to register for : ");
var select = Console.ReadLine();
var parsed = int.TryParse(select, out int u);

if (u == 1)
{
    RegAdvis();
}
else if (u == 2)
{
    RegAdvan();
}
else if (u == 3)
{
    VerUser();
}

void RegAdvan()
{
    Console.Write("Enter your lastname : ");
    var n = Console.ReadLine();
    Console.Write("Enter your firstname : ");
    var b = Console.ReadLine();

    var random = new Random();
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
    var result = new StringBuilder();

    for (int i = 0; i < 15; i++) // Change 10 to your desired length
    {
        result.Append(chars[random.Next(chars.Length)]);
    }

    var advan = new AdvansioUser
    {
        FirstName = n,
        LastName = b,
        ProgramName = "Advansio Meeting.",
        Code = result.ToString()
    };
    
    db.Add(advan);
    db.SaveChanges();

    var m = result.ToString();
    Console.WriteLine($"This is your meeting code {m}");
}

void RegAdvis()
{
    Console.Write("Enter your lastname : ");
    var n = Console.ReadLine();
    Console.Write("Enter your firstname : ");
    var b = Console.ReadLine();

    var random = new Random();
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
    var result = new StringBuilder();

    for (int i = 0; i < 15; i++) // Change 10 to your desired length
    {
        result.Append(chars[random.Next(chars.Length)]);
    }

    var advis = new AdvisoryUser
    {
        FirstName = n,
        LastName = b,
        ProgramName = " Advisory Meeting.",
        Code = result.ToString()
    };

    db.Add(advis);
    db.SaveChanges();

    var m = result.ToString();
    Console.WriteLine($"This is your meeting code {m}");
}

void VerUser()
{
    Console.WriteLine("Which Meeting are you checking for.");
    Console.WriteLine("1.Advisory Meeting");    
    Console.WriteLine("2.Advansio Meeting");
    Console.Write("Select your option : ");
    var opt = Console.ReadLine();
    var parsed = int.TryParse(opt, out int j);
    if (j == 1)
    {
        VerAdvis();
    }
    else if (j == 2)
    {
        VerAdvan();
    }
    
    void VerAdvan()
    {
        Console.Write("Enter code of meeting : ");
        string? per = Console.ReadLine();

        var queri = from p in db.AdvansioUser
                    where p.Code == per
                    select p;

        foreach (var output in queri)
        {
            if (output.Code == per)
            {
                Console.WriteLine("Valid Meeting Code");
            }
            else if (output.Code != per)
            {
                Console.WriteLine("Invalid Meeting Code");
            }
        }
    }
    
    void VerAdvis()
    {
        Console.Write("Enter code of meeting : ");
        string? per = Console.ReadLine();

        var queri = from p in db.AdvisoryUser
                    where p.Code == per
                    select p;


        foreach (var output in queri)
        {
            if (output.Code == per)
            {
                Console.WriteLine("Valid Meeting Code");
            }
            else if (output.Code != per)
            {
                Console.WriteLine("Invalid Meeting Code");
            }
        }
    }
    
}
app.MapGet("/", () => "Hello World!");

app.Run();
