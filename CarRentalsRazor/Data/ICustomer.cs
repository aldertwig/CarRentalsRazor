using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public interface ICustomer
    {
        Customer GetById(int id);
        Customer GetByEmail(string email);
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
