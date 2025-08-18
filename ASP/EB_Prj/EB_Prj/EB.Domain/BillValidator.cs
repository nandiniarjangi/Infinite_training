using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.Domain
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            return unitsConsumed < 0 ? "Given units is invalid" : null;
        }
    }
}