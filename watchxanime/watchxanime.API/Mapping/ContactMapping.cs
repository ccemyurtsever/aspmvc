using AutoMapper;
using watchxanime.DTO.DTOs.ContactDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Mapping
{
    public class ContactMapping: Profile
    {
        public ContactMapping() {
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();
        }
    }
}
