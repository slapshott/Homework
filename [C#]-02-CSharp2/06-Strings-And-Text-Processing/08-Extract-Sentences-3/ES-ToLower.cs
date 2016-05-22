﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Extract_Sentences_3
{
    class Program
    {
        static string Alphabet = "abcdefghijklmnopqrstuwxyz";

        static void Main()
        {
            // Sentences separated by DOT, 
            // words separated by non letter symbols
            var separator = ".";

            // {0} sentence {1} separator
            var sentenceFormat = "{0}{1}";

            // Word to find.
            var toFindWord = Console.ReadLine();

            // Text to search.
            var toParseSentences = Console
                .ReadLine()
                .Split(separator.ToCharArray())
                .ToArray();

            // Get a List of words with different
            // cases upper, lower, capitalized
            var toFind = GetWords(toFindWord);

            var output = new StringBuilder();

            foreach (var sentence in toParseSentences)
            {
                if (ContainsWord(sentence, toFind))
                {
                    output.Append(
                        string.Format(
                            sentenceFormat,
                            sentence,
                            separator
                            ));
                }
            }

            Console.WriteLine(output);
        }

        static string GetWords(string Word)
        {
            var toReturn = new StringBuilder();

            foreach (var letter in Word)
            {
                if (char.IsLetter(letter))
                {
                    toReturn.Append(char.ToLowerInvariant(letter));
                }
            }
            
            return toReturn.ToString();
        }

        static string GetSentence(string Sentence)
        {
            var toReturn = new StringBuilder();

            foreach (var letter in Sentence)
            {
                if (char.IsLetter(letter) || letter == ' ')
                {
                    toReturn.Append(char.ToLowerInvariant(letter));
                }
            }

            return toReturn.ToString();
        }

        // TOO SLOW
        static List<string> GenerateAllCases(string Word)
        {
            var curWordVariation = new StringBuilder();

            var toReturn = new List<string>();

            toReturn.Add(Word);

            var WordToLower = Word.ToLower();

            toReturn.Add(WordToLower);
            toReturn.Add(Word.ToUpper());

            for (int curEndPoint = 0;
                     curEndPoint < Word.Length;
                     curEndPoint++)
            {
                for (int curStartPoint = 0;
                         curStartPoint <= curEndPoint;
                         curStartPoint++)
                {
                    //reset the string builder
                    curWordVariation.Clear();

                    // Everything BEFORE StartPont AS IS 
                    for (int curIndex = 0;
                             curIndex < curStartPoint;
                             curIndex++)
                    {
                        curWordVariation.Append(WordToLower[curIndex]);
                    }
                    // Everuthing BETWEEN StartPoint and EndPoint to UPPER
                    for (int curIndex = curStartPoint;
                             curIndex <= curEndPoint;
                             curIndex++)
                    {
                        curWordVariation.Append(char.ToUpper(WordToLower[curIndex]));
                    }
                    // Everything AFTER EndPoint AS IS 
                    for (int curIndex = curEndPoint + 1;
                             curIndex < WordToLower.Length;
                             curIndex++)
                    {
                        curWordVariation.Append(WordToLower[curIndex]);
                    }

                    // Add the current variation to the list.
                    toReturn.Add(curWordVariation.ToString());
                }
            }

            return toReturn;
        }

        static bool ContainsWord(string Sentence, string word)
        {
            var checkFormat = "^{0}$";
            var toCheck = string.Format(checkFormat, Sentence.ToLowerInvariant());

            var wordLength = word.Length;

            var wordCurIndex = toCheck.IndexOf(word.ToLower());

            // While the current sentece contains
            // the current variation of the word.
            while (wordCurIndex >= 0)
            {
                // Check if the word string is a 
                // separate word.
                if (!Alphabet.Contains(toCheck[wordCurIndex - 1]) &&
                    !Alphabet.Contains(toCheck[wordCurIndex + wordLength]))
                {
                    return true;
                }

                // Find next occurance.
                wordCurIndex = toCheck.IndexOf(word.ToLower(), ++wordCurIndex);
            }


            return false;
        }
    }
}
