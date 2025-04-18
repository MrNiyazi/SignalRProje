﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _sliderService;
		private readonly IMapper _mapper; 

		public SliderController( ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult SliderList()
		{
			var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var value = _mapper.Map<Slider>(createSliderDto);
			_sliderService.TAdd(value);
			return Ok("eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var value=_sliderService.TGetById(id);
			_sliderService.TDelete(value);
			return Ok("silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var value = _sliderService.TGetById(id);
			return Ok(_mapper.Map<GetByIdSliderDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateSlider(UpdateSlider updateSlider)
		{
			var value = _mapper.Map<Slider>(updateSlider);
			_sliderService.TUpdate(value);
			return Ok("Kategori Güncellendi");
		}
	}
}
