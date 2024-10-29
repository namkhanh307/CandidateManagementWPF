using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Services
{
    public interface IJobPostingService
    {
        List<JobPosting> GetJobPostings();
        JobPosting GetJobPostingById(string jobId);
        bool AddJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(JobPosting jobPosting);
        bool UpdateJobPosting(JobPosting jobPosting);
    }
}
