using ToyRobot.Puzzle.Models;

namespace ToyRobot.Puzzle.Commands;

public class MoveCommand
{
    public ToyRobotPosition Move(ToyRobotPosition toyRobotPosition)
    {
        Common.ValidateToyRobotIfPlaced(toyRobotPosition.Direction);

        var newToyPosition = new ToyRobotPosition()
        {
            X = toyRobotPosition.X,
            Y = toyRobotPosition.Y,
            Direction = toyRobotPosition.Direction,
        };

        switch (newToyPosition.Direction)
        {
            case DirectionTypes.NORTH:
                newToyPosition.X -= 1;
                break;
            case DirectionTypes.SOUTH:
                newToyPosition.X += 1;
                break;
            case DirectionTypes.EAST:
                newToyPosition.Y += 1;
                break;
            case DirectionTypes.WEST:
                newToyPosition.Y -= 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        if (newToyPosition.X is < 0 or > Config.MaxUnits)
        {
            throw new Exception(ErrorMessages.ErrorToyRobotWouldFall);
        }

        if (newToyPosition.Y is < 0 or > Config.MaxUnits)
        {
            throw new Exception(ErrorMessages.ErrorToyRobotWouldFall);
        }

        return newToyPosition;
    }
}