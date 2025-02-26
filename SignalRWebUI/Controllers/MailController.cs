using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpDelete]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon","mail adresi");
			mimeMessage.From.Add(mailboxAddressFrom);
			return RedirectToAction("Index");
		}
	}
}
