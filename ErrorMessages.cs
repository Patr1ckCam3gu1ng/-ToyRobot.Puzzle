namespace ToyRobot.Puzzle;

public static class ErrorMessages
{
    public const string ErrorMissingValidPosition = $"Error! {Constants.Commands.Place} command must be provided with valid cardinal direction";

    public const string ErrorInvalidInitialCommand = $"Error! Invalid input command has been provided.";

    public const string ErrorInvalidValue = $"Error! Invalid values has been provided for this valid command.";

    public const string ErrorToyRobotWouldFall = $"Error! Toy Robot would fall from the table";
    
    public const string ErrorCoordinatesExceeded = $"Coordinates should not exceed by";
    
    public const string ErrorCommandIsEmpty = $"Command should not be empty or null";
    
    public const string ErrorToyRobotNotYetPlaced = $"Toy Robot must be first be placed";
}