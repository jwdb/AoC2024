var input = File.ReadAllText("day1.txt");

var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
    .ToArray();
    
var left = lines.Select(line  => int.Parse(line[0])).ToList();
var right = lines.Select(line => int.Parse(line[1])).ToList();
var answer = 0;
Console.WriteLine($"Day 1: {string.Join(" ", left)}");
while (left.Count > 0 && right.Count > 0)
{
    var leftMin = left.Min();
    var rightMin = right.Min();
    var difference = Math.Abs(leftMin - rightMin);
    answer += difference;
    left.Remove(leftMin);
    right.Remove(rightMin);
}

Console.WriteLine(answer);

answer = 0;
left = lines.Select(line  => int.Parse(line[0])).ToList();
right = lines.Select(line => int.Parse(line[1])).ToList();

foreach (var m in left)
{
    var rightCount = right.Count(c => c == m);
    answer += m * rightCount;
}

Console.WriteLine(answer);