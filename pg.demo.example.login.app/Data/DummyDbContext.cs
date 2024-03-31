using pg.demo.example.login.app.Models;
using pg.demo.example.login.app.Models.Const;

namespace pg.demo.example.login.app.Data
{
	public class DummyDbContext
	{
		private static IList<ApplicationUser> InitUserList()
		{
			return
			[
				new ApplicationUser("administrator@administrator.com", "jose@123A", "administrator@administrator.com",
				[
					new Role() { Name = ConstRoles.Administrator, Description = ConstRoles.Administrator }
				]),
				new ApplicationUser("user@user.com", "jose@123A", "user@user.com",
				[
					new Role() { Description = ConstRoles.Default, Name = ConstRoles.Default }
				]),
				new ApplicationUser("other@other.com", "jose@123A", "other@other.com",
				[
					new Role() { Description = ConstRoles.Other, Name = ConstRoles.Other },
				]),
				new ApplicationUser("otherplusdefault@otherplusdefault.com", "jose@123A", "otherplusdefault@otherplusdefault.com",
				[
					new Role() { Description = ConstRoles.Other, Name = ConstRoles.Other },
					new Role() { Description = ConstRoles.Default, Name = ConstRoles.Default }
				])
			];
		}
		public ApplicationUser GetByEmail(string email, string password) => InitUserList().FirstOrDefault(_ => _.Email == email & _.password == password);
	}
}
