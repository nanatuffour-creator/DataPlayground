// See https://aka.ms/new-console-template for more information
ONE: 
Console.Write("Enter Password : ");
dynamic? password = Console.ReadLine();

if(password == string.Empty)
{
    Console.WriteLine("Password can not be empty.");
    goto ONE;
}
TWO:
Console.Write("Confirm Password : ");
dynamic? password1 = Console.ReadLine();

if(password1 == string.Empty)
{
    Console.WriteLine("Password can not be empty.");
    goto TWO;
}

if (password == password1)
{
    Console.WriteLine("Password Match.");
}
else
{
    Console.WriteLine("Password Match.");
}

