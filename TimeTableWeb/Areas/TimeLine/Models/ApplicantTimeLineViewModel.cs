using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeTableBOL;

namespace TimeTableWeb.Areas.TimeLine.Models
{
    public class ApplicantTimeLineViewModel
    {
        //Applicant ID
        public int ApplicantID { get; set; }

        //Applicant Display Name
        public string ApplicantName { get; set; }

        //Step1 Finished Time
        [DataType(DataType.Date)]
        public DateTime? StepOne { get; set; }

        //Step2 Finished Time
        [DataType(DataType.Date)]
        public DateTime? StepTwo { get; set; }

        //Step3 Finished Time
        [DataType(DataType.Date)]
        public DateTime? StepThree { get; set; }

        //Step4 Finished Time
        [DataType(DataType.Date)]
        public DateTime? StepFour { get; set; }

        //Constructor
        public ApplicantTimeLineViewModel(Applicant applicant)
        {
            this.ApplicantID = applicant.ApplicantID;
            this.ApplicantName = applicant.ApplicantName;
            this.StepOne = applicant.StepOne;
            this.StepTwo = applicant.StepTwo;
            this.StepThree = applicant.StepThree;
            this.StepFour = applicant.StepFour;
        }
    }
}