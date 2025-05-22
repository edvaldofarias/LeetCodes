using System.Diagnostics;

namespace LeetCodes.Terminal.TwoSum;

public class TwoSumSolution(int target)
{
    private readonly int[] _numbers = GenerateRandomArray(100000, 1, 10000);

    /// <summary>
    /// Ele é muito escalavavel, porém ele consome mais memória pois ele armazena os números e os indices em um dicionário.
    /// Incluir, remover e buscar em um dicionário é mais lento em comparação a um array.
    /// Depende do tamanho do array, o dicionário pode ser mais lento.
    /// </summary>
    private int[] TwoSumHash()
    {
        var numIndices = new Dictionary<int, int>();

        for (var i = 0; i < _numbers.Length; i++)
        {
            var complement = target - _numbers[i];

            if (numIndices.TryGetValue(complement, out var value))
            {
                return new int[] { value, i };
            }

            if (!numIndices.ContainsKey(_numbers[i]))
            {
                numIndices[_numbers[i]] = i;
            }
        }

        throw new ArgumentException("No two sum solution");
    }

    /// <summary>
    /// Formato mais simples, porém ele é O(n2) e não é escalável.
    /// Ele pode ser mais rápido em arrays pequenos, pois não precisa de dicionário.
    /// Mas ele não é escalável, pois ele tem que fazer duas iterações.
    /// </summary>
    private int[] TwoSumBruteForce()
    {
        for (var i = 0; i < _numbers.Length; i++)
        {
            for (var j = i + 1; j < _numbers.Length; j++)
            {
                if (_numbers[i] + _numbers[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        throw new ArgumentException("No two sum solution");
    }
    
    public static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        var random = new Random();
        var result = new int[size];

        for (var i = 0; i < size; i++)
        {
            result[i] = random.Next(minValue, maxValue + 1);
        }

        return result;
    }

    public void Run()
    {
        var stopwatch = new Stopwatch();
        
        Console.WriteLine("Starting Two Sum Problem");
        Console.WriteLine("====================================");
        Console.WriteLine($"Array Size: {_numbers.Length}");
        Console.WriteLine($"Target: {target}");
        Console.WriteLine("====================================");


        Console.WriteLine("Running Two Sum Solutions...");
        Console.WriteLine("====================================");  
        Console.WriteLine("Two Sum Hash - O(n)");
        stopwatch.Start();
        var result = TwoSumHash();
        stopwatch.Stop();
        Console.WriteLine($"Two Sum Hash: [{result[0]}, {result[1]}]");
        
        PrintResult(result, stopwatch);


        stopwatch.Reset();
        Console.WriteLine("====================================");
        Console.WriteLine("Two Sum Brute Force - O(n2)");
        stopwatch.Start();
        result = TwoSumBruteForce();
        stopwatch.Stop();
        Console.WriteLine($"Two Sum Brute Force: [{result[0]}, {result[1]}]");
        
        PrintResult(result, stopwatch);
    }
    
    private void PrintResult(int[] result, Stopwatch stopwatch)
    {
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Two Sum: [{result[0]}, {result[1]}]");
        var numberOne = _numbers[result[0]];
        var numberTwo = _numbers[result[1]];
        Console.WriteLine($"Numbers: {numberOne} + {numberTwo} = {target}");
    }

}