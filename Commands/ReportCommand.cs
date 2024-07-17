using ToyRobot.Puzzle.Models;

namespace ToyRobot.Puzzle.Commands;

public class ReportCommand
{
    public void AnnouncePosition(ToyRobotPosition toyRobotPosition)
    {
        Common.ValidateToyRobotIfPlaced(toyRobotPosition.Direction);
        
        Console.WriteLine($"{toyRobotPosition.X}, {toyRobotPosition.Y} {toyRobotPosition.Direction.ToString()}");
    }
}