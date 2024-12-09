// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, day 4!");

var lines = File.ReadAllLines("input.txt");

var numberOfHits = 0;

foreach (var (line, y) in lines.Select((value, i) => (value, i)))
{
    foreach (var (character, x) in line.Select((value, i) => (value, i)))
    {
        try
        {
            if (lines[y][x] == 'A')
            {
                var corners = new[] { lines[y - 1][x - 1], lines[y + 1][x - 1], lines[y + 1][x + 1], lines[y - 1][x + 1] };

                if (corners.Count(x => x == 'M') == 2 && corners.Count(x => x == 'S') == 2)
                    if (corners[0] != corners[2] && corners[1] != corners[3])
                        numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }

    }
}

Console.WriteLine("Number of hits: " + numberOfHits);