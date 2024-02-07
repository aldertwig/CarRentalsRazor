using CarRentalsRazor.Models;

namespace CarRentalsRazor.Data
{
    public interface IBooking
    {
        public interface IBooking
        {
            IEnumerable<Booking> GetByCustomerEmail(string email);
            Booking GetById(int id);
            Booking GetByCarId(int id);
            IEnumerable<Booking> GetAll();
            void Add(Booking booking);
            void Update(Booking booking);
            void Delete(Booking booking);
        }
    }
}
