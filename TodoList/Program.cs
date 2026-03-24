using System;
using System.Collections.Generic;

class Program
{
    static List<(string Title, bool Done)> todos = new();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== To-Do List ===");
            if (todos.Count == 0)
            {
                Console.WriteLine("  (no items)");
            }
            else
            {
                for (int i = 0; i < todos.Count; i++)
                {
                    string status = todos[i].Done ? "[x]" : "[ ]";
                    Console.WriteLine($"  {i + 1}. {status} {todos[i].Title}");
                }
            }

            Console.WriteLine("\nOptions: (a)dd  (c)omplete  (d)elete  (q)uit");
            Console.Write("> ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            switch (input)
            {
                case "a":
                    Console.Write("Enter task title: ");
                    string? title = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(title))
                    {
                        todos.Add((title, false));
                        Console.WriteLine("Task added.");
                    }
                    break;

                case "c":
                    Console.Write("Enter task number to mark complete: ");
                    if (int.TryParse(Console.ReadLine(), out int completeIdx) &&
                        completeIdx >= 1 && completeIdx <= todos.Count)
                    {
                        var item = todos[completeIdx - 1];
                        todos[completeIdx - 1] = (item.Title, true);
                        Console.WriteLine("Task marked as complete.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case "d":
                    Console.Write("Enter task number to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteIdx) &&
                        deleteIdx >= 1 && deleteIdx <= todos.Count)
                    {
                        todos.RemoveAt(deleteIdx - 1);
                        Console.WriteLine("Task deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case "q":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Unknown option.");
                    break;
            }
        }
    }
}
