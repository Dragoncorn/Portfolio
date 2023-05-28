namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            for(int i=0; i < width - 3 + height-3; i++)
            {
                if (i < width - 3)
                    robot.MoveTo(Direction.Right);
                else
                    robot.MoveTo(Direction.Down);
            }
        }
    }
}