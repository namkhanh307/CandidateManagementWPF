using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfile? GetCandidateProfileById(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? candidate = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existedCandidateProfile = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (existedCandidateProfile != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existedCandidateProfile = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (existedCandidateProfile != null)
                {
                    context.Entry(existedCandidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
