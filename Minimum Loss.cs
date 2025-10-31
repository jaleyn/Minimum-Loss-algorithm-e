using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'minimumLoss' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts LONG_INTEGER_ARRAY price as parameter.
     */

    public static int minimumLoss(List<long> price)
    {
        int n = price.Count;

        var arr = price.Select((p, idx) => new { Value = p, Index = idx }).ToList();

        arr.Sort((x, y) => y.Value.CompareTo(x.Value));

        long minLoss = long.MaxValue;

        for (int i = 0; i < n - 1; i++)
        {
            
            if (arr[i].Index < arr[i + 1].Index)
            {
                long loss = arr[i].Value - arr[i + 1].Value;
                if (loss > 0 && loss < minLoss)
                    minLoss = loss;
            }
        }

        return (int)minLoss;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> price = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(priceTemp => Convert.ToInt64(priceTemp)).ToList();

        int result = Result.minimumLoss(price);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
