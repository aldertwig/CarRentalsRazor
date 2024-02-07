using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public class CarPicturesRepository : ICarPictures
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CarPicturesRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<CarPicture> GetAllByCarId(int id)
        {
            return _applicationDbContext.CarPictures.Where(p => p.CarId == id).ToList();
        }
    }
}
