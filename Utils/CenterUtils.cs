// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PRM.Utils
{
    public static class CenterUtils
    {
        public static IEnumerable<Point> GenerateCenters(this List<Point> points, int countOfClasses)
        {
            var selectedCenters = new List<Point>();
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < countOfClasses; i++)
            {
                yield return points.GetRandomCenter(selectedCenters, random);
            }
        }

        private static Point GetRandomCenter(this IReadOnlyCollection<Point> points, ICollection<Point> selectedCenters, Random random)
        {
            Point center;

            do
            {
                center = points.ElementAt(random.Next(points.Count));
            } while (selectedCenters.Contains(center));

            return center;
        }
    }
}
