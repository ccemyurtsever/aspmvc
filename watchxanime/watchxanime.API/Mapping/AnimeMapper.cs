using AutoMapper;
using watchxanime.DTO.DTOs.AnimeDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Mapping
{
    public class AnimeMapping : Profile
    {
        public AnimeMapping()
        {
            CreateMap<CreateAnimeDTO, Anime>().ReverseMap();
            CreateMap<UpdateAnimeDTO, Anime>().ReverseMap();
        }
    }
}