
using System.Collections.Immutable;

var arr1 = new List<int>();
var arr2 = new List<int>();
var lines = File.ReadAllLines("input.txt");
var distance = 0;

foreach (var line in lines)
{
    var parts = line.Split("   ");
    arr1.Add(int.Parse(parts[0]));
    arr2.Add(int.Parse(parts[1]));
}

arr1.Sort();
arr2.Sort();

for (var v = 0; v < arr1.Count; v++)
{
    distance += Math.Abs(arr1[v] - arr2[v]);
}

Console.WriteLine("Distance: " + distance);