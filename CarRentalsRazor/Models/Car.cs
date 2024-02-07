namespace CarRentalsRazor.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int RentPerDay { get; set; }
        public bool Available { get; set; }
    }
}
