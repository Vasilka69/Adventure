
using System.Collections;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

public class Day1
{
    static string[] input;

    static string[] oppCh;
    static string[] meCh;
    public static void Main()
    {
        string path = "input.txt";
        input = File.ReadAllText(path).Split("\r\n");
        oppCh = new string[] { "A", "B", "C" };
        meCh = new string[] { "X", "Y", "Z" };

        //PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        int score = 0;
        foreach (string line in input)
        {
            string[] choices = line.Split(" ");
            string opponent = choices[0];
            string me = choices[1];
            int oppInd = -2;
            int myInd = -2;
            for (int i = 0; i < oppCh.Length; i++)
                if (opponent == oppCh[i])
                    oppInd = i;
            for (int i = 0; i < meCh.Length; i++)
                if (me == meCh[i])
                {
                    myInd = i;
                    score += i + 1;
                }
            int looseInd = myInd + 1;
            if (looseInd < 0)
                looseInd = 2;
            else if (looseInd > 2)
                looseInd = 0;

            if (myInd == oppInd)
                score += 3;
            else if (oppInd != looseInd)
                score += 6;

        }
        Console.WriteLine(score);
    }
    
    public static void PartTwo()
    {
        int score = 0;
        int[] scoreList = new int[] { 0, 3, 6 };
        foreach (string line in input)
        {
            string[] choices = line.Split(" ");
            string opponent = choices[0];
            string me = choices[1];
            int oppInd = -2;
            for (int i = 0; i < oppCh.Length; i++)
                if (opponent == oppCh[i])
                    oppInd = i;
            int looseInd = oppInd - 1;

            int myInd = -2;
            if (looseInd < 0)
                looseInd = 2;
            else if (looseInd > 2)
                looseInd = 0;

            for (int i = 0; i < meCh.Length; i++)
                if (me == meCh[i])
                {
                    score += scoreList[i];
                    if (i == 0)
                        myInd = looseInd;
                    else if (i == 1)
                        myInd = oppInd;
                    else
                        for (int j = 0; j < 3; j++)
                            if (j != looseInd && j != oppInd)
                                myInd = j;
                }
            score += myInd + 1;
        }
        Console.WriteLine(score);

    }
    
}
