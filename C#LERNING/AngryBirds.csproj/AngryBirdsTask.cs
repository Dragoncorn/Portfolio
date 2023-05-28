using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		// Ниже — это XML документация, её использует ваша среда разработки, 
		// чтобы показывать подсказки по использованию методов. 
		// Но писать её естественно не обязательно.
		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
            //return Math.PI / 4;
            double rast = 0;
            double eagle=0;
            eagle =Math.Asin(distance * 9.8 / (Math.Pow(v,2)))/2;
            rast=v*v*Math.Sin(2*eagle)/ 9.8;
            if (eagle <= Math.PI/2)
                return eagle;
            else
                return double.NaN; //double.NaN;
        }
	}
}