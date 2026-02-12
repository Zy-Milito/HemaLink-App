using Domain.Models.Enums;

namespace Domain.Models
{
    public class Staff : Account
    {
        public StaffRole Role { get; set; }
    }
}
