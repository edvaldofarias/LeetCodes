namespace LeetCodes.Terminal.HammingWeight;

public class HammingWeightSolutions
{
    /// <summary>
    /// Calcula o número de bits 1 em um número inteiro sem sinal.
    /// 
    /// </summary>
    private static int HammingWeight(uint number)
    {
        var count = 0;
        while (number > 0)
        {
            count += (int)number & 1;
            number >>= 1;
        }
        return count;
    }

    /// <summary>
    /// Calcula o número de bits 1 em um número inteiro.
    /// Usando a divisão por 2.
    /// </summary>
    private static int CountBits(int number)
    {
        var count = 0;

        while (number > 0)
        {
            if(number % 2 == 1)
                count++;
            
            number /= 2;
        }
        return count;
    }
    
    public static void Run()
    {
        Console.WriteLine("Hamming Weight Problem");
        Console.WriteLine("====================================");
        
        const int number = 37; // 100101
        var result = HammingWeight(number);
        var result2 = CountBits(number);
        
        Console.WriteLine($"The number of 1 bits in {number} is: {result2}");
        Console.WriteLine($"The number of 1 bits in {number} is: {result}");
    }
}