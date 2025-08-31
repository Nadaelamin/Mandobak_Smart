using Microsoft.AspNetCore.Identity;

namespace Mandobak_Smart.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FullName { get; set; }
    }
}
