using System;
using System.Collections.Generic;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(string S)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        var wm = new WordMachine();
        return wm.ExecuteWordMachine(S);
    }
}

public class WordMachine
{
    public int ExecuteWordMachine(string input)
    {
        var stack = new Stack<int>();

        var commandList = ParseInput(input);
        try
        {
            foreach (var command in commandList)
            {

                if (IsCommandInteger(command))
                {
                    stack.Push(int.Parse(command));
                }
                else if (command.ToUpper() == "POP")
                {
                    stack.Pop();
                }

                else if (command.ToUpper() == "DUP")
                {
                    stack.Push(stack.Peek());
                }

                else if (command == "+")
                {
                    var firstPoppedItem = stack.Pop();
                    var secondPoppedItem = stack.Pop();
                    stack.Push(firstPoppedItem + secondPoppedItem);
                }

                else if (command == "-")
                {
                    var firstPoppedItem = stack.Pop();
                    var secondPoppedItem = stack.Pop();
                    stack.Push(firstPoppedItem - secondPoppedItem);
                }
            }

            return stack.Peek();
        }
        catch (Exception)
        {
            return -1;
        }
    }

    private List<string> ParseInput(string input)
    {
        var parsedStringArray = input.Split(' ');
        return parsedStringArray.ToList();
    }

    private bool IsCommandInteger(string input)
    {
        int n;
        return int.TryParse(input, out n);
    }
}