using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Repositories
{
    public interface ICandidateProfileRepo
    {
        CandidateProfile? GetCandidateProfileById(string id);
        List<CandidateProfile> GetCandidateProfiles();
        bool AddCandidateProfile(CandidateProfile candidateProfile);
        bool DeleteCandidateProfile(CandidateProfile candidateProfile);
        bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
