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
     * Complete the 'funWithAnagrams' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY s as parameter.
     */
    public static List<string> wordsToKeep = new List<string>();
    public static List<string> wordsToDrop = new List<string>();

    public static List<string> FunWithAnagrams(List<string> s)
    {
        bool skipFirst = true;

        //TEST: Simple test on input parameter data
        if (!SimpleInputDataTest(s))
            throw new Exception("FunWithAnagrams input record count is invalid or count is not an integer. Check input data and try again.");

        //LOOP: through all the words
        foreach(string wrd in s)
        {
            if (skipFirst)
            {
                skipFirst = false;
                continue;
            }

            if (!IsStringAnAnagram(wrd))
            {
                wordsToKeep.Add(wrd);
                continue;
            }
        }
        wordsToKeep.Sort();
        return wordsToKeep;
    }

    public static bool SimpleInputDataTest(List<string> s)
    {
        var recordCountActual = (s.Count() - 1);

        //CHECK1: Is the first string avalid integer and CHECK2: Does it match the real record count?
        if (!int.TryParse(s[0].ToString(), out int recordCountInData)) return false;
        if (recordCountActual != recordCountInData) return false;
        return true;
    }

    private static bool IsStringAnAnagram(string wordToCheck)
    {
        foreach(string word in wordsToKeep)
        {
            if (IsAnagram(word, wordToCheck)) return true;
        }
        return false;
    }
    private static bool IsAnagram(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;

        int word1charCount = word1.Length;
        var word2RemCount = 0;

        //LOOP: Through each character in word 1
        foreach (char c1 in word1)
        {
            //LOOP: Through each character in word 2
            foreach (char c2 in word2)
            {
                //CHECK: Is [Word1] char NOT EQUAL to [Word2] char?
                //TRUE: 
                // - Skip to next [Word2] char
                //FALSE: 
                // - Remove char from [Word2], 
                // - Increment remove counter and 
                // - Skip to next [Word1] letter
                if (c1 != c2)
                    continue;
                word2 = word2.Remove(word2.IndexOf(c2), 1);
                word2RemCount++;
                break;
            }
        }
        //CHECK: Does removal count match total count?
        if (word1charCount != word2RemCount) return false;

        return true;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        if(File.Exists(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH")))
            File.Delete(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"));

        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        IEnumerable<String> inputParamaters = File.ReadAllLines(@System.Environment.GetEnvironmentVariable("INPUT_PATH")).ToArray();

        List<string> inputNumbers = new List<string>();

        foreach(string paramater in inputParamaters)
        {
            inputNumbers.Add(paramater);
        }

        List<string> result = Result.FunWithAnagrams(inputNumbers);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}