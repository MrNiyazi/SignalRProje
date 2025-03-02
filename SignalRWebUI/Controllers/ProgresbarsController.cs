using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class ProgresbarsController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
	}
}
