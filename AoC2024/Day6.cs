public static class Day6
{
    public static void Main(params string[] args)
    {
        //var input =
        //    """
        //    ....#.....
        //    .........#
        //    ..........
        //    ..#.......
        //    .......#..
        //    ..........
        //    .#..^.....
        //    ........#.
        //    #.........
        //    ......#...
        //    """;

        var input = File.ReadAllText("inputs/day6.txt").Trim();

        var map = input.Split(Environment.NewLine).Select(i => i.ToList()).ToList();

        var currentY = map.FindIndex(row => row.Any(tile => tile == '^'));
        var currentX = map[currentY].IndexOf('^');

        var rowLength = map[0].Count - 1;
        var columnLength = map.Count - 1;
        var currentDirection = "up";
        List<(int, int)> tilesVisited = Walk(currentX, rowLength, currentY, columnLength, currentDirection, map);

        Console.WriteLine(tilesVisited.Distinct().Count());
        var options = 0;

        for (int i = 0; i < map.Count; i++)
        {
            var row = map[i];

            for (int j = 0; j < row.Count; j++)
            {
                if (map[i][j] == '.')
                {
                    var newMap = new List<List<char>>(map.Select(r => new List<char>(r)));
                    newMap[i][j] = '#';
                    currentDirection = "up";
                    var isStuck = WalkStuck(currentX, rowLength, currentY, columnLength, currentDirection, newMap);
                    if (!isStuck)
                    {
                        options++;
                    }
                }
            }
        }
        Console.WriteLine(options);
    }

    private static List<(int, int)> Walk(int currentX, int rowLength, int currentY, int columnLength, string currentDirection, List<List<char>> map)
    {
        var tilesVisited = new List<(int,int)>();

        while (currentX <= rowLength && currentY <= columnLength && currentX >= 0 && currentY >= 0 && tilesVisited.Count < rowLength * columnLength)
        {
            switch (currentDirection)
            {
                case "up" when currentY > 0 && map[currentY-1][currentX] != '#':
                case "up" when currentY == 0:
                    tilesVisited.Add((currentX, currentY));
                    currentY--;
                    break;
                case "down" when currentY < columnLength && map[currentY+1][currentX] != '#':
                case "down" when currentY == columnLength:
                    tilesVisited.Add((currentX, currentY));
                    currentY++;
                    break;
                case "left" when currentX > 0 && map[currentY][currentX-1] != '#':
                case "left" when currentX == 0:
                    tilesVisited.Add((currentX, currentY));
                    currentX--;
                    break;
                case "right" when currentX < rowLength && map[currentY][currentX+1] != '#':
                case "right" when currentX == rowLength:
                    tilesVisited.Add((currentX, currentY));
                    currentX++;
                    break;
                case "up" when map[currentY-1][currentX] == '#':
                    currentDirection = "right";
                    break;
                case "down" when map[currentY + 1][currentX] == '#':
                    currentDirection = "left";
                    break;
                case "left" when map[currentY][currentX-1] == '#':
                    currentDirection = "up";
                    break;
                case "right" when map[currentY][currentX + 1] == '#':
                    currentDirection = "down";
                    break;
            }
        }

        return tilesVisited;
    }
    private static bool WalkStuck(int currentX, int rowLength, int currentY, int columnLength, string currentDirection, List<List<char>> map)
    {
        var directionChanges = 0;
        while (currentX <= rowLength && currentY <= columnLength && currentX >= 0 && currentY >= 0 && directionChanges < 3000)
        {
            switch (currentDirection)
            {

                case "up" when currentY > 0 && map[currentY - 1][currentX] != '#':
                case "up" when currentY == 0:
                    currentY--;
                    break;
                case "down" when currentY < columnLength && map[currentY + 1][currentX] != '#':
                case "down" when currentY == columnLength:
                    currentY++;
                    break;
                case "left" when currentX > 0 && map[currentY][currentX - 1] != '#':
                case "left" when currentX == 0:
                    currentX--;
                    break;
                case "right" when currentX < rowLength && map[currentY][currentX + 1] != '#':
                case "right" when currentX == rowLength:
                    currentX++;
                    break;
                case "up" when map[currentY - 1][currentX] == '#':
                    currentDirection = "right";
                    directionChanges++;
                    break;
                case "down" when map[currentY + 1][currentX] == '#':
                    currentDirection = "left";
                    directionChanges++;
                    break;
                case "left" when map[currentY][currentX - 1] == '#':
                    currentDirection = "up";
                    directionChanges++;
                    break;
                case "right" when map[currentY][currentX + 1] == '#':
                    currentDirection = "down";
                    directionChanges++;
                    break;
            }
        }

        return directionChanges < 3000;
    }
}