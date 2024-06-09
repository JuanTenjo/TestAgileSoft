using Microsoft.AspNetCore.Identity;

namespace TestAgileSoft.Domain.Entities
{
    public class User: IdentityUser
    {   
        public string Nombre { get; set; } = default!;
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
