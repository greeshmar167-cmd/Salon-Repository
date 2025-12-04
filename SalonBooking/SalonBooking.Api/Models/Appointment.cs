namespace SalonBooking.Api.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } = string.Empty;

        public Service? Service { get; set; }
    }
}
