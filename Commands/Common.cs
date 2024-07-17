namespace ToyRobot.Puzzle.Commands;

public class Common
{
    public static void ValidateToyRobotIfPlaced(DirectionTypes direction)
    {
        if (direction == 0)
        {
            throw new Exception(ErrorMessages.ErrorToyRobotNotYetPlaced);
        }
    }
}