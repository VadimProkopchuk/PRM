using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRM.Models.KMeans;
using PRM.Utils;

namespace PRM.Algorithms
{
    public class KMeansAlgorithm
    {
        private readonly List<Point> _points;
        private readonly List<KMeans> _kMeansList;
        private readonly object _lock = new object();
        private bool _isRecalculateNecessary;

        public KMeansAlgorithm(IEnumerable<Point> points, int countOfClasses)
        {
            _points = points.ToList();
            _kMeansList = GenerateKMeansList(countOfClasses);
        }

        public async Task<List<KMeans>> GetResultAsync()
        {
            return await Task.Run(() =>
            {
                do
                {
                    _isRecalculateNecessary = false;
                    Parallel.ForEach(_kMeansList, x => x.ClearPointsWithSaveCenter());
                    Parallel.ForEach(_points, AddPointToClass);
                    Parallel.ForEach(_kMeansList, RecalculateCenter);

                } while (_isRecalculateNecessary);

                return _kMeansList;
            });
        }

        private List<KMeans> GenerateKMeansList(int countOfClasses)
            => _points.GenerateCenters(countOfClasses).Select(x => new KMeans(x)).ToList();

        private void AddPointToClass(Point point)
        {
            var diffClass = GetDiffClass(point);

            if (diffClass != default(KMeans))
            {
                diffClass.Add(point);
            }
        }

        private KMeans GetDiffClass(Point point)
        {
            var diff = Double.MaxValue;
            var diffClass = default(KMeans);

            foreach (var kMean in _kMeansList)
            {
                if (kMean.CompareCenter(point))
                {
                    return default(KMeans);
                }

                var different = kMean.GetDistanceToCenter(point);

                if (different < diff)
                {
                    diff = different;
                    diffClass = kMean;
                }
            }

            return diffClass;
        }

        private void RecalculateCenter(KMeans kMean)
        {
            var recalculatedCenter = kMean.GetRecalculatedCenter();

            if (!kMean.CompareCenter(recalculatedCenter))
            {
                kMean.ChangeCenter(recalculatedCenter);

                lock (_lock)
                {
                    _isRecalculateNecessary = true;
                }
            }
        }
    }
}