Console.WriteLine("Hello day 2");

var lines = File.ReadAllLines("input.txt");
var safeCount = 0;

static bool TestList(List<int> list)
{
    bool isSorted = list.SequenceEqual(list.OrderBy(x => x)) || list.SequenceEqual(list.OrderByDescending(x => x));
    if (!isSorted)
        return false;

    for (int i = 0; i < list.Count - 1; i++)
    {
        var difference = Math.Abs(list[i] - list[i + 1]);
        if (difference > 3 || difference < 1)
            return false;
    }

    return true;
}

static bool TestListWithOmissions(List<int> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        var templist = list.ToList();
        templist.RemoveAt(i);
        var isfixable = TestList(templist);
        if (isfixable)
        {
            return true;
        }
    }

    return false;
}

foreach (var line in lines)
{
    var parts = line.Split(" ").Select(int.Parse).ToList();

    var isSafe = TestList(parts);

    if (!isSafe)
    {
        isSafe = TestListWithOmissions(parts);
    }

    if (isSafe)
    {
        safeCount++;
    }

    Console.WriteLine(line + " is " + isSafe);
}

Console.WriteLine("Safe count: " + safeCount);