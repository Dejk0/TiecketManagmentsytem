using Microsoft.AspNetCore.Identity;
namespace Domain.Entityes
{
  public class User : IdentityUser
  {
    public string? Avatar { get; set; }
    public bool AccountConFirmed { get; set; }
  }
}
