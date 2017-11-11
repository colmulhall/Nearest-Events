using System;
using System.Collections.Generic;

/*
 * Structure for an event.
 */

namespace NearestEvents
{
    public struct Event
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}
