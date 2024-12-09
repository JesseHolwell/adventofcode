// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, day 4!");

var lines = File.ReadAllLines("input.txt");

var numberOfHits = 0;

foreach (var (line, y) in lines.Select((value, i) => (value, i)))
{
    foreach (var (character, x) in line.Select((value, i) => (value, i)))
    {

        //if we find an X
        // if (character == 'X')
        // {

        //yeah this is not clean at all

        bool hit = false;

        try
        {
            //right
            if (line[x] == 'X' && line[x + 1] == 'M' && line[x + 2] == 'A' && line[x + 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //left
            if (line[x] == 'X' && line[x - 1] == 'M' && line[x - 2] == 'A' && line[x - 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //up
            if (lines[y][x] == 'X' && lines[y - 1][x] == 'M' && lines[y - 2][x] == 'A' && lines[y - 3][x] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //down
            if (lines[y][x] == 'X' && lines[y + 1][x] == 'M' && lines[y + 2][x] == 'A' && lines[y + 3][x] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //upleft
            if (lines[y][x] == 'X' && lines[y - 1][x - 1] == 'M' && lines[y - 2][x - 2] == 'A' && lines[y - 3][x - 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //upright
            if (lines[y][x] == 'X' && lines[y - 1][x + 1] == 'M' && lines[y - 2][x + 2] == 'A' && lines[y - 3][x + 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //downright
            if (lines[y][x] == 'X' && lines[y + 1][x + 1] == 'M' && lines[y + 2][x + 2] == 'A' && lines[y + 3][x + 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }
        try
        {
            //downleft
            if (lines[y][x] == 'X' && lines[y + 1][x - 1] == 'M' && lines[y + 2][x - 2] == 'A' && lines[y + 3][x - 3] == 'S')
            {
                hit = true;
                numberOfHits++;
            }
        }
        catch (Exception ex)
        {
            // do nothing
        }

        if (hit == true)
        {
            // numberOfHits++;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
        }

        Console.Write(lines[y][x]);
        Console.ResetColor();
    }

    Console.WriteLine();
}

Console.WriteLine("Number of hits: " + numberOfHits);