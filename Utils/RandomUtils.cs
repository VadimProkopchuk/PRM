// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Vector = PRM.Models.Vector;

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

        public static Vector[][] GetRandomVectors(this int classCount, int vectorsCount, int vectorsSize)
        {
            var vectors = new Vector[classCount][];

            for (var i = 0; i < classCount; i++)
            {
                vectors[i] = new Vector[vectorsCount];

                for (var j = 0; j < vectorsCount; j++)
                {
                    vectors[i][j] = new Vector(vectorsSize + 1)
                    {
                        Elements = vectorsSize.GenerateRandomNumbers(-10, 10).ToArray()
                    };
                    vectors[i][j].Elements[vectorsSize] = 1;
                }
            }

            return vectors;
        }
    } 
} 