// // See https://aka.ms/new-console-template for more information
// // Console.WriteLine("Hello, World!");
ONE:
Console.Write("Enter size for array : ");
bool parsed = int.TryParse(Console.ReadLine(), out int x);

if (!parsed) { Console.WriteLine("You entered the wrong value.It should be a number.");goto ONE;}

// int[] arr = new int[x];

// //arr[0] = 1;
int j;

//int value = 0;
// for (j = 0; j < x; j++)
// {
// TWO:
//     Console.WriteLine("Enter values for the array : ");
//     string? m = Console.ReadLine();
//     // int value = 0;
//     bool valueParsed = int.TryParse(m, out value);
//     if (!valueParsed)
//     {
//         Console.WriteLine("You entered the wrong value.It should be a number.");
//         goto TWO;
//     }

//     arr[j] = value;

// }

// Console.WriteLine();

// for (int i = 0; i < x; i++)
// {
//     Console.WriteLine(arr[i]);
// }

// Console.WriteLine();

// if (x == 1)
// {
//     Console.WriteLine($"Add : {arr[0]}");
// }
// else { Console.WriteLine($"Add : {arr[0] + value}"); }

// if(x == 2)
// {
//     Console.WriteLine($"There is no middle number.");
// }
// else if (x % 2 == 0)
// {
//     Console.WriteLine($"Middle Numbers : {arr[(x / 2) - 1]} , {arr[x / 2]}");
// }
// else
// {
//     Console.WriteLine($"Middle Number : {arr[x / 2]}");
// }

string?[] arr = new string[x];

for (j = 0; j < x; j++)
{
    THREE:
    Console.WriteLine("Enter for the array : ");
    arr[j] = Console.ReadLine();

    if (arr[j] == string.Empty)
    {
        Console.WriteLine("You input should not be empty.");goto THREE;
    }
}
Console.WriteLine();
for (int i = 0; i < x; i++)
{
    Console.WriteLine($"{arr[i] }");
}

if (x == 1)
{
    Console.WriteLine($"\n{arr[0]}");
}
else { Console.WriteLine($"\n{arr[0]} , {arr[x-1]}"); }

if(x == 2)
{
    Console.WriteLine($"There is no middle word.");
}
else if (x % 2 == 0)
{
    Console.WriteLine($"Middle Word : {arr[(x / 2) - 1]} , {arr[x / 2]}");
}
else
{
    Console.WriteLine($"Middle Word : {arr[x / 2]}");
}
