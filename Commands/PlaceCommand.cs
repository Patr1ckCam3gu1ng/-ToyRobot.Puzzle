using ToyRobot.Puzzle.Models;

namespace ToyRobot.Puzzle.Commands;

public class PlaceCommand
{
    public string GetCommand(string consoleReadValue)
    {
        if (string.IsNullOrEmpty(consoleReadValue) == false)
        {
            var commandAndValue = Helpers.GetCommandAndValue(consoleReadValue);
            if (commandAndValue.Length == 0)
            {
                throw new Exception(ErrorMessages.ErrorInvalidInitialCommand);
            }

            return GetSubmittedCommand(commandAndValue[0]);
        }

        throw new Exception(ErrorMessages.ErrorCommandIsEmpty);
    }

    public CommandValueModel GetSubmittedCommandValue(string consoleReadValue, DirectionTypes currentDirection)
    {
        var submittedCommandAndValues = Helpers.GetCommandAndValue(consoleReadValue);

        if (submittedCommandAndValues.Length < 2)
        {
            throw new Exception($"X {ErrorMessages.ErrorInvalidValue}");
        }

        var splitCommandValues = submittedCommandAndValues[1].Split(",");
        if (splitCommandValues.Length == 3 || (currentDirection != 0 && splitCommandValues.Length == 2))
        {
            var valueDirection = currentDirection != 0 ? currentDirection.ToString() : splitCommandValues[2];

            if (Constants.ValidDirections.Select(c => c.ToString()).Contains(valueDirection))
            {
                var directionValue = Helpers.ConvertValueToDirectionType(valueDirection);
                if (directionValue != null)
                {
                    var xPosition = Helpers.GetNumericValue(splitCommandValues[0]);
                    if (xPosition == null)
                    {
                        throw new Exception($"X {ErrorMessages.ErrorMissingValidPosition}");
                    }

                    var yPosition = Helpers.GetNumericValue(splitCommandValues[1]);
                    if (yPosition == null)
                    {
                        throw new Exception($"Y {ErrorMessages.ErrorMissingValidPosition}");
                    }
                    
                    if (xPosition > Config.MaxUnits || yPosition > Config.MaxUnits)
                    {
                        throw new Exception($"{ErrorMessages.ErrorCoordinatesExceeded} {Config.MaxUnits} units");
                    }

                    var commandValue = new CommandValueModel
                    {
                        XPosition = (int)xPosition,
                        YPosition = (int)yPosition,
                        Direction = (DirectionTypes)directionValue
                    };

                    return commandValue;
                }
                else
                {
                    throw new Exception(ErrorMessages.ErrorMissingValidPosition);
                }
            }
            else
            {
                throw new Exception(ErrorMessages.ErrorMissingValidPosition);
            }
        }
        else
        {
            throw new Exception(ErrorMessages.ErrorInvalidValue);
        }
    }

    private string GetSubmittedCommand(string value)
    {
        var command = Helpers.GetCommandValueType(value);
        if (command == null)
        {
            throw new Exception(ErrorMessages.ErrorInvalidInitialCommand);
        }

        return command;
    }
}