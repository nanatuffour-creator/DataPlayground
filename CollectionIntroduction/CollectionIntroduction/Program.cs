// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
ONE:
Console.Write("Enter size for array : ");
bool parsed = int.TryParse(Console.ReadLine(), out int x);

if (!parsed) goto ONE;

int[] arr = new int[x];

//arr[0] = 1;
int j;

int value = 0;
for (j = 0; j < x; j++)
{
TWO:
    Console.WriteLine("Enter values for the array : ");
    string? m = Console.ReadLine();
    // int value = 0;
    bool valueParsed = int.TryParse(m, out value);
    if (!valueParsed)
    {
        goto TWO;
    }

    arr[j] = value;

    // if (int.TryParse(m, out int d))
    // {
    //     Console.WriteLine($"The value should not {d}.");
    // }
    // else
    // {
    //     Console.WriteLine($"Enter a valid number.");
    // }
}
for (int i = 0; i < x; i++)
{
    Console.WriteLine(arr[i]);
}

// arr[0] = 2;
// arr[1] = 5;
// arr[2] = 4;
// arr[3] = 8;
// arr[5] = 7;
// arr[6] = 7;
// arr[7] = 7;

// Console.WriteLine($"{arr[0]}");
// Console.WriteLine($"{arr[1]}");
// Console.WriteLine($"{arr[2]}");
// Console.WriteLine($"{arr[3]}");
// Console.WriteLine($"{arr[4]}");
