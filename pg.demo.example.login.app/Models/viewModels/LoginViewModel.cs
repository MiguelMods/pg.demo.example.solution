using System.ComponentModel.DataAnnotations;

namespace pg.demo.example.login.app.Models.viewModels
{
	public class LoginViewModel
	{
		[Required]
		public string? Username { get; set; }
		
		[Required, DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
