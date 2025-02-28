using AutoMapper;
using watchxanime.DTO.DTOs.PrivacyPolicyDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Mapping
{
    public class PrivacyPolicyMapping: Profile
    {
        public PrivacyPolicyMapping() {
            CreateMap<CreatePrivacyPolicyDTO,PrivacyPolicy>().ReverseMap();
            CreateMap<UpdatePrivacyPolicyDTO,PrivacyPolicy>().ReverseMap();  
        }
    }
}
