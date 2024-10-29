using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Repositories
{
    public interface IJobPostingRepo
    {
        List<JobPosting> GetJobPostings();
        JobPosting GetJobPostingById(string jobId);
        bool AddJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(JobPosting jobPosting);
        bool UpdateJobPosting(JobPosting jobPosting);
    }
}
