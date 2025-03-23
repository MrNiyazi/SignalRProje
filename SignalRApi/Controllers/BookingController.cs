using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System.Net.Mail;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;
		public BookingController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult BookingList() 
		{
			var values = _bookingService.TGetListAll();
			return Ok(_mapper.Map<List<ResultBookingDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			var value = _mapper.Map<Booking>(createBookingDto);
			_bookingService.TAdd(value);
			return Ok("Rezervasyon Yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			_bookingService.TDelete(value);
			return Ok("Rezervasyon Silindi");
		}
		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var value = _mapper.Map<Booking>(updateBookingDto);
			_bookingService.TUpdate(value);
			return Ok("Rezervasyon güncelllendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(_mapper.Map<GetBookingDto>(value));
		}
		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_bookingService.BookingStatusApproved(id);
			return Ok("Rezervasyon açıklaması değiştirildi");
		}
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.BookingStatusCancelled(id);
			return Ok("Değiştirildi");
		}

	//	void BookingStatusApproved(int id);
	//	void BookingStatusCancelled(int id);
	}
}
