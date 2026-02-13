using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class ModeratorPromotionDto
    {

        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
