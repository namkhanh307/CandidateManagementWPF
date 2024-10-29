using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext _context;
        private static HRAccountDAO instance = null;
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }
        public HRAccountDAO()
        {
            _context = new CandidateManagementContext();
        }
        public Hraccount? GetHraccountByEmail(string email)
        {
            return _context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }
        public IEnumerable<Hraccount> GetHraccounts()
        {
            return _context.Hraccounts.ToList();
        }
    }
}
