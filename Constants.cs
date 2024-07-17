namespace ToyRobot.Puzzle;

public static class Constants
{
    public static class Commands
    {
        public const string Place = "PLACE";

        public const string Move = "MOVE";

        public const string Left = "LEFT";

        public const string Right = "RIGHT";

        public const string Report = "REPORT";
    }
    
    public static readonly List<string?> ValidCommands =
    [
        Commands.Place,
        Commands.Move,
        Commands.Left,
        Commands.Right,
        Commands.Report
    ];
    
    public static readonly List<DirectionTypes> ValidDirections =
    [
        DirectionTypes.NORTH,
        DirectionTypes.EAST,
        DirectionTypes.WEST,
        DirectionTypes.SOUTH
    ];
}

