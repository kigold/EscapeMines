using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Data;
using TurtleChallenge.Enums;

namespace TurtleChallenge
{
    public class TurtleGame
    {
        private DirectionEnum _direction;
        private readonly BoardTileEnum[,] _mineField;
        private LocationData _location;
        private LocationData _startLocation;
        private TurtleStatusEnum _status;
        private readonly int XLowerBoundary;
        private readonly int XUpperBoundary;
        private readonly int YLowerBoundary;
        private readonly int YUpperBoundary;
        private readonly LocationData _boardSetting;
        public TurtleGame(LocationData boardSetting, DirectionEnum initialDirection, LocationData exitLocation, LocationData startlocation, LocationData[] mineLocations)
        {
            _boardSetting = boardSetting.Copy();
            _mineField = new BoardTileEnum[boardSetting.X, boardSetting.Y];
            _direction = initialDirection;
            _location = startlocation.Copy();
            _startLocation = startlocation.Copy();
            _status = TurtleStatusEnum.Danger;
            XLowerBoundary = 0;
            YLowerBoundary = 0;
            XUpperBoundary = boardSetting.X - 1;
            YUpperBoundary = boardSetting.Y - 1;
            _mineField[exitLocation.X, exitLocation.Y] = BoardTileEnum.Exit;
            foreach (var mineLocation in mineLocations)
            {
                _mineField[mineLocation.X, mineLocation.Y] = BoardTileEnum.Mine;
            }
        }
        
        public TurtleStatusEnum MoveTurtle(string moves)
        {
            ResetTurtle();
            var turtleMoves = moves.Split(' ').Select(x => (MovesEnum)Enum.Parse(typeof(MovesEnum), x));
            foreach (var move in turtleMoves)
            {                
                if (move == MovesEnum.M)
                {
                    _location = UpdateTurtleLocation(_direction, _location);
                }
                else
                {
                    _direction = RotateTurtle(_direction, move);
                }
                if (_status != TurtleStatusEnum.Danger)
                    return _status;
                //PrintBoard();
            }
            return _status;
        }
        private LocationData UpdateTurtleLocation(DirectionEnum currentDirection, LocationData currentLocation)
        {
            switch (currentDirection)
            {
                case DirectionEnum.N:
                    if(currentLocation.Y > YLowerBoundary)
                        currentLocation.Y--;
                    break;
                case DirectionEnum.S:
                    if (currentLocation.Y < YUpperBoundary)
                        currentLocation.Y++;
                    break;
                case DirectionEnum.E:
                    if (currentLocation.X < XUpperBoundary)
                        currentLocation.X++;
                    break;
                case DirectionEnum.W:
                    if (currentLocation.X > XLowerBoundary)
                        currentLocation.X--;
                    break;
                default:
                    break;
            }
            UpdateTurtleStatus();
            return currentLocation;
        }
        private DirectionEnum RotateTurtle(DirectionEnum currentDirection, MovesEnum move)
        {
            var change = (int)currentDirection + (int)move + 4;
            change = Math.Abs(change) % 4;
            return (DirectionEnum)Enum.ToObject(typeof(DirectionEnum), change);
        }
        public void UpdateTurtleStatus()
        {
            var currentTile = _mineField[_location.X, _location.Y];
            if (currentTile == BoardTileEnum.Exit)
            {
                _status = TurtleStatusEnum.Success;
                return;
            }
            if (currentTile == BoardTileEnum.Mine)
            {
                _status = TurtleStatusEnum.MineHit;
                return;
            }
            _status = TurtleStatusEnum.Danger;
        }
        private void ResetTurtle()
        {
            _status = TurtleStatusEnum.Danger;
            _location = _startLocation.Copy();
            _direction = DirectionEnum.N;
        }
        private void PrintBoard()
        {
            Console.WriteLine($"<#===============================X:{_location.X}===Y:{_location.Y}=Direction:{_direction}=====================================================");
            for (var i = 0; i < _boardSetting.Y; i++)
            {
                for (var j = 0; j < _boardSetting.X; j++)
                {
                    Console.Write("|");
                    Console.Write(_mineField[j, i]);
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"=====================================X:{_location.X}===Y:{_location.Y}===Direction:{_direction}===================================================#>");
        }
    }
}
