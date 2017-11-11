using System;
using System.Collections.Generic;
using System.Text;

/*
 * This is a utility class to sort, validate and perform any calculations on the seed data.
 */

namespace NearestEvents
{
    public static class Utils
    {
        // Calculate and display 
        public static void calculateNearestEventsWithCheapestTicket(int x1, int x2, List<Tuple<int, Event>> events)
        {
            List<Tuple<int, Event, int>> nearestEvents = new List<Tuple<int, Event, int>>();

            foreach (var evnt in events)
            {
                int y1 = evnt.Item2.xCoordinate;
                int y2 = evnt.Item2.yCoordinate;

                // Calculate Manhattan distance
                int distance = Utils.calculateManhattan(x1, y1, x2, y2);

                nearestEvents.Add(new Tuple<int, Event, int>(evnt.Item1, evnt.Item2, distance));
            }

            // Get the 5 closest events
            nearestEvents = sort(nearestEvents);

            Console.WriteLine(Environment.NewLine + "Closest events to (" + x1 + "," + x2 + ")"+ Environment.NewLine);

            foreach (var thisevent in nearestEvents)
            {
                string output = "Event ID: " + thisevent.Item1 +
                    ", coordinates: (" + thisevent.Item2.xCoordinate + "," + thisevent.Item2.yCoordinate + "), "
                    + "distance: " + thisevent.Item3
                    + ", cheapest ticket: $" + getCheapestTicketPrice(thisevent.Item2);
                
                Console.WriteLine(output);
            }
        }

        // Return the cheapest ticket for an event
        private static decimal getCheapestTicketPrice(Event anEvent)
        {
            decimal cheapestTicketPrice = anEvent.tickets[0].price;

            foreach (Ticket ticket in anEvent.tickets)
            {
                if (ticket.price < cheapestTicketPrice) 
                {
                    cheapestTicketPrice = ticket.price;
                }
            }
            return cheapestTicketPrice;
        }

        // Check if specified coordinates aleady exist in a specified list
        public static bool existingCoordinates(int x, int y, List<Tuple<int, int>> coordinateList)
        {
            bool contains = false;

            foreach (Tuple<int, int> coordinatePair in coordinateList)
            {
                if (coordinatePair.Item1 == x && coordinatePair.Item2 == y)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }


        // Calculate the Manhattan distance between two sets of (x,y) coordinates
        private static int calculateManhattan(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - y1) + Math.Abs(x2 - y2);
        }

        // Sort the events by distance, shortest to longest and return the first 5
        public static List<Tuple<int, Event, int>> sort(List<Tuple<int, Event, int>> events)
        {
            events.Sort((x, y) => x.Item3.CompareTo(y.Item3));

            return events.GetRange(0, 5);;
        }
    }
}
