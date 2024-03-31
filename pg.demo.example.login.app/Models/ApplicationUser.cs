namespace pg.demo.example.login.app.Models
{
	public record ApplicationUser(string Name, string password, string Email, IList<Role> Roles);
}
