// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using PRM.Models;

namespace PRM.Algorithms
{
    public class PersiptronAlgorithm
    {
        private readonly int _classCount;
        private readonly int _vectorsSize;

        public PersiptronAlgorithm(int classCount, int vectorsSize)
        {
            _classCount = classCount;
            _vectorsSize = vectorsSize;
        }

        public PersiptronResult GetResult(Vector[][] teachingVectors)
        {
            var result = new PersiptronResult
            {
                SepareteFunctions = EmptyFunctions().ToArray()
            };
            var nextIteration = true;
            var iterationNumber = 0;

            while (nextIteration && iterationNumber < 1000)
            {
                iterationNumber++;
                nextIteration = PersiptronIteration(teachingVectors, result.SepareteFunctions);
            }

            if (iterationNumber == 1000)
            {
                result.HasWarning = true;
            }

            return result;
        }

        private IEnumerable<PersiptronFunction> EmptyFunctions() =>
            Enumerable.Range(1, _classCount).Select(x => new PersiptronFunction(_vectorsSize));

        private bool PersiptronIteration(IReadOnlyList<Vector[]> teachingVectors, PersiptronFunction[] result)
        {
            if (teachingVectors.Count != _classCount) { throw new Exception(); }

            var nextIteration = false;

            for (var classNumber = 0; classNumber < _classCount; classNumber++)
            {
                for (var i = 0; i < teachingVectors[classNumber].Length; i++)
                {
                    if (WorkWithVector(teachingVectors[classNumber][i], result, classNumber))
                    {
                        nextIteration = true;
                    }
                }
            }

            return nextIteration;
        }

        private bool WorkWithVector(Vector currentVector, PersiptronFunction[] result, int vectorsClass)
        {
            var maxClass = GetMaxVectorClass(result, currentVector);

            if (maxClass != vectorsClass)
            {
                Panish(currentVector, result, vectorsClass);
            }

            return maxClass != vectorsClass;
        }

        private void Panish(Vector currentVector, IList<PersiptronFunction> result, int vectorsClass)
        {
            for (var i = 0; i < _classCount; i++)
            {
                result[i] += ((i == vectorsClass ? 1 : -1) * currentVector);
            }
        }

        public int GetMaxVectorClass(PersiptronFunction[] result, Vector currentVector)
        {
            var max = result[0].GetValue(currentVector);
            var maxClass = 0;
            var maxCount = 1;

            for (var i = 1; i < _classCount; i++)
            {
                var currentValue = result[i].GetValue(currentVector);

                if (currentValue > max)
                {
                    maxCount = 0;
                    max = currentValue;
                    maxClass = i;
                }

                if (currentValue == max)
                {
                    maxCount++;
                }
            }

            return maxCount == 1 ? maxClass : -1;
        }
    }
}
