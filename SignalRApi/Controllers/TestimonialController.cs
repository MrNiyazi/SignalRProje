﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult TestimonialList()
		{
			var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			_testimonialService.TAdd(new Testimonial()
			{
				Name = createTestimonialDto.Name,
				Title = createTestimonialDto.Title,
				Comment = createTestimonialDto.Comment,
				ImageUrl = createTestimonialDto.ImageUrl,
				Status = createTestimonialDto.Status,
			});
			return Ok("eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetById(id);
	        _testimonialService.TDelete(value);
			return Ok("silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial()
			{
				TestimonialID = updateTestimonialDto.TestimonialID,
				Name = updateTestimonialDto.Name,
				Title = updateTestimonialDto.Title,
				Comment = updateTestimonialDto.Comment,
				ImageUrl=updateTestimonialDto.ImageUrl,
				Status = updateTestimonialDto.Status,
			});
			return Ok("Kategori Güncellendi");
		}
	}
}
