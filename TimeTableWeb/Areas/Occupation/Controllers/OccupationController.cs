﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTableBLL;
using TimeTableWeb.Areas.Occupation.Models;

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
            if (result.Success)
            {
                //Success
                //Pass Result.Total tp ViewBag
                ViewBag.Total = result.Total;

                //Creat ViewModel
                List<OccupationList1ViewModel> list = new List<OccupationList1ViewModel>();

                //Record Last Radian
                double last = 0;

                //Color Random
                Random rand = new Random();

                foreach (var item in result.OccupationList)
                {
                    //Calculate the of Each Arc 
                    list.Add(new OccupationList1ViewModel()
                    {
                        Code = item.Key,
                        Count = item.Value,
                        ArcBegin = last,
                        ArcEnd = last + 2 * Math.PI * (double)item.Value / result.Total,
                        Color = rand.Next(256).ToString("X2") + rand.Next(256).ToString("X2") + rand.Next(256).ToString("X2")
                    });
                    //Set last equals to Arc End
                    last = last + 2 * Math.PI * (double)item.Value / result.Total;
                }

                //Pass List to View
                return View(list);
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

        // GET: Occupation/Occupation/List4
        [HttpGet]
        public ActionResult List4()
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

        // Post: Occupation/Occupation/List4
        // Ajax return request appliant list
        [HttpPost]
        public ActionResult List4(string code)
        {
            //if the param is null or empty
            if (string.IsNullOrEmpty(code))
            {
                return new EmptyResult();
            }

            //Get result
            var result = service.GetApplicantByOccupation(code);

            //Check if the result is successful
            if (result.Success)
            {
                //Success
                //Check if the result is empty
                if (result.Applicants.Count() == 0)
                {
                    //The list is empty
                    return new EmptyResult();
                }

                //Deal the data
                List<ApplicantDetailInOccupationViewModel> list = new List<ApplicantDetailInOccupationViewModel>();

                //Convert Applicant to ViewModel
                foreach (var applicant in result.Applicants)
                {
                    list.Add(new ApplicantDetailInOccupationViewModel(applicant));
                }

                var j = Json(list);

                return j;
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