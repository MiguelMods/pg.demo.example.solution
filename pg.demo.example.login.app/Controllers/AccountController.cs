using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using pg.demo.example.login.app.Data;
using pg.demo.example.login.app.Models;
using pg.demo.example.login.app.Models.viewModels;
using System.Security.Claims;

namespace pg.demo.example.login.app.Controllers
{
	public class AccountController(DummyDbContext dummyDbContext) : Controller
	{
		private readonly DummyDbContext dummyDbContext = dummyDbContext;

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return View(viewModel);

			var getUser = dummyDbContext.GetByEmail(viewModel.Username!, viewModel.Password!);

			if (getUser == null)
			{
				ModelState.AddModelError("", "User not exist");
				return View(viewModel);
			}

			await CreateCookieAuthenticateClaims(getUser);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(LoginViewModel viewModel)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Logout() 
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("login");
		}

		private async Task CreateCookieAuthenticateClaims(ApplicationUser applicationUser) 
		{
			var claims = new List<Claim>()
			{
				new(ClaimTypes.Name, applicationUser.Name),
				new(ClaimTypes.Email, applicationUser.Email)
			};

			foreach (var item in applicationUser.Roles)
			{
				claims.Add(new(ClaimTypes.Role, item.Name));
			}

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
		}
	}
}
