using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Services
{
    public interface IHRAccountService
    {
        Hraccount GetHraccountByEmail(string email);
        IEnumerable<Hraccount> GetHraccounts();
    }
}
