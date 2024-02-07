using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public interface IAdmin
    {
        Admin GetById(int id);
        Admin GetByEmail(string email);
    }
}
