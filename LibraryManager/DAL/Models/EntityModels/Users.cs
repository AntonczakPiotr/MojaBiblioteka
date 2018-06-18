using Microsoft.AspNetCore.Identity;
using Shared;

namespace DAL.Models.EntityModels
{
    public class Users : IdentityUser
    {
        public Users()
        {

        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserPermissions Permissions { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }
}
