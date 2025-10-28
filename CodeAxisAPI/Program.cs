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

Console.WriteLine("1.Add User.");
Console.WriteLine("2.Delete User.");
Console.WriteLine("3.Search User.");
Console.WriteLine("4.Add User.");
Console.Write("Choose an option : ");
var select = Console.ReadLine();
var parsed = int.TryParse(select, out int u);
if (u == 1)
{
    AddUser();
}
else if (u == 2)
{
    Console.WriteLine("Not implemented.");
}else if (u == 3)
{
    Search();
}

//Add User.
void AddUser()
{
    Console.Write("Enter your lastname : ");
    var n = Console.ReadLine();
    Console.Write("Enter your firstname : ");
    var b = Console.ReadLine();
    Console.Write("Enter your age : ");
    var a = Console.ReadLine();
    parsed = int.TryParse(a, out int s);

    var person = new Person
    {
        OtherNames = n,
        LastName = b,
        Age = s
    };

    db.Add(person);
    db.SaveChanges();
}

//Search User
void Search()
{
    Console.WriteLine("1.Search user by lastname.");
    Console.WriteLine("2.Search user by firstname.");
    Console.WriteLine("3.Search user by age.");
    Console.Write("Choose an option : ");
    var a = Console.ReadLine();
    parsed = int.TryParse(a, out int s);

    if (s == 1)
    {
        SeaLast();
    }else if (s == 2)
    {
        SeaFirst();
    }else if (s == 3)
    {
        SeaAge();
    }
}
//Search by lastname.
void SeaLast()
{
    Console.Write("Enter lastname of person you are searching : ");
    string? per = Console.ReadLine();

    var queri = from p in db.Persons
                where p.LastName == per
                select new {p.LastName , p.Age, p.OtherNames};  //db.Persons.Where(p => p.LastName == "Qofi");


// if (!db.Persons.Any(m => m.OtherNames != per))
// {
//     Console.WriteLine("User not found");
// }

    foreach (var output in queri)
    {
        Console.WriteLine();
        Console.WriteLine("User Details.");
        Console.WriteLine($"FirstName : {output.OtherNames}");
        Console.WriteLine($"Age : {output.Age}");
        Console.WriteLine();
    }
}
//Search by FirstName
void SeaFirst()
{
    Console.Write("Enter firstname of person you are searching : ");
    string? per = Console.ReadLine();

    var queri = from p in db.Persons
                where p.OtherNames == per
                select new { p.LastName, p.Age, p.OtherNames };  //db.Persons.Where(p => p.LastName == "Qofi");


    // if (!db.Persons.Any(m => m.OtherNames != per))
    // {
    //     Console.WriteLine("User not found");
    // }

    foreach (var output in queri)
    {
        Console.WriteLine();
        Console.WriteLine("User Details.");
        Console.WriteLine($"LastName : {output.LastName}");
        Console.WriteLine($"Age : {output.Age}");
        Console.WriteLine();
    }
}

void SeaAge()
{
    Console.Write("Enter age of person you are searching : ");
    var per = Console.ReadLine();
    
    if (int.TryParse(per,  out int f))
    {
        var queri = from p in db.Persons
                    where p.Age == f
                    select new { p.LastName, p.Age, p.OtherNames };

        foreach (var person in queri)
        {
            Console.WriteLine($"{person.LastName}, {person.OtherNames}");
        }
    }
    else
    {
        Console.WriteLine("Invalid age entered.");
    }  //db.Persons.Where(p => p.LastName == "Qofi");


    // if (!db.Persons.Any(m => m.OtherNames != per))
    // {
    //     Console.WriteLine("User not found");
    // }

    
}

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/dashboard", () => "Hello my dashboard!");

app.Run();

