﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTableBOL;
using TimeTableDAL;

namespace TimeTableBLL
{
    public class ApplicantBLL
    {
        ApplicantDAL dal = new ApplicantDAL();

        //Get All Applicants
        public IEnumerable<Applicant> GetAllApplicants()
        {
            return dal.GetApplicants();
        }

        //Get Occupation Code Statistics
        public OccupationResult GetOccupationCode()
        {
            try
            {
                //Get All Occupation Codes from DB
                var originaList = dal.GetProperty<string>(e => e.OccupationCode);

                //Get total items in originaList
                int total = originaList.Count();

                //Distinct the duplicated
                var occList = originaList.OrderBy(e => e).Distinct();

                //Set New Dictionary for Occupation Code and Its Count
                IDictionary<string, int> list = new Dictionary<string, int>();

                //Count Each Occupation Code in Original List
                foreach (var str in occList)
                {
                    list.Add(str, originaList.Count(e => e == str));
                }

                //Return Result
                return new OccupationResult() { Success = true, OccupationList = list, Total = total };
            }
            catch (Exception ee)
            {
                return new OccupationResult() { Success = false, ErrorMessage = Utility.GetErrorMessage(ee) };
            }
        }

        public void AddRange(IEnumerable<Applicant> list)
        {
            dal.AddRange(list);
        }
    }
}