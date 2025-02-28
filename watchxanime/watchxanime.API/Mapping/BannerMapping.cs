using AutoMapper;
using watchxanime.DTO.DTOs.BannerDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDTO,Banner>().ReverseMap();
            CreateMap<UpdateBannerDTO, Banner>().ReverseMap();
        }
    }
}
