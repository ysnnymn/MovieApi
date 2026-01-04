using Microsoft.AspNetCore.Identity;

namespace MovieApi.Persistance.Identity;

public class AppUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? ImageUrl { get; set; }    
}