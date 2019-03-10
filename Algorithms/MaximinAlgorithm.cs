// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRM.Algorithms.Core;
using PRM.Models;
using PRM.Models.Calculators;

namespace PRM.Algorithms
{
    public class MaximinAlgorithm : BasedAreaPointsAlgorithm
    {
        private readonly object _lock = new object();
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        public MaximinAlgorithm(IEnumerable<Point> points) : base (points.ToList())
        {
            AreaPointsList = GenerateCore();
        }

        public async Task<List<AreaPoints>> GetResultAsync()
        {
            return await Task.Run(() =>
            {
                Point? core;

                do
                {
                    Parallel.ForEach(AreaPointsList, x => x.ClearPointsWithSaveCenter());
                    Parallel.ForEach(Points, AddPointToClass);

                    AddCore(core = RecalculateCore());
                } while (core.HasValue);

                return AreaPointsList;
            });
        }

        private List<AreaPoints> GenerateCore()
            => new List<AreaPoints> { new AreaPoints(Points[_random.Next(Points.Count)]) };

        private Point? RecalculateCore()
        {
            var avgDistance = AreaPointsList.GetAvgCoreDistance();
            var coreCandidate = GetPointWithMaxDistance(GetClassesMaxPoints());

            return coreCandidate.Distance > avgDistance / 2 ? coreCandidate.Point : default(Point?);
        }

        private PointDistance GetPointWithMaxDistance(IEnumerable<PointDistance> points)
        {
            var maxPoint = new PointDistance();

            Parallel.ForEach(points, point =>
            {
                if (point.Distance > maxPoint.Distance)
                    maxPoint = point;
            });

            return maxPoint;
        }

        private IEnumerable<PointDistance> GetClassesMaxPoints()
        {
            foreach (var areaPoints in AreaPointsList)
                yield return GetMaxPointDistance(areaPoints);
        }

        private PointDistance GetMaxPointDistance(AreaPoints areaPoints)
        {
            var maxPoint = new PointDistance();

            Parallel.ForEach(areaPoints.GetPoints(), point =>
            {
                var distance = areaPoints.GetDistanceToCenter(point);

                if (distance > maxPoint.Distance)
                {
                    maxPoint = new PointDistance
                    {
                        Distance = distance,
                        Point = point
                    };
                }
            });

            return maxPoint;
        }

        private void AddCore(Point? core)
        {
            if (core.HasValue)
            {
                lock (_lock)
                {
                    AreaPointsList.Add(new AreaPoints(core.Value));
                }
            }
        }
    }
}
