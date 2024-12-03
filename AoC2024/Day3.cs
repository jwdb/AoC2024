using System.Text.RegularExpressions;

public partial class Day3
{
    public static void Main(params string[] args)
    {
        //var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var input = File.ReadAllText("inputs/day3.txt");

        var regex = partOneRegex();
        
        var result = MatchRegex(regex, input);

        Console.WriteLine(result);

        //var input2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var input2 = File.ReadAllText("inputs/day3.txt");
        var strings = ("do()" + input2).Split("don\'t()");
        var newInput = new String(strings.SelectMany(part => part.SkipWhile((_, i) => i < 4 || part[(i - 4)..i] != "do()")).ToArray());
        result = MatchRegex(regex, newInput);

        Console.WriteLine(result);
    }

    private static int MatchRegex(Regex regex, string input)
    {
        var results = regex.Matches(input);
        var result = 0;
        foreach (Match match in results)
        {
            var value = match.Value;
            Console.WriteLine(value);
            var numbers = value.Substring(4, value.Length - 5).TrimEnd(')').Split(',').Select(int.Parse).ToArray(); 
            result += numbers[0] * numbers[1];
        }

        return result;
    }

    [GeneratedRegex(@"(mul\(\d+?,\d+?\))")]
    private static partial Regex partOneRegex();
}