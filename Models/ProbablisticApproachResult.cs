// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

namespace PRM.Models
{
    public class ProbablisticApproachResult
    {
        public double[] FirstLine { get; set; }
        public double[] SecondLine { get; set; }
        public double FalseProbability { get; set; }
        public double SkipProbability { get; set; }
    }
}
