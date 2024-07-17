using ToyRobot.Puzzle;
using ToyRobot.Puzzle.Commands;
using ToyRobot.Puzzle.Models;

var toyRobotPosition = new ToyRobotPosition();

var cmd = new PlaceCommand();
var rotate = new RotateCommand();
var report = new ReportCommand();
var mv = new MoveCommand();

while (true)
{
    try
    {
        Console.Write("Enter command: ");
        var commandSubmitted = Console.ReadLine();

        if (string.IsNullOrEmpty(commandSubmitted))
        {
            Console.WriteLine(ErrorMessages.ErrorInvalidInitialCommand);
            continue;
        }

        var command = cmd.GetCommand(commandSubmitted);

        switch (command)
        {
            case Constants.Commands.Place:
            {
                var values = cmd.GetSubmittedCommandValue(commandSubmitted, toyRobotPosition.Direction);

                toyRobotPosition = new ToyRobotPosition()
                {
                    X = values.XPosition,
                    Y = values.YPosition,
                    Direction = values.Direction
                };
                break;
            }
            case Constants.Commands.Move:
            {
                toyRobotPosition = mv.Move(toyRobotPosition);
                break;
            }
            case Constants.Commands.Left:
                toyRobotPosition.Direction = rotate.RotateLeft(toyRobotPosition.Direction);
                break;
            case Constants.Commands.Right:
                toyRobotPosition.Direction = rotate.RotateRight(toyRobotPosition.Direction);
                break;
            case Constants.Commands.Report:
                report.AnnouncePosition(toyRobotPosition);
                break;
        }

        continue;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        continue;
    }
}

return;