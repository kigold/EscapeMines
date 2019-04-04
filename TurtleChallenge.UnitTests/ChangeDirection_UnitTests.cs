using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TurtleChallenge.Enums;

namespace TurtleChallenge.UnitTests
{
    [TestFixture]
    public class ChangeDirection_UnitTests
    {
        private TurtleGame _turtleGame;
        [SetUp]
        public void Turtle_Setup()
        {
            _turtleGame = new TurtleGame(DirectionEnum.North, 5, 4);
        }

        [Test]
        public void TurtleFacingNorth_RotateTurtleRigh_ReturnEast()
        {
            _turtleGame.TurtleMove(MovesEnum.Right);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.East);
        }
        [Test]
        public void TurtleFacingNorth_RotateTurtleLeft_ReturnWest()
        {
            _turtleGame.TurtleMove(MovesEnum.Left);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.West);
        }
        [Test]
        public void TurtleFacingSouth_RotateTurtleRight_ReturnWest()
        {
            _turtleGame = new TurtleGame(DirectionEnum.South, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Right);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.West);
        }
        [Test]
        public void TurtleFacingSouth_RotateTurtleLeft_ReturnEast()
        {
            _turtleGame = new TurtleGame(DirectionEnum.South, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Left);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.East);
        }
        [Test]
        public void TurtleFacingEast_RotateTurtleRight_ReturnSouth()
        {
            _turtleGame = new TurtleGame(DirectionEnum.East, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Right);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.South);
        }
        [Test]
        public void TurtleFacingEast_RotateTurtleLeft_ReturnNorth()
        {
            _turtleGame = new TurtleGame(DirectionEnum.East, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Left);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.North);
        }
        [Test]
        public void TurtleFacingWest_RotateTurtleRight_ReturnNorth()
        {
            _turtleGame = new TurtleGame(DirectionEnum.West, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Right);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.North);
        }
        [Test]
        public void TurtleFacingWest_RotateTurtleLeft_ReturnSouth()
        {
            _turtleGame = new TurtleGame(DirectionEnum.West, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Left);
            Assert.AreEqual(_turtleGame.GetDirection, DirectionEnum.South);
        }
        [Test]
        public void TurtleFacingWest_RotateTurtleLeft_NotReturnSouth()
        {
            _turtleGame = new TurtleGame(DirectionEnum.West, 5, 4);
            _turtleGame.TurtleMove(MovesEnum.Left);
            Assert.AreNotEqual(_turtleGame.GetDirection, DirectionEnum.North);
        }
    }
}
