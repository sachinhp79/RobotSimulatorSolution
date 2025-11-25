using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Application.Interfaces
{
    public interface ISimulationService
    {
        void MoveRobot();
        void PlaceRobot(int xCoordinate, int yCoordinate, Direction direction);
        void MoveRobotToLeft();
        void MoveRobotToRight();
        void ReportRobotStatus();
    }
}
