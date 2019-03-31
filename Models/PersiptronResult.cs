// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

namespace PRM.Models
{
    public class PersiptronResult
    {
        public bool HasWarning { get; set; }
        public PersiptronFunction[] SepareteFunctions { get; set; }
    }
}