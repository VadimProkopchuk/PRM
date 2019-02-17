using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PRM.Models.Calculators;

namespace PRM.Models
{
    public class AreaPoints
    {
        protected List<Point> Points;
        protected Point Core;
        protected readonly object Lock = new object();

        public AreaPoints(Point core) => Points = new List<Point> { (Core = core) };

        public Point GetRecalculatedCenter()
        {
            var averageCenter = new Point(Points.Average(x => x.X), Points.Average(x => x.Y));
            var distance = double.MaxValue;
            var recalculatedPoint = new Point();

            foreach (var point in Points)
            {
                var diff = averageCenter.GetDistance(point);

                if (diff < distance)
                {
                    distance = diff;
                    recalculatedPoint = point;
                }
            }

            return recalculatedPoint;
        }

        public void ClearPointsWithSaveCenter()
        {
            Points.Clear();
            Points = new List<Point> { Core };
        }

        public bool CompareCore(Point point) => Core == point;

        public void ChangeCore(Point point) => Core = point;

        public double GetDistanceToCenter(Point point) => Core.GetDistance(point);

        public double GetDistanceToCenter(AreaPoints areaPoints) => Core.GetDistance(areaPoints.Core);

        public void Add(Point point)
        {
            lock (Lock)
            {
                Points.Add(point);
            }
        }

        public IEnumerable<Point> GetPoints() => Points;
    }
}
