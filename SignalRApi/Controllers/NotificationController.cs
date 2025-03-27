using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;
		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
		}
		[HttpGet("NotificatonCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificatonCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.Status = false;
			createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);
			return Ok("Ekleme işlemi yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateNatification(UpdateNatificationDto updateNatificationDto)
		{
			updateNatificationDto.Status = false;
			updateNatificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
			var value = _mapper.Map<Notification>(updateNatificationDto);
			_notificationService.TUpdate(value);
			return Ok("bildirim güncellendi");
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}

	}
}
