using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TurtleChallenge.Data;
using TurtleChallenge.Enums;

namespace TurtleChallenge.UnitTests
{
    [TestFixture]
    public class ChangeDirection_UnitTests
    {
        private TurtleGame _turtleGame;
        private LocationData boardDimension;
        private LocationData exitLocation;
        private LocationData startingPositon;
        private DirectionEnum initialDirection;
        private LocationData[] mineLocations;
        [SetUp]
        public void Turtle_Setup()
        {
            LocationData boardDimension = new LocationData() { X=5,Y=4};
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.N;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
        }

        [Test]
        public void TurtleInitialDirection_InitializeTurtleNorth_ReturnNorth()
        {
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.N);
        }
        [Test]
        public void TurtleInitialDirection_InitializeTurtleSouth_ReturnSouth()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.S;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.S);
        }
        [Test]
        public void TurtleInitialDirection_InitializeTurtleEast_ReturnEast()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.E;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.E);
        }
        [Test]
        public void TurtleInitialDirection_InitializeTurtleWest_ReturnWest()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.W;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.W);
        }
        [Test]
        public void TurtleFacingNorth_RotateTurtleRight_ReturnEast()
        {
            _turtleGame.MoveTurtle("R");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.E);
        }
        [Test]
        public void TurtleFacingNorth_RotateTurtleLeft_ReturnWest()
        {
            _turtleGame.MoveTurtle("L");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.W);
        }
        [Test]
        public void TurtleFacingNorth_Move_ChangedLocation()
        {
            _turtleGame.MoveTurtle("M");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.N);
            Assert.IsTrue(_turtleGame.GetLocation.IsEqual(new LocationData { X = 0, Y = 0 }));
        }
        [Test]
        public void TurtleFacingSouth_RotateTurtleRight_ReturnWest()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.S;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("R");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.W);
        }
        [Test]
        public void TurtleFacingSouth_RotateTurtleLeft_ReturnEast()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.S;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("L");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.E);
        }
        [Test]
        public void TurtleFacingSouth_Move_ChangedDirection()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.S;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("M");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.S);
            Assert.IsTrue(_turtleGame.GetLocation.IsEqual(new LocationData { X = 0, Y = 2 }));
        }
        [Test]
        public void TurtleFacingWest_RotateTurtleRight_ReturnNorth()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.W;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("R");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.N);
        }
        [Test]
        public void TurtleFacingWest_RotateTurtleLeft_ReturnSouth()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.W;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("L");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.S);
        }
        [Test]
        public void TurtleFacingWest_Move_SameLocation()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.W;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("M");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.W);
            Assert.IsTrue(_turtleGame.GetLocation.IsEqual(new LocationData { X = 0, Y = 1 }));
        }
        [Test]
        public void TurtleFacingWest_Move_ChangeLocation()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 2, Y = 1 };
            var initialDirection = DirectionEnum.W;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("M");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.W);
            Assert.IsTrue(_turtleGame.GetLocation.IsEqual(new LocationData { X = 1, Y = 1 }));
        }
        [Test]
        public void TurtleFacingEast_RotateTurtleRight_ReturnSouth()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.E;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("R");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.S);
        }
        [Test]
        public void TurtleFacingEast_RotateTurtleLeft_ReturnNorth()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.E;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("L");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.N);
        }

        [Test]
        public void TurtleFacingEast_Move_ChangedLocation()
        {
            LocationData boardDimension = new LocationData() { X = 5, Y = 4 };
            LocationData exitLocation = new LocationData() { X = 4, Y = 2 };
            LocationData startingPositon = new LocationData() { X = 0, Y = 1 };
            var initialDirection = DirectionEnum.E;
            var mineLocations = new[] { new LocationData() { X = 1, Y = 1 }, new LocationData() { X = 3, Y = 1 }
                ,new LocationData() { X=3,Y=3}};
            _turtleGame = new TurtleGame(boardDimension, initialDirection, exitLocation, startingPositon, mineLocations);
            _turtleGame.MoveTurtle("M");
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.E);
            Assert.IsTrue(_turtleGame.GetLocation.IsEqual(new LocationData { X = 1, Y = 1 }));
        }
    }
}
