using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableBLL
{
    //Base Result
    public class CommonResult
    {
        //Success
        public bool Success { get; set; }

        //ErrorMessage
        public string ErrorMessage { get; set; }
    }

    //Occupation List Result
    public class OccupationResult : CommonResult
    {
        //Occupation Dictionary
        public IDictionary<string, int> OccupationList { get; set; }

        //Total Items in the list
        public int Total { get; set; }
    }
}
