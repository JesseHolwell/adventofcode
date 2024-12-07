

var arr1 = new List<int>();
var arr2 = new List<int>();
var lines = File.ReadAllLines("input.txt");
var score = 0;

var dictionary = new Dictionary<int, int>();

foreach (var line in lines)
{
    var parts = line.Split("   ");
    dictionary.Add(int.Parse(parts[0]), 0);
    arr2.Add(int.Parse(parts[1]));
}

foreach (var item in arr2)
{
    if (dictionary.ContainsKey(item))
        dictionary[item] = dictionary[item] + 1;
}

foreach (var (key, value) in dictionary)
{
    score += key * value;
}

Console.WriteLine("Similarity score: " + score);
