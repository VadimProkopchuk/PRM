// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Drawing;
using PRM.Models;

namespace PRM.Algorithms
{
    public class PotentialsAlgorithm
    {
        private const int ClassCount = 2;
        private const int IterationsCount = 50;

        private int _correction;

        public PotentialsResult GetResult(Point[][] teachingPoints)
        {
            var function = new PotentialsFunction(0, 0, 0, 0);
            var result = new PotentialsResult();
            var nextIteration = true;
            var iterationNumber = 0;

            _correction = 1;

            while (nextIteration && iterationNumber < IterationsCount)
            {
                iterationNumber++;
                nextIteration = PotentialsIteration(teachingPoints, ref function);
            }

            if (iterationNumber == IterationsCount)
            {
                result.HasWarning = true;
            }

            result.Function = function;

            return result;
        }

        private bool PotentialsIteration(IReadOnlyList<Point[]> teachingPoints, ref PotentialsFunction result)
        {
            var nextIteration = false;

            if (teachingPoints.Count != ClassCount) {throw new Exception();}

            for (var classNumber = 0; classNumber < ClassCount; classNumber++)
            {
                for (var i = 0; i < teachingPoints[classNumber].Length; i++)
                {
                    result += _correction * PartFunction(teachingPoints[classNumber][i]);

                    var index = (i + 1) % teachingPoints[classNumber].Length;
                    var nextClassNumber = index == 0 ? (classNumber + 1) % ClassCount : classNumber;
                    var nextPoint = teachingPoints[nextClassNumber][index];

                    _correction = GetNewCorrection(nextPoint, result, nextClassNumber);

                    if (_correction != 0)
                    {
                        nextIteration = true;
                    }
                }
            }

            return nextIteration;
        }

        private static int GetNewCorrection(Point nextPoint, PotentialsFunction result, int nextClassNumber)
        {
            var functionValue = result.GetValue(nextPoint);

            if (functionValue <= 0 && nextClassNumber == 0) {return 1;}

            return functionValue > 0 && nextClassNumber == 1 ? -1 : 0;
        }

        private static PotentialsFunction PartFunction(Point point) => new PotentialsFunction(4 * point.X, 4 * point.Y, 16 * point.X * point.Y, 1);
    }
}
