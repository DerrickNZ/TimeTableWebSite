using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTableBLL;
using TimeTableWeb.Areas.TimeLine.Models;

namespace TimeTableWeb.Areas.TimeLine.Controllers
{
    public class TimeLineController : Controller
    {
        ApplicantBLL service = new ApplicantBLL();

        // GET: TimeLine/TimeLine/Line1
        public ActionResult Line1()
        {
            //Get all applicants
            var result = service.GetAllApplicants();

            //Check the result is success
            if(result.Success)
            {
                //Success
                //Create ViewModel List
                List<ApplicantTimeLineViewModel> list = new List<ApplicantTimeLineViewModel>();
                
                //add applicant to the list
                foreach (var applicant in result.Applicants)
                {
                    list.Add(new ApplicantTimeLineViewModel(applicant));
                }

                return View(list);

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