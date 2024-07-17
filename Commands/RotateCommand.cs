namespace ToyRobot.Puzzle.Commands;

public class RotateCommand
{
    public DirectionTypes RotateLeft(DirectionTypes direction)
    {
        Common.ValidateToyRobotIfPlaced(direction);

        return direction switch
        {
            DirectionTypes.NORTH => DirectionTypes.WEST,
            DirectionTypes.EAST => DirectionTypes.NORTH,
            DirectionTypes.SOUTH => DirectionTypes.EAST,
            DirectionTypes.WEST => DirectionTypes.SOUTH,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public DirectionTypes RotateRight(DirectionTypes direction)
    {
        Common.ValidateToyRobotIfPlaced(direction);

        return direction switch
        {
            DirectionTypes.NORTH => DirectionTypes.EAST,
            DirectionTypes.EAST => DirectionTypes.SOUTH,
            DirectionTypes.SOUTH => DirectionTypes.WEST,
            DirectionTypes.WEST => DirectionTypes.NORTH,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}