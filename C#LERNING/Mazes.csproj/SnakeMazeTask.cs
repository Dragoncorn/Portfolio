using System;

namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            var steps = GetCountComandToFinish(height);
            var rightOrLeft = width-3;
            StartMove(robot, steps, rightOrLeft);
        }
       
        public static int GetCountComandToFinish( int height)
        {
            return height - 2;
        }

        public static void MoveRight(int rightOrLeft, Robot robot)
        {
            for (int i = 0; i < rightOrLeft; i++)
                robot.MoveTo(Direction.Right);
        }

        public static void MoveLeft(int rightOrLeft, Robot robot)
        {
            for (int i = 0; i < rightOrLeft; i++)
                robot.MoveTo(Direction.Left);
        }

        public static void MoveDown( Robot robot)
        {
            for (int i = 0; i < 2; i++)
                robot.MoveTo(Direction.Down);
        }

        public static void StartMove(Robot robot, int steps, int rightOrLeft)
        {
            for (int i = 1; i < steps + 1; i++)
            {
                if (i % 4 == 1)
                    MoveRight(rightOrLeft, robot);
                else if (i % 4 == 2)
                    MoveDown(robot);
                else if (i % 4 == 3)
                    MoveLeft(rightOrLeft, robot);
                else
                    MoveDown(robot);
            }
        }
    }
}