Console.Write("Enter index of Prime number u'd like to find: ");
if (int.TryParse(Console.ReadLine(), out int inptNumber))
{
    PrimeNumberFinder(inptNumber);
}
else Console.WriteLine("You didn't enter NUMBER");

static bool IsPrimeNumber(int inptNumber)
{
    var result = true;
    if (inptNumber > 1)
    {
        for (var cntr = 2; cntr <= Math.Sqrt(inptNumber); cntr++)
        {
            if (inptNumber % cntr == 0)
            {
                result = false;
                break;
            }
        }
    }
    else result = false;
    return result;
}
static void PrimeNumberFinder(int index)
{
    var cntr = 0;
    var iNumber = 2;
    while (cntr < index)
    {
        if (IsPrimeNumber(iNumber))
        {
            if (cntr == index - 1)
            {
                Console.WriteLine($"Your {index} Prime number is: {iNumber}");
            }
        cntr++;
        }
        iNumber++;
    }
}