using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Services
{
    public interface ICandidateProfileService
    {
        (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSize);
        CandidateProfile? GetCandidateProfileById(string id);
        List<CandidateProfile> GetCandidateProfiles();
        bool AddCandidateProfile(CandidateProfile candidateProfile);
        bool DeleteCandidateProfile(CandidateProfile candidateProfile);
        bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
