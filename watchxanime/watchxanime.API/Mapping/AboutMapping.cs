using AutoMapper;
using watchxanime.DTO.DTOs.AboutDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDTO,AboutUs>().ReverseMap();
            CreateMap<UpdateAboutDTO,AboutUs>().ReverseMap();
        }

    }
}
