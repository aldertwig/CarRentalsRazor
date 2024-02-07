using Microsoft.AspNetCore.Mvc;
using CarRentalsRazor.Data;

namespace CarRentalsRazor.Components
{
    public class CarPicturesViewComponent : ViewComponent
    {
        private readonly ICarPictures _carPicturesRepo;

        public CarPicturesViewComponent(ICarPictures carPicturesRepo)
        {
            _carPicturesRepo = carPicturesRepo;
        }

        public IViewComponentResult Invoke(int id) 
        {
            var items = _carPicturesRepo.GetAllByCarId(id);
            return View(items);
        }
    }
}
