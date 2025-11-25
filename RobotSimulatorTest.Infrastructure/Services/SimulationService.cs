using RobotSimulator.Models;
using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Infrastructure.Services
{
    public class SimulationService(Robot robot, Table table) : ISimulationService
    {
        /// <summary>
        /// Attempts to move the robot one unit forward in its current direction
        /// </summary>
        public void MoveRobot()
        {
            if (robot is null || table is null)
                throw new ArgumentNullException("Robot or Table cannot be null");

            if (!robot.IsRobotPlacedOnTable)
            {
                Console.WriteLine("Robot is not placed on the table. Use PLACE command first.");
                return;
            }

            Position newPosition = robot.MoveToNextPosition();

            if (table.IsValidPosition(newPosition))
            {
                robot.UpdatePosition(newPosition);
            }
            else
            {
                Console.WriteLine($"Cannot move: Position ({newPosition.X},{newPosition.Y}) would be out of bounds.");
            }
        }

        public void PlaceRobot(int xCoordinate, int yCoordinate, Direction direction)
        {
            var position = new Position(xCoordinate, yCoordinate);

            if (!table.IsValidPosition(position))
            {
                Console.WriteLine($"Invalid position: ({xCoordinate},{yCoordinate}) is out of table bounds (0-{table.Width-1}, 0-{table.Height-1}).");
                return;
            }

            robot.Place(position, direction);
            Console.WriteLine($"Robot placed at ({xCoordinate},{yCoordinate}) facing {direction}.");
        }

        public void MoveRobotToLeft()
        {
            if (!robot.IsRobotPlacedOnTable)
            {
                Console.WriteLine("Robot is not placed on the table. Use PLACE command first.");
                return;
            }

            robot.TurnLeft();
        }

        public void MoveRobotToRight()
        {
            if (!robot.IsRobotPlacedOnTable)
            {
                Console.WriteLine("Robot is not placed on the table. Use PLACE command first.");
                return;
            }

            robot.TurnRight();
        }

        public void ReportRobotStatus()
        {
            Console.WriteLine(robot.ReportPosition());
        }
    }
}
