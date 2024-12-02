public class Day2
{
    public static void Main(params string[] args)
    {
        var input = File.ReadAllText("inputs/day2.txt");

        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
            .ToArray();

        var answer = lines.Where(IsSafe).Count();

        Console.WriteLine(answer);

        answer = lines.Where(IsSafeWithProblemDampener).Count();

        Console.WriteLine(answer);
    }

    private static bool IsSafe(int[] input)
    {
        bool isReverse = input[0] > input[1];
        for (int i = 0; i < input.Length - 1; i++)
        {
            var current = input[i];
            var next = input[i + 1];

            if (Math.Abs(current - next) is < 1 or > 3)
            {
                return false;
            }

            if (current > next != isReverse)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsSafeWithProblemDampener(int[] input)
    {
        var inputList = new List<int>(input);
        bool isReverse = inputList[0] > inputList[1];
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            var current = inputList[i];
            var next = inputList[i + 1];

            if (Math.Abs(current - next) is < 1 or > 3)
            {
                return ProblemDampener(input, i);
            }

            if (current > next != isReverse)
            {
                return ProblemDampener(input, i);
            }
        }

        return true;
    }

    private static bool ProblemDampener(int[] input, int i)
    {
        var newListOne = new List<int>(input);
        newListOne.RemoveAt(i);
        if (IsSafe(newListOne.ToArray()))
        {
            return true;
        }

        var newListTwo = new List<int>(input);
        newListTwo.RemoveAt(i + 1);
        if (IsSafe(newListTwo.ToArray()))
        {
            return true;
        }

        if (i > 0)
        {
            var newListThree = new List<int>(input);
            newListThree.RemoveAt(i - 1);
            if (IsSafe(newListThree.ToArray()))
            {
                return true;
            }
        }

        return false;
    }
}