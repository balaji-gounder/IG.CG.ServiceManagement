using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class LoginModel
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? UserPassword { get; set; }

    }
}
