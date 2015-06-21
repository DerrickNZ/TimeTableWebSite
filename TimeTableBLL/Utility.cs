using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableBLL
{
    internal static class Utility
    {
        //Get Error Message from Exception
        internal static string GetErrorMessage(Exception ee)
        {
            if (ee.InnerException == null)
            {
                return ee.Message;
            }
            else
            {
                return ee.Message + Environment.NewLine + ee.InnerException.Message;
            }
        }
    }
}
