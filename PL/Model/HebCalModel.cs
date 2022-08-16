using BL;
using HebDates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
    public class HebCalModel
    {
        IBL bl = new BLImp();
        public List<HebDates.DateAndStatus> dateAndStatuses;
        public HebCalModel()
        {
            dateAndStatuses = new List<HebDates.DateAndStatus>();
        }
        public HebDates.DateAndStatus ReturnStatusOfDate(DateTime date)
        {
            
            foreach (HebDates.DateAndStatus var in dateAndStatuses)
            {
                if (var.Date == date)
                    return var;
            }
            string status = bl.ReturnStatusOfDate(date);
            var DS=new HebDates.DateAndStatus()
            {
                    Date = date,
                    Status = status,
            };
            dateAndStatuses.Add(DS);
            return DS;


            
        }
            

    }
}
