using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightModel
{
    public class HelperClass
    {
        public HelperClass()
        {

        }
        //Helper Function to convert from UnixEpoch time to Human DataTimes.
        public DateTime GetDataTimeFromEpoch(int EpochTimeStamp)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);//from start epoch time
            start = start.AddSeconds(EpochTimeStamp);//add the seconds to the start DataTime.
            return start;
        }
    }
}
