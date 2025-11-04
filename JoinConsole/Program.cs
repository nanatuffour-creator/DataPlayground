using Microsoft.EntityFrameworkCore;
using JoinConsole.Entities;
using JoinConsole.Entities.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<JoinContext>((o) =>
{
    o.UseSqlServer("server=.\\SQLSERVER_2019;database=demo;user id=sa;password=password1.com;TrustServerCertificate=true;");
});

var app = builder.Build();

using var scoped = app.Services.CreateScope();
var db = scoped.ServiceProvider.GetRequiredService<JoinContext>();

Console.WriteLine("Register Student or Course.");
Console.WriteLine("1.Register Course.");
Console.WriteLine("2.Register Student.");
Console.Write("Choose an option : ");
var select = Console.ReadLine();
var parsed = int.TryParse(select, out int selects);


if (selects == 1)
{
    CouRegister();
}
else if (selects == 2)
{
    StuRegister();
}

void StuRegister()
{
    Console.Write($"Enter Name of Student : ");
    string? stu = Console.ReadLine();
    Console.Write($"Enter Course of Study : ");
    string? stud = Console.ReadLine();
    var student = new StudentDetails
    {
        StudentName = stu,
        CourseName = stud
    };
    var cou = db.Set<StudentDetails>().Add(student);
    db.SaveChanges();
    student.StudentId = $"STU2025-{student.Id:D3}";
    db.SaveChanges();
}
void CouRegister()
{
    Console.Write($"Enter Name of Course : ");
    string? cour = Console.ReadLine();
    var courses = new CourseDetails
    {
        CourseName = cour
    };
    var cou = db.Set<CourseDetails>().Add(courses);
    db.SaveChanges();
    courses.CourseId = $"{courses.CourseName![0]}{courses.CourseName![1]}-{courses.Id:D3}";
    db.SaveChanges();
}

Console.WriteLine($"Seacrh students by course name : ");
string? seastu = Console.ReadLine();


var obj = (from cols in db.StudentDetails
           from c in db.CourseDetails
           where cols.CourseName == seastu &&
                    c.CourseName == seastu
           select new
           {
               sId = cols.StudentId,
               sNa = cols.StudentName,
               cId = c.CourseId

           })
           .
           ToList();
 
foreach(var objs in obj)
{
    Console.WriteLine($"Student Name : {objs.sNa}");
    Console.WriteLine($"Student Id : {objs.sId}");
    Console.WriteLine($"Course Id : {objs.cId}");
}
app.MapGet("/", () => "Hello World!");

app.Run();
