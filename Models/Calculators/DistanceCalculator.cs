// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
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

        public static double GetAvgCoreDistance(this List<AreaPoints> areaPointsList)
        {
            var distanceSum = 0d;

            for (var i = 0; i < areaPointsList.Count; i++)
            for (var j = i + 1; j < areaPointsList.Count; j++)
                distanceSum += areaPointsList[i].GetDistanceToCenter(areaPointsList[j]);

            var count = (int) (Math.Pow(areaPointsList.Count, 2) / 2);

            return count == 0 ? 0 : distanceSum / count;
        }
    }
}