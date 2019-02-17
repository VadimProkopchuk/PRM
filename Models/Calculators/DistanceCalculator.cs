using System;
using System.Windows;

namespace PRM.Models.Calculators
{
    public static class DistanceCalculator
    {
        public static double GetDistance(this Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(GetSqrtAxis(x => x.X) + GetSqrtAxis(x => x.Y));

            double GetSqrtAxis(Func<Point, double> getAxisValue) => Math.Pow(getAxisValue(firstPoint) - getAxisValue(secondPoint), 2);
        }
    }
}