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
                return;

            Position newPosition = robot.MoveToNextPosition();

            if (table.IsValidPosition(newPosition))
            {
                robot.UpdatePosition(newPosition);
            }
        }

        public void PlaceRobot(int xCoordinate, int yCoordinate, Direction direction)
        {
            var position = new Position(xCoordinate, yCoordinate);

            if (!table.IsValidPosition(position))
            {
                return;
            }

            robot.Place(position, direction);
        }

        public void MoveRobotToLeft()
        {
            if (!robot.IsRobotPlacedOnTable)
                return;

            robot.TurnLeft();
        }

        public void MoveRobotToRight()
        {
            if (!robot.IsRobotPlacedOnTable)
                return;

            robot.TurnRight();
        }

        public void ReportRobotStatus()
        {
            Console.WriteLine(robot.ReportPosition());
        }
    }
}
