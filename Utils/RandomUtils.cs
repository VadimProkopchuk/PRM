using System;
using System.Collections.Generic;
using System.Windows;

namespace PRM.Utils
{
    public static class RandomUtils
    {
        public static IEnumerable<Point> GenerateRandomPoints(this int countOfPOints, int maxX, int maxY)
        {
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < countOfPOints; i++)
            {
                yield return new Point(random.Next(maxX), random.Next(maxY));
            }
        }

        public static IEnumerable<int> GenerateRandomNumbers(this int countOfPoints, int min, int max)
        {
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < countOfPoints; i++)
            {
                yield return random.Next(min, max);
            }
        }
    } 
} 