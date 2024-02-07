using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public interface ICarPictures
    {
        public IEnumerable<CarPicture> GetAllByCarId(int id);
    }
}
