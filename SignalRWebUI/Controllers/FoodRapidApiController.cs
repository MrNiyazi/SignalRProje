using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;

namespace SignalRWebUI.Controllers
{
	public class FoodRapidApiController : Controller
	{
		public async Task<IActionResult> Index()
		{
			//List<ResultTastyApi> resultTastyApis = new List<ResultTastyApi>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
				Headers =
	{
		{ "x-rapidapi-key", "70dc19646emsh5a00e62444c6f71p1da85cjsnf36a21a19577" },
		{ "x-rapidapi-host", "tasty.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				//var values = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
				//return View(values.ToList());
				//Console.WriteLine(body);
				var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
				var values = root.Results;
				return View (values);



			}
			
		}
	}
}
