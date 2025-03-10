﻿using Microsoft.AspNetCore.Http;
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
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
		[HttpGet]
		public IActionResult BookingList() 
		{
			var values = _bookingService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				Mail = createBookingDto.Mail,
				Date = createBookingDto.Date,
				Name = createBookingDto.Name,
				PersonCount = createBookingDto.PersonCount,
				Phone = createBookingDto.Phone,
				Description = createBookingDto.Description,
			};
			_bookingService.TAdd(booking);
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
			Booking booking = new Booking()
			{
				Mail = updateBookingDto.Mail,
				BookingID = updateBookingDto.BookingID,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
				Date = updateBookingDto.Date,
			};
			_bookingService.TUpdate(booking);
			return Ok("Rezervasyon güncelllendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(value);
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
