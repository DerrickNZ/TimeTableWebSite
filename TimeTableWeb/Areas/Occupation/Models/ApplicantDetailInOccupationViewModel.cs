using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeTableBOL;

namespace TimeTableWeb.Areas.Occupation.Models
{
    public class ApplicantDetailInOccupationViewModel
    {
        //Applicant ID
        public int ApplicantID { get; set; }

        //Applicant Display Name
        public string ApplicantName { get; set; }

        //Date of Birth
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        //Total Score
        public int Score { get; set; }

        public ApplicantDetailInOccupationViewModel(Applicant applicant)
        {
            this.ApplicantID = applicant.ApplicantID;
            this.ApplicantName = applicant.ApplicantName;
            this.DateOfBirth = applicant.DateOfBirth;
            this.Score = applicant.Score;
        }
    }
}