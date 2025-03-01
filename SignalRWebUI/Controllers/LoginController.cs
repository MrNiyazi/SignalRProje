using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _singInManager;

		public LoginController(SignInManager<AppUser> singInManager)
		{
			_singInManager = singInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _singInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			return View();
		}

		public async Task<IActionResult> LogOut()
		{
			await _singInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}

	}
}
