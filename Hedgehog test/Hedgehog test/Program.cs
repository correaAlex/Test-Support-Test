using System;
using System.Reflection;
using System.Text.RegularExpressions;

public class HedgehogTest
{
    static void Main()
    {
        // color = 2, {0, 0, 9} => 0
        // color = 0 or 1 or 2, {8, 1, 9} => -1
        // color = 1, {8, 10, 8} => 8
        Console.WriteLine(Monochromatize(1, new int[] { 8, 10, 8 }));
        Console.ReadLine();
    }

    /// <summary>
    /// Makes all of the hedgehogs the same colour
    /// </summary>
    /// <param name="color">Color from 0 to 2</param>
    /// <param name="hedgehogs">An array of positive integers with length 3</param>
    /// <returns>Returns an integer. -1 if it fails to get them all to the same colour, otherwise the number of iterations.</returns>
    static int Monochromatize(int color, IEnumerable<int> hedgehogs)
    {
        if (hedgehogs.Count() != 3)
            return -1;

        if (color < 0 || color > 2)
            return -1;

        if (hedgehogs.Where(e => e < 0).Any())
            return -1;

        int sum = hedgehogs.Sum();
        if (sum < 1 || sum > int.MaxValue)
            return -1;

        if (hedgehogs.ElementAt(color) == sum)
            return 0;

        int a, b;
        int c = hedgehogs.ElementAt(color);
        int index = 0;
        if (color == 0)
        {
            a = hedgehogs.ElementAt(1);
            b = hedgehogs.ElementAt(2);
        }
        else if (color == 1)
        {
            a = hedgehogs.ElementAt(0);
            b = hedgehogs.ElementAt(2);
        }
        else
        {
            a = hedgehogs.ElementAt(0);
            b = hedgehogs.ElementAt(1);
        }
        if (a <= 0 || b <= 0)
            return -1;

        while (a > 0)
        {
            a--;
            b--;
            c += 2;
            index++;
        }
        if (c != sum)
            return -1;

        return index;
    }
}
