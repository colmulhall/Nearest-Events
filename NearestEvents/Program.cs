using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Code challenge
 * 
 * The purpose of this program is to allow the user to enter coordinate along the -10/+10 x and y axis.
 * Based on these coordinates, the nearest 5 events with their cheapest ticket prices are to be displayed 
 * to the user. The events and tickets should be randomly generated.
 * 
 * Author: Colm Mulhall, November 2017
 */

namespace NearestEvents
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] coordinates = inputAndValidateCoordinate();

            // Generate the seed data
            SeedGenerator seedGen = new SeedGenerator();

            // Calculate and display the results
            Utils.calculateNearestEventsWithCheapestTicket(coordinates[0], coordinates[1], SeedGenerator.allEvents);
        }

        // Validate that the coordinates entered are integers and in the range of -10 to +10
        static int[] inputAndValidateCoordinate()
        {
            int[] coordinates = new int[2];
            int coordinate;
            int i = 0;

            Console.WriteLine("Please input coordinates:");
            String input = Console.ReadLine();

            if (input.Split(',').Count() > 1 && input.Split(',').Count() < 3)
            {
                foreach (var singleCoordinate in input.Split(','))
                {
                    if (!Int32.TryParse(singleCoordinate, out coordinate))
                    {
                        Console.WriteLine("Not a valid coordinate");
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        if (coordinate < -10 || coordinate > 10)
                        {
                            Console.WriteLine("Coordinate must be in the range of -10 to 10");
                            System.Environment.Exit(1);
                        }
                    }

                    coordinates[i] = coordinate;
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Coordinates should be in format: x,y");
                System.Environment.Exit(1);
            }
            return coordinates;
        }
    }
}
