// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
ONE:
Console.Write("Enter size for array : ");
bool parsed = int.TryParse(Console.ReadLine(), out int x);

if (!parsed) { Console.WriteLine("You entered the wrong value.It should be a number.");goto ONE;}

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
        Console.WriteLine("You entered the wrong value.It should be a number.");
        goto TWO;
    }

    arr[j] = value;

}
for (int i = 0; i < x; i++)
{
    Console.WriteLine(arr[i]);
}
