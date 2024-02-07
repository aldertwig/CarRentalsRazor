using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetAll(bool isAvailable);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
