using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
    public class RangeOfDatesModel
    {
        public DateTime FromDate { get; set; } = DateTime.Today;
        public DateTime UntilDate { get; set; } = DateTime.Today;

    }
}
