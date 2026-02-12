using Domain.Models.Enums;

namespace Domain.Models
{
    public class Requester : Account
    {
        public AdmissionStatus AdmissionStatus { get; set; }
    }
}
