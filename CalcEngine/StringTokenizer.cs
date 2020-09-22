using System.ComponentModel.Design;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalcEngine
{
    //splits a string into tokens based on a specified set of delimiter values.
    public class StringTokenizer
    {

        public virtual string[] Tokenize(string command, IEnumerable<string> splitOn)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentOutOfRangeException(nameof(command));
            if (splitOn?.Any() != true)
                throw new ArgumentOutOfRangeException(nameof(splitOn));

            var results = new List<string>();
            
            ReadOnlySpan<char> commandChars = command.AsSpan();
            int startIndex = 0, searchIndex = 0;
            bool found;

            while (searchIndex < commandChars.Length)
            {
                found = false;

                foreach (string delimiter in splitOn)
                {
                    //operator length may be > 1 char
                    if (commandChars.Length < searchIndex + delimiter.Length)
                        continue;
                    
                    var slice = commandChars.Slice(searchIndex, delimiter.Length);
                    if (slice.SequenceEqual(delimiter.AsSpan()))
                    {
                        found = true;
                        if (searchIndex > startIndex) //don't add zero-length strings!
                            results.Add(new string(commandChars.Slice(startIndex, searchIndex - startIndex)));
                        results.Add(delimiter);
                                            
                        //move the search and start indexes past the found token
                        searchIndex += delimiter.Length;
                        startIndex = searchIndex;
                        break;
                    }
                }

                if (!found)
                    searchIndex++;
            }

            //return the final segment if any
            if (startIndex < commandChars.Length)
                results.Add(new string(commandChars.Slice(startIndex)));

            return results.ToArray();
        }


    }
}