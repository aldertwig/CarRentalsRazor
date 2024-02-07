using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(Booking booking)
        {
            _applicationDbContext.Add(booking);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Booking booking)
        {
            _applicationDbContext.Remove(booking);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Booking> GetAll()
        {
            return _applicationDbContext.Bookings.OrderBy(b => b.RentalEnd);
        }

        public Booking GetById(int id)
        {
            return _applicationDbContext.Bookings.FirstOrDefault(b => b.Id == id);
        }


        public Booking GetByCarId(int id)
        {
            return _applicationDbContext.Bookings.FirstOrDefault(b => b.CarId == id);
        }

        public IEnumerable<Booking> GetByCustomerEmail(string email)
        {
            return _applicationDbContext.Bookings.Where(b => b.Email == email);
        }

        public void Update(Booking booking)
        {
            _applicationDbContext.Update(booking);
            _applicationDbContext.SaveChanges();
        }
    }
}
