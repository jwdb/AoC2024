public static class Day5
{

    public static void Main(params string[] args)
    {
        var input = File.ReadAllText("inputs/day5.txt");
        //var input =
        //    """
        //    47|53
        //    97|13
        //    97|61
        //    97|47
        //    75|29
        //    61|13
        //    75|53
        //    29|13
        //    97|29
        //    53|29
        //    61|53
        //    97|53
        //    61|29
        //    47|13
        //    75|47
        //    97|75
        //    47|61
        //    75|61
        //    47|29
        //    75|13
        //    53|13
            
        //    75,47,61,53,29
        //    97,61,53,29,13
        //    75,29,13
        //    75,97,47,61,53
        //    61,13,29
        //    97,13,75,29,47
        //    """;

        var rules = input.Split(Environment.NewLine + Environment.NewLine)[0];
        var manuals = input.Split(Environment.NewLine + Environment.NewLine)[1];

        var rulesPerPage = rules
            .Split(Environment.NewLine)
            .Select(item => item.Split('|'))
            .GroupBy(item => item[0])
            .ToDictionary(
                item => item.Key,
                item => item.Select(m => m[1]).Distinct().ToArray()
            );
        var manualsSplit = manuals.Split(Environment.NewLine);
        Part1(manualsSplit, rulesPerPage);
        Part2(manualsSplit, rulesPerPage);
    }

    private static void Part1(string[] manualsSplit, Dictionary<string, string[]> rulesPerPage)
    {
        var result = 0;
        foreach (string manual in manualsSplit)
        {
            bool valid = true;
            var pages = manual.Split(",");

            for (int i = 0; i < pages.Length; i++)
            {
                var page = pages[i];

                if (rulesPerPage.ContainsKey(page) && rulesPerPage[page].Any(p => pages[..i].Any(item => item == p)))
                {
                    valid = false;
                }
            }

            if (valid)
            {
                result += int.Parse(pages[pages.Length / 2]);
            }
        }

        Console.WriteLine(result);
    }


    private static void Part2(string[] manualsSplit, Dictionary<string, string[]> rulesPerPage)
    {
        var result = 0;
        foreach (string manual in manualsSplit)
        {
            bool valid = true;
            var pages = manual.Split(",").ToList();

            for (int i = 0; i < pages.Count; i++)
            {
                var page = pages[i];

                if (rulesPerPage.ContainsKey(page) && rulesPerPage[page].Any(p => pages[..i].Any(item => item == p)))
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                pages.Sort(Comparer<string>.Create((a,b) =>
                {
                    return rulesPerPage.ContainsKey(b) && rulesPerPage[b].Any(item => item == a) ? 1 : -1;
                }));
                result += int.Parse(pages[pages.Count / 2]);
            }
        }

        Console.WriteLine(result);
    }
}
