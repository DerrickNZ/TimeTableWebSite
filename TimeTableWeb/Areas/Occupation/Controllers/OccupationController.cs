using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTableBLL;

namespace TimeTableWeb.Areas.Occupation.Controllers
{
    public class OccupationController : Controller
    {
        ApplicantBLL service = new ApplicantBLL();

        // GET: Occupation/Occupation/List1
        public ActionResult List1()
        {
            //get occupation result
            var result = service.GetOccupationCode();

            //Check result 
            if(result.Success)
            {
                //Success
                //Pass Result.Total tp ViewBag
                ViewBag.Total = result.Total;

                //Pass List to View
                return View(result.OccupationList);
            }
            else
            {
                //Fail
                //TODO: Go to Error Page
                return View();
            }
        }

        // GET: Occupation/Occupation/List2
        public ActionResult List2()
        {
            //get occupation result
            var result = service.GetOccupationCode();

            //Check result 
            if (result.Success)
            {
                //Success
                //Pass Result.Total tp ViewBag
                ViewBag.Total = result.Total;

                //Pass List to View
                return View(result.OccupationList);
            }
            else
            {
                //Fail
                //TODO: Go to Error Page
                return View();
            }
        }

        // GET: Occupation/Occupation/List3
        public ActionResult List3()
        {
            //get occupation result
            var result = service.GetOccupationCode();

            //Check result 
            if (result.Success)
            {
                //Success
                //Pass Result.Total tp ViewBag
                ViewBag.Total = result.Total;

                //Pass List to View
                return View(result.OccupationList);
            }
            else
            {
                //Fail
                //TODO: Go to Error Page
                return View();
            }
        }

    }
}