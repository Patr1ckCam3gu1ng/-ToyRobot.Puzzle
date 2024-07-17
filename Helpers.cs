namespace ToyRobot.Puzzle;

public static class Helpers
{
    public static int? GetNumericValue(string value)
    {
        var cleanedValue = value.Trim().Replace(",", "");

        if (int.TryParse(cleanedValue, out var numValue))
        {
            return numValue;
        }

        return null;
    }

    public static string[] GetCommandAndValue(string consoleReadValue)
    {
        return consoleReadValue.Split(" ");
    }

    public static string? GetCommandValueType(string value)
    {
        return Constants.ValidCommands.FirstOrDefault(command => command == value);
    }

    public static DirectionTypes? ConvertValueToDirectionType(string commandValueDirection)
    {
        foreach (var validDirection in Constants.ValidDirections.Where(validDirection => validDirection.ToString() == commandValueDirection))
        {
            return validDirection;
        }

        return null;
    }
}