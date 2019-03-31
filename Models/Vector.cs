// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

namespace PRM.Models
{
    public class Vector
    {
        public Vector(int size) => Elements = new int[size];

        public int[] Elements { get; set; }

        public static Vector operator *(int integer, Vector vector)
        {
            var result = new Vector(vector.Elements.Length);

            for (var i = 0; i < vector.Elements.Length; i++)
            {
                result.Elements[i] *= integer;
            }

            return result;
        }
    }
}