// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Linq;

namespace PRM.Models
{
    public class PersiptronFunction
    {
        public PersiptronFunction(int size) => Elements = new int[size];

        public int[] Elements { get; set; }

        public int GetValue(Vector vector)
        {
            if (vector.Elements.Length != Elements.Length) {throw new Exception();}

            return vector.Elements.Select((t, i) => t * Elements[i]).Sum();
        }

        public static PersiptronFunction operator +(PersiptronFunction function, Vector vector)
        {
            if (function.Elements.Length != vector.Elements.Length) {throw new Exception();}

            var result = new PersiptronFunction(function.Elements.Length);

            for (var i = 0; i < function.Elements.Length; i++)
            {
                result.Elements[i] = function.Elements[i] + vector.Elements[i];
            }

            return result;
        }
    }
}