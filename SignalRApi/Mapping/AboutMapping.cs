using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class AboutMapping : Profile
	{
		public AboutMapping() 
		{
			CreateMap<About, ResaultAboutDto>().ReverseMap();
			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, GetAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();
		}
	}
}
