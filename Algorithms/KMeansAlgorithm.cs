using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRM.Models;
using PRM.Utils;

namespace PRM.Algorithms
{
    public class KMeansAlgorithm
    {
        private readonly List<Point> _points;
        private readonly List<AreaPoints> _areaPointsList;
        private readonly object _lock = new object();
        private bool _isRecalculateNecessary;

        public KMeansAlgorithm(IEnumerable<Point> points, int countOfClasses)
        {
            _points = points.ToList();
            _areaPointsList = GenerateAreaPointsList(countOfClasses);
        }

        public async Task<List<AreaPoints>> GetResultAsync()
        {
            return await Task.Run(() =>
            {
                do
                {
                    _isRecalculateNecessary = false;
                    Parallel.ForEach(_areaPointsList, x => x.ClearPointsWithSaveCenter());
                    Parallel.ForEach(_points, AddPointToClass);
                    Parallel.ForEach(_areaPointsList, RecalculateCenter);

                } while (_isRecalculateNecessary);

                return _areaPointsList;
            });
        }

        private List<AreaPoints> GenerateAreaPointsList(int countOfClasses)
            => _points.GenerateCenters(countOfClasses).Select(x => new AreaPoints(x)).ToList();

        private void AddPointToClass(Point point)
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

            foreach (var areaPoints in _areaPointsList)
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

        private void RecalculateCenter(AreaPoints areaPoints)
        {
            var recalculatedCenter = areaPoints.GetRecalculatedCenter();

            if (!areaPoints.CompareCore(recalculatedCenter))
            {
                areaPoints.ChangeCore(recalculatedCenter);

                lock (_lock)
                {
                    _isRecalculateNecessary = true;
                }
            }
        }
    }
}