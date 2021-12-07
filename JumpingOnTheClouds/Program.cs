//using Commons;
//using System;

//namespace JumpingOnTheClouds
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TextHandle.WriteFile(new Result());
//        }
//    }
//}

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

 public static class ExtensionMethods
{
    public static Tuple<int, int> NextTwo(this IEnumerable<int> list, int currentPosition)
    {
        if (list == null)
            throw new ArgumentNullException("TheList should not be null");
        else
        {
            var teste = list.Where(value => (value >= currentPosition + 1 && value <= currentPosition + 2));
            return new Tuple<int, int>(teste.FirstOrDefault(), teste.LastOrDefault());
        }
    }
}

class Result
{

    /*
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

    public static int jumpingOnClouds(List<int> c)
    {
        var _parameters = new { n = (int)c.Count, c = (List<int>)c };

        var allowedClouds = _parameters.c
            .Select((value, index) => new { value, index })
            .Where(item => item.value == 0)
            .Select(item => item.index);

        int currentPosition = 0;
        int pathSize = 0;

        while(currentPosition != c.Count -1)
        {
            var possiblePaths = allowedClouds.NextTwo(currentPosition);

            currentPosition = possiblePaths.Item2;
            pathSize++;
        }

        return pathSize;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Result.jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

