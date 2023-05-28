using System;

namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            bool firstStepDown = IsFirstStepDown(width, height);
            var countStep = (Math.Min(width, height) - 2);
            int stepdown = GetDownValue(width, height);
            int stepright = GetRightValue(width, height);
            Run(countStep, firstStepDown,robot, stepdown, stepright);
        }

        public static void Run(int countStep, bool firstStepDown,Robot robot,int stepdown, int stepright)
        {
            for (int i = 0; i < countStep * 2 - 1; i++)
            {
                if (firstStepDown)
                    MoveDown(stepdown, robot);
                else
                    MoveRight(stepright, robot);
                firstStepDown = !firstStepDown;
            }
        }

        public static int GetDownValue(int width, int height)
        {
            if (width > height)
                return 1;
            else
                return (Math.Max(width, height) - 2) / (Math.Min(width, height) - 2);
        }

        public static int GetRightValue(int width, int height)
        {
            if (width > height)
                return (Math.Max(width, height) - 2) / (Math.Min(width, height) - 2);
            else
                return 1;
        }

        public static bool IsFirstStepDown(int width, int height)
        {
            return height > width;
        }

        public static void MoveRight(int rightOrLeft, Robot robot)
        {
            for (int i = 0; i < rightOrLeft; i++)
                robot.MoveTo(Direction.Right);
        }

        public static void MoveDown(int stepdown, Robot robot)
        {
            for (int i = 0; i < stepdown; i++)
                robot.MoveTo(Direction.Down);
        }
    }
}