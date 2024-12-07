public static class Day7
{
    public static void Main(params string[] args)
    {
    //    var input =
    //        """
    //        190: 10 19
    //        3267: 81 40 27
    //        83: 17 5
    //        156: 15 6
    //        7290: 6 8 6 15
    //        161011: 16 10 13
    //        192: 17 8 14
    //        21037: 9 7 18 13
    //        292: 11 6 16 20
    //        """;
        var input = File.ReadAllText("inputs/day7.txt").Trim();

        var inputLines = input.Trim().Split(Environment.NewLine);
        var problems = inputLines
            .Select(line => line.Split(':'))
            .Select(line => (problem: long.Parse(line[0]), inputNumbers: line[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()))
            .ToArray();

        var result = problems.Where(problem => PossibleSums(problem.inputNumbers).Contains(problem.problem))
            .Sum(item => item.problem);

        Console.WriteLine(result);
    }

    public static List<long> PossibleSums(long[] inputNumbers)
    {
        List<long> results = new List<long>();

        Calculate(inputNumbers, 0, inputNumbers[0], results);

        return results;
    }

    static void Calculate(long[] numbers, int index, long currentSum, List<long> results)
    {
        if (index == numbers.Length - 1)
        {
            results.Add(currentSum);
            return;
        }

        int nextIndex = index + 1;

        Calculate(numbers, nextIndex, currentSum + numbers[nextIndex], results);

        Calculate(numbers, nextIndex, currentSum * numbers[nextIndex], results);

        Calculate(numbers, nextIndex, long.Parse($"{currentSum}{numbers[nextIndex]}"), results);
    }
}