namespace LeetCodes.Terminal.BackTracking;

public class BackTrackingSolutions
{
    private readonly Dictionary<int, string[]> _digitToLetters = new()
    {
        { 2, ["a", "b", "c"]},
        { 3, ["d", "e", "f"]},
        { 4, ["g", "h", "i"]},
        { 5, ["j", "k", "l"]},
        { 6, ["m", "n", "o"]},
        { 7, ["p", "q", "r", "s"]},
        { 8, ["t", "u", "v"]},
        { 9, ["w", "x", "y", "z"]}
    };
    
    private readonly IList<string> _combinations = [];

    /// <summary>
    /// Esse método é o ponto de entrada para gerar todas as combinações de letras a partir de um array de números.
    /// Anotação: O array de números deve conter apenas números entre 2 e 9.
    /// BIG O Notation: O(3^n * 4^m) onde n é o número de dígitos que tem 3 letras e m é o número de dígitos que tem 4 letras.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private string[] LetterCombinations(int[] nums)
    {
        if (nums.Length == 0) 
            return [];
        
        Backtrack("", nums, 0);
        return _combinations.ToArray();
    }

    /// <summary>
    /// Recursividade para gerar todas as combinações de letras.
    /// Ele faz isso através de backtracking, ou seja, ele vai adicionando letras e quando chega no tamanho máximo ele adiciona a combinação na lista.
    /// Permutation é a combinação atual, digits são os números que foram passados e index é o índice atual.
    /// </summary>
    private void Backtrack(string permutation, int[] digits, int index)
    {
        if (index == digits.Length)
        {
            _combinations.Add(permutation);
            return;
        }

        var digit = digits[index];
        var letters = _digitToLetters[digit];

        foreach (var letter in letters)
        {
            Backtrack(permutation + letter, digits, index + 1);
        }
    }
    
    public static void Run()
    {
        Console.WriteLine("Backtracking Problem");
        Console.WriteLine("====================================");
        
        var backTracking = new BackTrackingSolutions();
        var result = backTracking.LetterCombinations([2, 3]);
        
        Console.WriteLine($"The letter combinations are: {string.Join(", ", result)}");
    }
}