using System;
using System.Collections.Generic;
using System.Text;

/*
 * The purpose of this class is to generate random seed data for the program. 
 * 
 * This will generate:
 * 
 *  - a random number of events between 5 and 30
 *  - for each event, a random number of tickets between 0 and 100 will be generated
 *  - for each ticket, a random price between $10 and $300
 * 
 * It also includes a method which dumps the seed data into a text file so that the program 
 * output can be validated.
 */

namespace NearestEvents
{
    public class SeedGenerator
    {
        public static List<Tuple<int, Event>> allEvents;

        public SeedGenerator()
        {
            allEvents = new List<Tuple<int, Event>>();

            Random rand = new Random();
            List<Tuple<int, int>> coordinateList = new List<Tuple<int, int>>();

            // Generate random number of events between 5 and 30
            for (int i = 0; i < rand.Next(10, 30); i++)
            {
                // For this event, generate a random x, y cooradinate on the -10 + 10 axis
                // Ensure that more than one event are not generated in the same location
                int x, y = 0;

                do
                {
                    x = rand.Next(-10, 10);
                    y = rand.Next(-10, 10);
                } while (Utils.existingCoordinates(x, y, coordinateList));

                coordinateList.Add(new Tuple<int, int>(x, y));

                // Generate a random number of tickets between 0 and 100 for the event
                List<Ticket> tickets = new List<Ticket>();

                for (int j = 0; j < rand.Next(0, 100); j++)
                {
                    // Generate the random ticket price between 10 USD and 300 USD
                    var randomDecimal = new decimal(rand.NextDouble() * (300 - 10) + 10);
                    decimal price = System.Math.Round(randomDecimal, 2);

                    Ticket thisTicket = new Ticket();
                    thisTicket.eventID = j + 1;
                    thisTicket.price = price;

                    tickets.Add(thisTicket);
                }

                // Build the event struct
                Event thisEvent = new Event();
                thisEvent.xCoordinate = x;
                thisEvent.yCoordinate = y;
                thisEvent.tickets = tickets;

                allEvents.Add(new Tuple<int, Event>(i + 1, thisEvent));
            }

            // Write the seed data to a file for reference
            writeSeedDataToFile();
        }

        // Write the output of the program to a file for reference
        private static void writeSeedDataToFile()
        {
            StringBuilder outputToFile = new StringBuilder();

            foreach (var thisevent in allEvents)
            {
                string output = "Event ID: " + thisevent.Item1 +
                    ", coordinates: (" + thisevent.Item2.xCoordinate + "," + thisevent.Item2.yCoordinate + ") ";

                outputToFile.AppendLine(output + Environment.NewLine);

                outputToFile.AppendLine(thisevent.Item2.tickets.Count + " tickets available for this event:");
                foreach (Ticket thisTicket in thisevent.Item2.tickets)
                {
                    outputToFile.Append("$" + thisTicket.price + " ");
                }
                outputToFile.Append(Environment.NewLine + Environment.NewLine);
            }

            System.IO.File.WriteAllText("../../Generated Seed Data.txt", outputToFile.ToString());
        }
    }
}
