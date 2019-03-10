// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Windows;
using PRM.Models;

namespace PRM.Algorithms.Core
{
    public abstract class BasedAreaPointsAlgorithm
    {
        protected readonly List<Point> Points;
        protected List<AreaPoints> AreaPointsList;

        protected BasedAreaPointsAlgorithm(List<Point> points)
        {
            Points = points;
        }

        protected void AddPointToClass(Point point)
        {
            var diffClass = GetDiffClass(point);

            if (diffClass != default(AreaPoints))
            {
                diffClass.Add(point);
            }
        }

        private AreaPoints GetDiffClass(Point point)
        {
            var diff = Double.MaxValue;
            var diffClass = default(AreaPoints);

            foreach (var areaPoints in AreaPointsList)
            {
                if (areaPoints.CompareCore(point))
                {
                    return default(AreaPoints);
                }

                var different = areaPoints.GetDistanceToCenter(point);

                if (different < diff)
                {
                    diff = different;
                    diffClass = areaPoints;
                }
            }

            return diffClass;
        }
    }
}
