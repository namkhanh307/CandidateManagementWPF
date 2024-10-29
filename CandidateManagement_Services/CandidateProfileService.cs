using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Repositories;

namespace CandidateManagement_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        public CandidateProfileService()
        {
            candidateProfileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.AddCandidateProfile(candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.DeleteCandidateProfile(candidateProfile);
        public CandidateProfile? GetCandidateProfileById(string id) => candidateProfileRepo.GetCandidateProfileById(id);
        public List<CandidateProfile> GetCandidateProfiles() => candidateProfileRepo.GetCandidateProfiles();
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.UpdateCandidateProfile(candidateProfile);
        public (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSize)
        {
            var allProfiles = candidateProfileRepo.GetCandidateProfiles();
            var totalItems = allProfiles.Count();

            var pagedProfiles = allProfiles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return (pagedProfiles, totalItems, totalPages);
        }
    }
}
