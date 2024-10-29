using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Repositories;

namespace CandidateManagement_Services
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo _repo;

        public HRAccountService()
        {
            _repo = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email) => _repo.GetHraccountByEmail(email);
        public IEnumerable<Hraccount> GetHraccounts() => _repo.GetHraccounts();
    }
}
