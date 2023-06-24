using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
    public class User
    {
        
        public Guid Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
