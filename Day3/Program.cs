
using System.Collections;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

public class Day1
{
    static string[] input;
    public static void Main()
    {
        string path = "input.txt";
        input = File.ReadAllText(path).Split("\r\n");

        //PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        char[] repeats = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            string line = input[i];
            int half = line.Length / 2;
            string secHalf = line.Substring(half);
            for (int j = 0; j < half; j++)
            {
                if (secHalf.Contains(line[j]))
                {
                    repeats[i] = line[j];
                    break;
                }
            }
        }

        int lowOff = 96;
        int upOff = 38;
        int sum = 0;
        foreach (char i in repeats)
            sum += char.IsLower(i) == true ? (int)i - lowOff : (int)i - upOff;

        Console.WriteLine(sum);

    }

    public static void PartTwo()
    {
        char[] repeats = new char[input.Length / 3];
        int counter = 0;
        for (int i = 0; i < input.Length; i += 3)
        {
            string line = input[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (input[i + 1].Contains(line[j]) && input[i + 2].Contains(line[j]))
                {
                    repeats[counter++] = line[j];
                    break;
                }
            }
        }

        int lowOff = 96;
        int upOff = 38;
        int sum = 0;
        foreach (char i in repeats)
            sum += char.IsLower(i) == true ? (int)i - lowOff : (int)i - upOff;

        Console.WriteLine(sum);

    }

}
