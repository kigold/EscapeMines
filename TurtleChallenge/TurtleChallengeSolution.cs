using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Data;
using TurtleChallenge.Enums;
using TurtleChallenge.Extensions;

namespace TurtleChallenge
{
    public class TurtleChallengeSolution
    {
        public static void Run(string filePath)
        {
            string line;
            int counter = 0;
            LocationData boardDimension = null;
            LocationData exitLocation = null;
            LocationData startingPositon = null;
            TurtleGame EscapeMinesGame = null;
            List<LocationData> mineLocations = new List<LocationData>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    string[] lineArray;
                    if (counter < 5)
                    {                        
                        //Configuration
                        switch(counter)
                        {
                            case 1:
                                //Get Board Dimension
                                lineArray = line.Split(' ');
                                boardDimension = new LocationData{ X = int.Parse(lineArray[0]), Y = int.Parse(lineArray[1]) };
                                break;
                            case 2:
                                //Get Mines Locations
                                lineArray = line.Split(' ');
                                foreach(var dimension in lineArray)
                                {
                                    var mines = dimension.Split(',');
                                    mineLocations.Add(new LocationData { X = int.Parse(mines[0]), Y = int.Parse(mines[1]) });
                                }
                                break;
                            case 3:
                                //Get Exit Location
                                lineArray = line.Split(' ');
                                exitLocation = new LocationData { X = int.Parse(lineArray[0]), Y = int.Parse(lineArray[1]) };
                                break;
                            case 4:
                                //Get Starting Postion and Direction
                                lineArray = line.Split(' ');
                                startingPositon = new LocationData { X = int.Parse(lineArray[0]), Y = int.Parse(lineArray[1]) };
                                var initialDirection = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), lineArray[2]);

                                //Create Board
                                EscapeMinesGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations.ToArray());
                                break;
                        }                            
                    }
                    else
                    {
                        //Read Turtle Moves
                        Console.WriteLine($"Sequence {counter-4}: {EscapeMinesGame.MoveTurtle(line).GetDescription()}");
                    }
                }
            }
            
        }
    }
}
