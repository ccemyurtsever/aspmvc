using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchxanime.Business;
using watchxanime.DTO.DTOs.ContactDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactServices, IMapper _mapper ) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactServices.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _contactServices.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactServices.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateContactDTO createContactDTO)
        {
            var newValue = _mapper.Map<Contact>(createContactDTO);
            _contactServices.TCreate(newValue);
            return Ok(newValue);
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDTO updateContactDTO)
        {
            var value = _mapper.Map<Contact>(updateContactDTO);
            _contactServices.TUpdate(value);
            return Ok(value);
        }

    }
}
