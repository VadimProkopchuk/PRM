using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PRM.Models.Calculators;

namespace PRM.Models.KMeans
{
    public class KMeans
    {
        private List<Point> _points;
        private Point _centerPoint;
        private readonly object _lock = new object();

        public KMeans(Point center)
        {
            _points = new List<Point>();
            _points.Add(_centerPoint = center);
        }

        public Point GetRecalculatedCenter()
        {
            var averageCenter = new Point(_points.Average(x => x.X), _points.Average(x => x.Y));
            var distance = Double.MaxValue;
            var recalculatedPoint = new Point();

            foreach (var point in _points)
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
            _points.Clear();
            _points = new List<Point> {_centerPoint};
        }

        public bool CompareCenter(Point point) => _centerPoint == point;

        public void ChangeCenter(Point point) => _centerPoint = point;

        public double GetDistanceToCenter(Point point) => _centerPoint.GetDistance(point);

        public void Add(Point point)
        {
            lock (_lock)
            {
                _points.Add(point);
            }
        } 

        public IEnumerable<Point> GetPoints() => this._points;
    }
}