using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRM.Algorithms.Core;
using PRM.Models;
using PRM.Utils;

namespace PRM.Algorithms
{
    public class KMeansAlgorithm : BasedAreaPointsAlgorithm
    {
        private readonly object _lock = new object();
        private bool _isRecalculateNecessary;

        public KMeansAlgorithm(IEnumerable<Point> points, int countOfClasses) : base(points.ToList())
        {
            AreaPointsList = GenerateAreaPointsList(countOfClasses);
        }

        public async Task<List<AreaPoints>> GetResultAsync()
        {
            return await Task.Run(() =>
            {
                do
                {
                    _isRecalculateNecessary = false;
                    Parallel.ForEach(AreaPointsList, x => x.ClearPointsWithSaveCenter());
                    Parallel.ForEach(Points, AddPointToClass);
                    Parallel.ForEach(AreaPointsList, RecalculateCenter);

                } while (_isRecalculateNecessary);

                return AreaPointsList;
            });
        }

        private List<AreaPoints> GenerateAreaPointsList(int countOfClasses)
            => Points.GenerateCenters(countOfClasses).Select(x => new AreaPoints(x)).ToList();

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