// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, day 5 part 2!");

var lines = File.ReadAllLines("input.txt");

var rules = lines.Take(1176);
var updates = lines.Skip(1177).Take(1362 - 1178);

var output = 0;

Console.WriteLine("Rules: " + rules.Count() + " Updates: " + updates.Count());

var rulepairs = rules.Select(x => x.Split('|').Select(y => int.Parse(y)).ToList()).ToList();

static List<int>? FixCorrectness(List<int> input, List<List<int>> rulePairs)
{
    foreach (var rulepair in rulePairs)
    {
        if (input.Contains(rulepair[0]) && input.Contains(rulepair[1]))
        {
            if (input.IndexOf(rulepair[0]) > input.IndexOf(rulepair[1]))
            {
                Swap(input, input.IndexOf(rulepair[0]), input.IndexOf(rulepair[1]));
            }
        }
    }

    return input;

}

static bool CheckCorrectness(List<int> input, List<List<int>> rulePairs)
{
    var isCorrect = true;

    foreach (var rulepair in rulePairs)
    {
        if (input.Contains(rulepair[0]) && input.Contains(rulepair[1]))
        {
            // Console.Write(rulepair[0] + "|" + rulepair[1] + " ");
            if (input.IndexOf(rulepair[0]) > input.IndexOf(rulepair[1]))
                isCorrect = false;

        }
    }

    // Console.WriteLine();

    return isCorrect;
}

static void Swap<T>(List<T> list, int index1, int index2)
{
    // Ensure indices are valid
    if (index1 >= 0 && index2 >= 0 && index1 < list.Count && index2 < list.Count)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
    else
    {
        Console.WriteLine("Invalid indices provided.");
    }
}

foreach (var update in updates)
{
    var numbers = update.Split(',').Select(x => int.Parse(x)).ToList();
    var attempts = 0;
    List<int>? updatedInput = null;

    while (CheckCorrectness(numbers, rulepairs) == false)
    {
        numbers.ForEach(i => Console.Write("{0} ", i));
        Console.WriteLine("Attempt {0}", attempts);

        updatedInput = FixCorrectness(numbers, rulepairs);
        attempts++;
    }

    if (updatedInput != null)
    {
        updatedInput.ForEach(i => Console.Write("{0} ", i));
        Console.WriteLine("Attempt final");

        var middleNumber = updatedInput[updatedInput.Count() / 2];
        output += middleNumber;
        Console.WriteLine("middle {0}", middleNumber);
    }
}

Console.WriteLine("Output: " + output);
