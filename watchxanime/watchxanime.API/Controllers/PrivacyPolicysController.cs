using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchxanime.Business;
using watchxanime.DTO.DTOs.PrivacyPolicyDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivacyPolicysController(IGenericService<PrivacyPolicy> _PrivacyPolicyServices, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _PrivacyPolicyServices.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _PrivacyPolicyServices.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _PrivacyPolicyServices.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreatePrivacyPolicyDTO createPrivacyPolicyDTO)
        {
            var newValue = _mapper.Map<PrivacyPolicy>(createPrivacyPolicyDTO);
            _PrivacyPolicyServices.TCreate(newValue);
            return Ok(newValue);
        }
        [HttpPut]
        public IActionResult Update(UpdatePrivacyPolicyDTO updatePrivacyPolicyDTO)
        {
            var value = _mapper.Map<PrivacyPolicy>(updatePrivacyPolicyDTO);
            _PrivacyPolicyServices.TUpdate(value);
            return Ok(value);
        }
    }
}
