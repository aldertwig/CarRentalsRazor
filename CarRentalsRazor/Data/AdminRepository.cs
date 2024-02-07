using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Admin GetByEmail(string email)
        {
            return _applicationDbContext.Admins.FirstOrDefault(a => a.Email == email);
        }

        public Admin GetById(int id)
        {
            return _applicationDbContext.Admins.FirstOrDefault(a => a.Id == id);
        }
    }
}
