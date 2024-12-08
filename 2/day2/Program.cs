Console.WriteLine("Hello day 2");

var lines = File.ReadAllLines("input.txt");
var safeCount = 0;

foreach (var line in lines)
{
    var parts = line.Split(" ").Select(int.Parse).ToList();

    bool isSorted = parts.SequenceEqual(parts.OrderBy(x => x));

    var isSafe = isSorted;

    for (var i = 1; i < parts.Count; i++)
    {
        if (Math.Abs(parts[i] - parts[i + 1]) > 2)
        {
            isSafe = false;
            return;
        }
    }

    if (isSafe)
    {
        safeCount++;
    }

}

Console.WriteLine("Safe count: " + safeCount);