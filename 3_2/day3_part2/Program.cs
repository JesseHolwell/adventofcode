// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello day 3!");

var lines = File.ReadAllLines("input.txt");

Console.WriteLine("lines count: " + lines.Count());

var total = 0;

bool processNext = true;

//numbers are 1 to 3 characers

foreach (var line in lines)
{
    for (var i = 0; i < line.Length; i++)
    {
        try
        {
            if (line.Substring(i, 4) == "do()")
            {
                processNext = true;
            }
        }
        catch (Exception ex)
        {

        }

        try
        {
            if (line.Substring(i, 7) == "don't()")
            {
                processNext = false;
            }
        }
        catch (Exception ex)
        {

        }

        if (processNext)
        {
            if (line[i] == 'm' && line[i + 1] == 'u' && line[i + 2] == 'l' && line[i + 3] == '(')
            {
                //max length (3 each) is 12
                //mul(123,123)

                //lets just get (123,123) or (1,2)junk or (1,2)jun)
                //then split off the end

                try
                {
                    var starthere = i + 4;
                    var getthismuch = 12 - 3;
                    if (line.Substring(starthere).Length < getthismuch)
                        getthismuch = line.Substring(starthere).Length;

                    var substring = line.Substring(starthere, getthismuch).Split(")")[0];
                    Console.Write("\nsub " + substring);

                    if (substring.Count(x => x == ',') == 1)
                    {
                        var couple = substring.Split(",").Select(x => int.Parse(x)).ToList();

                        total += couple[0] * couple[1];
                        Console.Write("\t" + couple[0] + " " + couple[1]);

                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write("\tfailed " + ex.Message);

                    //do nothing
                }
            }
        }
        // Console.Write("\n");

    }
}

Console.WriteLine();
Console.WriteLine(total);