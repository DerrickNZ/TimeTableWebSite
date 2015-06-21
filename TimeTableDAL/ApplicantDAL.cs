using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TimeTableBOL;

namespace TimeTableDAL
{
    public class ApplicantDAL
    {
        TimeTableDBContext context = new TimeTableDBContext();

        //Get Applicants
        public IEnumerable<Applicant> GetApplicants(Expression<Func<Applicant,bool>> filter = null)
        {
            //Return Applicants based on filter
            if (filter != null)
            {
                return context.Applicants.Where(filter);
            }
            else
            {
                return context.Applicants;
            }
        }

        //Add Applicants
        public void Add(Applicant applicant)
        {
            context.Applicants.Add(applicant);
            context.SaveChanges();
        }

        //Add Multiple Applicants
        public void AddRange(IEnumerable<Applicant> addList)
        {
            context.Applicants.AddRange(addList);
            context.SaveChanges();
        }

        //Get List of any Property in Applicant Class
        public IEnumerable<TResult> GetProperty<TResult>(Expression<Func<Applicant, TResult>> selector)
        {
            return context.Applicants.Select(selector);
        }

        //Dispose
        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
