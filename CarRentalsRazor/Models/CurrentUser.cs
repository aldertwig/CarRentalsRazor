namespace CarRentalsRazor.Models
{
    public static class CurrentUser
    {
        public static Customer Customer { get; set; }
        public static Admin Admin { get; set; }
        public static string Email { get; set; } = string.Empty;
        public static bool IsAdmin { get; set; } = false;
        public static int LastCarLookedAtId { get; set; }
        public static bool IsLoggedIn { get; set; } = false;
        public static bool RedirectedFromBooking { get; set; } = false;
    }
}
