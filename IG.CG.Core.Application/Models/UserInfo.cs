using IG.CG.Core.Application.Interfaces.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace IG.CG.Core.Application.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string? Token { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public string UserType { get; set; }
        public bool IsFirstLogin { get; set; }
        [NotMapped]
        public string IsCustomer { get; set; } = "false";

    }
}
