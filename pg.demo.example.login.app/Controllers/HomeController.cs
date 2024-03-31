using Microsoft.AspNetCore.Mvc;
using pg.demo.example.login.app.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace pg.demo.example.login.app.Controllers
{
	[Authorize]
	public class HomeController(ILogger<HomeController> logger) : Controller
	{
		private readonly ILogger<HomeController> _logger = logger;

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult FormOne() 
		{
			return View();
		}

		public IActionResult FormTwo() 
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
