public static class Day4
{
    public static void Main(params string[] args)
    {
        var input = File.ReadAllText("inputs/day4.txt");
        //var input =
        //    """
        //    MMMSXXMASM
        //    MSAMXMSMSA
        //    AMXSXMAAMM
        //    MSAMASMSMX
        //    XMASAMXAMM
        //    XXAMMXXAMA
        //    SMSMSASXSS
        //    SAXAMASAAA
        //    MAMMMXMMMM
        //    MXMXAXMASX
        //    """.Trim();

        //var input =
        //    """
        //    X..X
        //    .MM.
        //    .AA.
        //    S..S
        //    XMAS
        //    SAMX
        //    S..S
        //    .AA.
        //    .MM.
        //    X..X
        //    """;

        var rowLength = input.Split(Environment.NewLine)[0].Length + Environment.NewLine.Length;
        var totalRows = input.Split(Environment.NewLine).Length - 1;
        var result = 0;
        for (var i = 0; i < input.Length; i++)
        {
                result += SearchXmas(input, rowLength, totalRows, i);
        }

        Console.WriteLine(result);

        //var input2 =
        //    """
        //    .M.S......
        //    ..A..MSMS.
        //    .M.S.MAA..
        //    ..A.ASMSM.
        //    .M.S.M....
        //    ..........
        //    S.S.S.S.S.
        //    .A.A.A.A..
        //    M.M.M.M.M.
        //    ..........
        //    """.Trim();

        var input2 = input;

        //var input2 =
        //    """
        //    M.M
        //    .A.
        //    S.S
        //    S.M
        //    .A.
        //    S.M
        //    S.S
        //    .A.
        //    M.M
        //    M.S
        //    .A.
        //    M.S
        //    """;
        rowLength = input2.Split(Environment.NewLine)[0].Length + Environment.NewLine.Length;
        totalRows = input2.Split(Environment.NewLine).Length - 1;
        result = 0;
        for (var i = 0; i < input2.Length; i++)
        {
            result += SearchX_mas(input2, rowLength, totalRows, i);
        }
        Console.WriteLine(result);
    }

    private static int SearchXmas(string input, int rowLength, int totalRows, int currentPosition)
    {
        int currentPositionInRow = currentPosition % rowLength;
        int currentRow = (int)Math.Round((decimal)currentPosition / rowLength, MidpointRounding.ToZero);
        char currentChar = input[currentPosition];
        var hits = 0;

        if (currentChar != 'X')
        {
            return hits;
        }
        if (currentPosition + 3 < input.Length && rowLength - currentPositionInRow > 3 && input[currentPosition..(currentPosition+4)] == "XMAS")
        {
            hits++;
        }

        if (currentPositionInRow >= 3 && input[(currentPosition - 3)..(currentPosition + 1)] == "SAMX")
        {
            hits++;
        }

        if (currentRow > 2)
        {
            if (currentPositionInRow > 2 && input[currentPosition - rowLength - 1] == 'M')
            {
                if (input[currentPosition - rowLength * 2 - 2] == 'A')
                {
                    if (input[currentPosition - rowLength * 3 - 3] == 'S')
                    {
                        hits++;
                    }
                }
            }

            if (rowLength - currentPositionInRow > 3 && input[currentPosition - rowLength + 1] == 'M')
            {
                if (input[currentPosition - rowLength * 2 + 2] == 'A')
                {
                    if (input[currentPosition - rowLength * 3 + 3] == 'S')
                    {
                        hits++;
                    }
                }
            }


            if (input[currentPosition - rowLength] == 'M')
            {
                if (input[currentPosition - rowLength * 2] == 'A')
                {
                    if (input[currentPosition - rowLength * 3] == 'S')
                    {
                        hits++;
                    }
                }
            }
        }

        if (totalRows - currentRow >= 3)
        {
            if (currentPositionInRow > 2 && input[currentPosition + rowLength - 1] == 'M')
            {
                if (input[currentPosition + rowLength * 2 - 2] == 'A')
                {
                    if (input[currentPosition + rowLength * 3 - 3] == 'S')
                    {
                        hits++;
                    }
                }
            }

            if (rowLength - currentPositionInRow > 3 && input[currentPosition + rowLength + 1] == 'M')
            {
                if (input[currentPosition + rowLength * 2 + 2] == 'A')
                {
                    if (input[currentPosition + rowLength * 3 + 3] == 'S')
                    {
                        hits++;
                    }
                }
            }


            if (input[currentPosition + rowLength] == 'M')
            {
                if (input[currentPosition + rowLength * 2] == 'A')
                {
                    if (input[currentPosition + rowLength * 3] == 'S')
                    {
                        hits++;
                    }
                }
            }
        }

        return hits;
    }


    private static int SearchX_mas(string input, int rowLength, int totalRows, int currentPosition)
    {
        int currentPositionInRow = currentPosition % rowLength;
        int currentRow = (int)Math.Round((decimal)currentPosition / rowLength, MidpointRounding.ToZero);
        char currentChar = input[currentPosition];
        var hits = 0;

        if (currentChar != 'A')
        {
            return hits;
        }

        if (currentRow >= 1 && currentRow < totalRows && currentPositionInRow > 0 && rowLength - currentPositionInRow > 1)

        {
            if (input[currentPosition - rowLength - 1] == 'M')
            {
                if (input[currentPosition - rowLength + 1] == 'S')
                {
                    if (input[currentPosition + rowLength - 1] == 'M')
                    {
                        if (input[currentPosition + rowLength + 1] == 'S')
                        {
                            hits++;
                        }
                    }
                }
            }


            if (input[currentPosition - rowLength - 1] == 'S')
            {
                if (input[currentPosition - rowLength + 1] == 'M')
                {
                    if (input[currentPosition + rowLength - 1] == 'S')
                    {
                        if (input[currentPosition + rowLength + 1] == 'M')
                        {
                            hits++;
                        }
                    }
                }
            }
            if (input[currentPosition - rowLength - 1] == 'M')
            {
                if (input[currentPosition - rowLength + 1] == 'M')
                {
                    if (input[currentPosition + rowLength - 1] == 'S')
                    {
                        if (input[currentPosition + rowLength + 1] == 'S')
                        {
                            hits++;
                        }
                    }

                }
            }

            if (input[currentPosition - rowLength - 1] == 'S')
            {
                if (input[currentPosition - rowLength + 1] == 'S')
                {
                    if (input[currentPosition + rowLength - 1] == 'M')
                    {
                        if (input[currentPosition + rowLength + 1] == 'M')
                        {
                            hits++;
                        }
                    }
                }
            }
        }

        return hits;
    }
}