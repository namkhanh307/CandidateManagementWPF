using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;

namespace CandidateManagement_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting) => JobPostDAO.Instance.AddJobPosting(jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting) => JobPostDAO.Instance.DeleteJobPosting(jobPosting);

        public JobPosting GetJobPostingById(string jobId) => JobPostDAO.Instance.GetJobPostingById(jobId);
        public List<JobPosting> GetJobPostings() => JobPostDAO.Instance.GetJobPostings();

        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostDAO.Instance.UpdateJobPosting(jobPosting);
    }
}
