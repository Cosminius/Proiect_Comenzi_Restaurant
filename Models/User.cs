using Microsoft.AspNetCore.Identity;

namespace Proiect_Medii_Restaurantul_Meu.Models
{
    public class User: IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
