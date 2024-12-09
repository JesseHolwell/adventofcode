// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, day 5!");


var lines = File.ReadAllLines("input.txt");

var rules = lines.Take(1176);
var updates = lines.Skip(1177).Take(1361 - 1178);

var output = 0;

Console.WriteLine("Rules: " + rules.Count() + " Updates: " + updates.Count());

var rulepairs = rules.Select(x => x.Split('|').Select(y => int.Parse(y)).ToList()).ToList();

static bool CheckCorrectness(List<int> input, List<List<int>> rulePairs)
{
    var isCorrect = true;

    foreach (var rulepair in rulePairs)
    {
        if (input.Contains(rulepair[0]))
        {
            if (input.Contains(rulepair[1]))
            {
                if (input.IndexOf(rulepair[0]) > input.IndexOf(rulepair[1]))
                    isCorrect = false;
            }
        }
    }

    return isCorrect;
}

foreach (var update in updates)
{
    var numbers = update.Split(',').Select(x => int.Parse(x)).ToList();

    var isCorrect = CheckCorrectness(numbers, rulepairs);

    if (isCorrect)
    {
        var middleNumber = numbers[numbers.Count() / 2];
        output += middleNumber;
    }
}

Console.WriteLine("Output: " + output);
