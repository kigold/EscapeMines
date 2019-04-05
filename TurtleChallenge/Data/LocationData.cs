using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Data
{
    public class LocationData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationData Copy()
        {
            return new LocationData { X = this.X, Y = this.Y };
        }
        public bool IsEqual(LocationData obj)
        {
            return (obj.X == X && obj.Y == Y);
        }
    }
}
