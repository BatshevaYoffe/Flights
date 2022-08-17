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
        public HebCalModel()
        {
        }
        public async Task<HebDates.DateAndStatus> ReturnStatusOfDate(DateTime date)
        {

           string status =await bl.ReturnStatusOfDate(date);
            var DS = new HebDates.DateAndStatus()
            {
                Date = date,
                Status = status,
            };
           
            return DS;



        }


    }
}
