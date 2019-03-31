// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System.Collections.Generic;
using System.Text;
using PRM.Models;

namespace PRM.Algorithms.Providers
{
    public class PersiptronTextResultProvider
    {
        public string GetTextResult(int classCount, int vectorsCount, int vectorsSize, Vector[][] vectors,
            PersiptronFunction[] functions)
        {
            var builder = new StringBuilder();

            GetTextTeachingResult(classCount, vectorsCount, vectorsSize, vectors, builder);
            builder.AppendLine();
            builder.AppendLine();
            builder.AppendLine("Separated Functions:");
            builder.AppendLine();
            GetTextFunctions(classCount, vectorsSize, functions, builder);

            return builder.ToString();
        }

        private static void GetTextTeachingResult(int classCount, int vectorsCount, int vectorsSize, 
            IReadOnlyList<Vector[]> vectors, StringBuilder builder)
        {
            for (var i = 0; i < classCount; i++)
            {
                builder.AppendLine($"{i + 1} Class: ");

                for (var j = 0; j < vectorsCount; j++)
                {
                    builder.Append("(");

                    for (var k = 0; k < vectorsSize; k++)
                    {
                        builder.Append($"{vectors[i][j].Elements[k]}; ");
                    }

                    builder.AppendLine(")");
                }
            }
        }

        private static void GetTextFunctions(int classCount, int vectorsSize, IReadOnlyList<PersiptronFunction> functions, 
            StringBuilder builder)
        {
            for (var i = 0; i < classCount; i++)
            {
                builder.Append($"d({i + 1})  = ");

                for (var j = 0; j < vectorsSize; j++)
                {
                    if (j != 0 && functions[i].Elements[j] >= 0)
                    {
                        builder.Append("+");
                    }

                    builder.Append($"{functions[i].Elements[j]}*x{j + 1}");
                }

                if (functions[i].Elements[vectorsSize] >= 0)
                {
                    builder.Append("+");
                }

                builder.AppendLine(functions[i].Elements[vectorsSize].ToString());
            }
        }
    }
}