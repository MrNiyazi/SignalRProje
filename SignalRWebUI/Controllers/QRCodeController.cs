using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
	public class QRCodeController : Controller
	{
		public IActionResult Index(string value)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				QRCodeGenerator createQRCode = new QRCodeGenerator();
				QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
				using (Bitmap image = squareCode.GetGraphic(10))
				{
					image.Save(stream, ImageFormat.Png);
					ViewBag.QRCodeImage = "data/png;base64"+Convert.ToBase64String(stream.ToArray());
				}
			}
			return View();
		}
	}
}
