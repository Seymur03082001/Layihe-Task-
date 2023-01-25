using Microsoft.AspNetCore.Identity;

namespace Layihe_Task_.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
