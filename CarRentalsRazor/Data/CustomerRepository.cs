using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(Customer customer)
        {
            _applicationDbContext.Add(customer);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _applicationDbContext.Remove(customer);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _applicationDbContext.Customers.OrderBy(c => c.LastName).ToList();
        }

        public Customer GetById(int id)
        {
            return _applicationDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer GetByEmail(string email)
        {
            return _applicationDbContext.Customers.FirstOrDefault(c => c.Email == email);
        }

        public void Update(Customer customer)
        {
            _applicationDbContext.Update(customer);
            _applicationDbContext.SaveChanges();
        }
    }
}
