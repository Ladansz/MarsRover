using System;
using System.Collections.Generic;
using System.Linq;

namespace Recreo
{
    class Result
    {
        public static void Command()
        {
            Console.WriteLine("Welcome to Mars! Please select between these options:");
            Console.WriteLine("Press any key to explore.");
            Console.WriteLine("Press E to exit.");
            if (Console.ReadLine().ToUpper() != "E")
            {
                try
                {
                    Console.WriteLine("Enter upper-right coordinates of the plateau:");
                    List<int> coordinates = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
                    do
                    {
                        Console.WriteLine("Enter rover's position: ");
                        List<string> roverPosition = Console.ReadLine().Trim().Split(' ').ToList();
                        Console.WriteLine("Enter instructions: ");
                        var instructions = Console.ReadLine().ToUpper();
                        var plateau = new Plateau(coordinates);
                        var rover = new Rover(roverPosition, plateau);
                        rover.Explore(instructions);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Output: {0} {1} {2}", rover.Point.X, rover.Point.Y, rover.Orientation);
                        Console.ResetColor();
                    } while (Console.ReadLine() != "E");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}