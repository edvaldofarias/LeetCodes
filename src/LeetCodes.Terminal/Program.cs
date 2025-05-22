// See https://aka.ms/new-console-template for more information

using LeetCodes.Terminal.TwoSum;

namespace LeetCodes.Terminal;

internal class Program
{
    static void Main(string[] args)
    {
        DisplayMenu();
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        
        Console.WriteLine("LeetCodes Terminal");
        
        Console.WriteLine("====================================");
        
        Console.WriteLine("1. Two Sum");
        
        Console.WriteLine("====================================");
        
        Console.WriteLine("Select an option:");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var option))
        {
            Run(option);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void Run(int option)
    {
        Console.Clear();
        switch (option)
        {
            case 1:
                const int target = 752;
                var twoSum = new TwoSumSolution(target);
                twoSum.Run();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        DisplayMenu();
    }
}

