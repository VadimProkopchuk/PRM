using System;
using System.Collections.Generic;
using System.Linq;
using PRM.Models;
using PRM.Utils;

namespace PRM.Algorithms
{
    public sealed class ProbablisticApproachAlgorithm
    {
        private readonly double _eps;

        public ProbablisticApproachAlgorithm(double eps)
        {
            _eps = eps;
        }

        public ProbablisticApproachResult GetResult(double pc1, int countOfPoints, int countOfGraphPoints)
        {
            var pc2 = 1 - pc1;
            var result = new ProbablisticApproachResult
            {
                FirstLine = GetResult(countOfPoints.GenerateRandomNumbers(0, (int)(countOfGraphPoints * 0.8)), pc1, countOfGraphPoints).ToArray(),
                SecondLine = GetResult(countOfPoints.GenerateRandomNumbers((int)(countOfGraphPoints * 0.2), countOfGraphPoints),
                    pc2, countOfGraphPoints).ToArray()
            };

            var intersectionPoint = GetIntersectionPoint(result.FirstLine, result.SecondLine);

            result.FalseProbability = result.SecondLine.Take(intersectionPoint).Sum();
            result.SkipProbability = (pc1 > pc2 ? result.SecondLine : result.FirstLine).Skip(intersectionPoint).Sum();

            return result;
        }

        private IEnumerable<double> GetResult(IEnumerable<int> initialPoints, double probablistic, int countOfGraphPoints)
        {
            var initialPointsList = initialPoints.ToList();
            var mx = initialPointsList.Average();
            var sigma = initialPointsList.Aggregate(0d, (accum, item) => accum += Math.Pow(item - mx, 2), accum => Math.Sqrt(accum / initialPointsList.Count));

            for (var i = 0; i < countOfGraphPoints; i++)
            {
                yield return Math.Exp(-0.5 * Math.Pow((i - mx) / sigma, 2)) / (sigma * Math.Sqrt(2 * Math.PI)) * probablistic;
            }
        }

        private int GetIntersectionPoint(double[] first, double[] second)
        {
            for (var i = 0; i < first.Length; i++)
                if (Math.Abs(first[i] - second[i]) < _eps)
                    return i;

            return 0;
        }
    }
}
