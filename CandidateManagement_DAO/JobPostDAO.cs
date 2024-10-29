using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_DAO
{
    public class JobPostDAO
    {
        private CandidateManagementContext context;
        public static JobPostDAO instance;
        private JobPostDAO()
        {
            context = new CandidateManagementContext();
        }
        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();
                }
                return instance;
            }
        }

        public List<JobPosting> GetJobPostings()
        {
            return context.JobPostings.ToList();
        }
        public JobPosting? GetJobPostingById(string jobId)
        {
            return context.JobPostings.SingleOrDefault(m => m.PostingId.Equals(jobId));
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPostingById(jobPosting.PostingId);
            try
            {
                if (job == null)
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? job = GetJobPostingById(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.JobPostings.Remove(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? job = GetJobPostingById(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.Entry(job).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
