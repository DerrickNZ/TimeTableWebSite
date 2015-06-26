using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTableWeb.Areas.Occupation.Models
{
    public class OccupationList1ViewModel
    {
        //Occupation Code
        public string Code { get; set; }

        //Occupation Count
        public int Count { get; set; }

        //Arc Begin Aadian
        public double ArcBegin { get; set; }

        //Arc End Aadian
        public double ArcEnd { get; set; }

        //Element Color
        public string Color { get; set; }
    }
}