using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Enums;

namespace TurtleChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\kingslee\\Desktop\\Turtle.txt";
            //path = args[0];
            TurtleChallengeSolution.Run(path);
        }
    }
}
