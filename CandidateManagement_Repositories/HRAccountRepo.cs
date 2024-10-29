using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;

namespace CandidateManagement_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {

        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);

        public IEnumerable<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();

    }
}
