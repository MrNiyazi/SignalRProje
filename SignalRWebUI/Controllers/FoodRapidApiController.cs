using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class FoodRapidApiController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
