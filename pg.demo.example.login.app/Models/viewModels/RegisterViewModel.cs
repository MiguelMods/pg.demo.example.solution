using System.ComponentModel.DataAnnotations;

namespace pg.demo.example.login.app.Models.viewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string? Name { get; set; }
		
		[Required, DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		
		[Compare("Email")]
		public string? ConfirmEmail { get; set; }

		[Required, DataType(DataType.Password)]
		public string? Password { get; set; }
		
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
	}
}
