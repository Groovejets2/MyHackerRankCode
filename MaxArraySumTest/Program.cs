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

class Solution
{

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr)
    {
        int indexRunner = 0;
        int arrLength = arr.Length;
        int maxSubsetSum = 0;

        while (indexRunner < arr.Length)
        {
            int thisSkipSum = returnSkipSum(indexRunner, arr);
            if (thisSkipSum > maxSubsetSum)
                maxSubsetSum = thisSkipSum;

            int altStartIndex = indexRunner + 2;
            if (altStartIndex > arrLength - 2)
                break;

            while (altStartIndex < arrLength)
            {
                int thisJumpSum = returnJumpSum(indexRunner, altStartIndex, arr);
                if (thisJumpSum > maxSubsetSum)
                    maxSubsetSum = thisJumpSum;
                altStartIndex++;
            }

            indexRunner++;
        }
        if (maxSubsetSum == 0)
            throw new Exception("A maximum subset could not be not found. Check your number array and try again.");
        return maxSubsetSum;
    }

    static int returnSkipSum(int startIndex, int[] arr)
    {
        int sum = 0;
        while (startIndex < arr.Length)
        {
            sum += arr[startIndex];
            startIndex += 2;
        }
        return sum;
    }

    static int returnJumpSum(int startIndex, int jumpIndex, int[] arr)
    {
        return arr[startIndex] + arr[jumpIndex];

    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@"C:\Dev\MaxArraySumTest\timeout.txt", true);

        int counter = 0;
        string line;
        int n = 0;

        System.IO.StreamReader file =  new System.IO.StreamReader(@"C:\Dev\MaxArraySumTest\timeout.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (counter == 0)
                n = Convert.ToInt32(line.ToString());
                counter++;
 
        }
            int n = 5;

        int[] arr = { 3, 7, 4, 6, 5 }; //Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
