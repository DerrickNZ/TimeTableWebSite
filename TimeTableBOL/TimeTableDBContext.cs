namespace TimeTableBOL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TimeTableDBContext : DbContext
    {
        public TimeTableDBContext()
            : base("name=TimeTableDBContext")
        {

        }

        public DbSet<Applicant> Applicants { get; set; }
    }
}