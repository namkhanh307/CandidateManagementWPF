using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Repositories
{
    public interface IHRAccountRepo
    {

        Hraccount GetHraccountByEmail(string email);
        public IEnumerable<Hraccount> GetHraccounts();
    }
}
