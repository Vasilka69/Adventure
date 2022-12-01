
using System.Collections;
using System.Runtime.CompilerServices;

public class Day1
{
    static List<int> sums;
    public static void Main()
    {
        string path = "input.txt";
        string[] input = File.ReadAllText(path).Split("\r\n");
        sums = new List<int>();
        int currSum = 0;
        foreach (string row in input)
        {
            if (row != "")
                currSum += int.Parse(row);
            else
            {
                sums.Add(currSum);
                currSum = 0;
            }
        }
        
        foreach (int cal in sums)
            Console.WriteLine(cal);
        Console.WriteLine();

        //PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        int maxCal = sums[0];
        foreach (int cal in sums)
            if (cal > maxCal)
                maxCal = cal;
        Console.WriteLine(maxCal);
    }

    public static void PartTwo()
    {
        int[] topCals = new int[3];
        int topMin = topCals[0];
        foreach (int cal in sums)
            if (cal > topMin)
                for (int i = 0; i < topCals.Length; i++)
                {
                    if (topCals[i] == topMin)
                    {
                        topCals[i] = cal;
                        topMin = topCals[0];
                        foreach (int topCal in topCals)
                            if (topCal < topMin)
                                topMin = topCal;
                        break;
                    }
                }
        int sumTops = 0;
        foreach (int cal in topCals)
            sumTops += cal;
        Console.WriteLine(sumTops);

    }
}
