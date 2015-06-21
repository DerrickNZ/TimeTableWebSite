using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TimeTableBOL
{
    public class Applicant
    {
        //Applicant ID
        [Key]
        public int ApplicantID { get; set; }

        //Applicant Display Name
        [StringLength(50)]
        [Required]
        public string ApplicantName { get; set; }

        //Date of Birth
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        //Total Score
        [Range(0, 100)]
        [Required]
        public int Score { get; set; }

        //Applicant Display Name
        [StringLength(6)]
        [Required]
        public string OccupationCode { get; set; }

        //Step1 Finished Time
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? StepOne { get; set; }

        //Step2 Finished Time
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? StepTwo { get; set; }

        //Step3 Finished Time
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? StepThree { get; set; }

        //Step4 Finished Time
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? StepFour { get; set; }
    }
}
