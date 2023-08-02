using Microsoft.AspNetCore.Identity;

namespace E_Commerce_2.Entities
{
    public class User : IdentityUser
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string ProfilePicture{get; set;}
    }
}