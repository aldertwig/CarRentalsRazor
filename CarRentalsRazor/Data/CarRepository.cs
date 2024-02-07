using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return _applicationDbContext.Cars.OrderBy(c => c.Brand).ToList();
        }

        public Car GetById(int id)
        {
            return _applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Car car)
        {
            _applicationDbContext.Add(car);
            _applicationDbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            _applicationDbContext.Update(car);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            _applicationDbContext.Remove(car);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAll(bool isAvailable)
        {
            return _applicationDbContext.Cars.Where(c => c.Available == isAvailable).ToList();
        }
    }
}
