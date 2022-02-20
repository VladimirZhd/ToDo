using System;
using System.Collections.Generic;

namespace ToDo
{
    public class ToDo
    {
        public static void ListItems()
        {
            var toDoList = new List<ToDoItem>();
            var running = true;

            Console.WriteLine("Welcome to the Simple To Do List");
            Console.WriteLine("Commands: '-Exit', '-Show', -Completed, '-' \n");

            while (running == true)
            {
                Console.WriteLine("Please enter a list item to add or a command to perform:");

                Console.WriteLine("\n------To Do List-----");
                foreach (var task in toDoList)
                {
                    if (task.Completed)
                    {
                        Console.WriteLine($"\u2713 {task.Desc}");
                    }
                    else
                    {
                        Console.WriteLine($"- {task.Desc}");
                    }
                }
                Console.WriteLine("---------------------\n");


                // get user input
                var input = Console.ReadLine();

                switch(input)
                {
                    // Exit the app
                    case string a when a.StartsWith("-Exit"):
                        running = false;
                        break;

                    // Remove an item from a list
                    case string b when b.EndsWith("-"):
                        var endIndex = b.IndexOf("-");
                        var item = b.Substring(0, endIndex);
                        ToDoItem taskToRemove = toDoList.Find(x => x.Desc == item);
                        

                        if (toDoList.Contains(taskToRemove))
                        {
                            toDoList.Remove(taskToRemove);
                            Console.WriteLine($"{item} was removed.");
                        }
                        else
                        {
                            Console.WriteLine("{0} is not currently in the list, it cannot be removed", item);
                        }
                        break;

                    // Show list
                    case string c when c.StartsWith("-Show"):
                        Console.WriteLine("\n------To Do List-----");
                        foreach (var task in toDoList)
                        {
                            if (task.Completed)
                            {
                                //Console.WriteLine("{0} {1}", task.Desc, (char)251);
                                Console.WriteLine($"\u2713 {task.Desc}");


                            }
                            else
                            {
                                Console.WriteLine($"- {task.Desc}");
                            }
                        }
                        Console.WriteLine("---------------------\n");
                        break;

                    // Update 'completed' value
                    case string d when d.StartsWith("-Complete"):
                        var toDoName = d.Remove(0, d.IndexOf(' ') + 1);
                           foreach (var task in toDoList)
                        {
                            if (toDoName == task.Desc)
                            {
                                task.Completed = true;
                            }
                        }
                        break;

                    // If there is no options add todo to the list
                    default:
                        ToDoItem newItem = new ToDoItem(description: input, completed: false);
                        toDoList.Add(newItem);
                        break;
                }

            }
        }
    }
}
