using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Models
{
    public class UserIdentityResult
    {
        public IdentityResult Result { get; set; }
        public User User { get; set; }
    }
}