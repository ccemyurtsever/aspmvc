using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchxanime.Business;
using watchxanime.DTO.DTOs.AboutDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUssController(IGenericService<AboutUs> _aboutService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
             _aboutService.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDTO createAboutDTO)
        {
            var newValue = _mapper.Map<AboutUs>(createAboutDTO);
            _aboutService.TCreate(newValue);
            return Ok(newValue); 
        }
        [HttpPut]
        public IActionResult Update(UpdateAboutDTO updateAboutDTO)
        {
            var value = _mapper.Map<AboutUs>(updateAboutDTO);
            _aboutService.TUpdate(value);
            return Ok(value);
        }
    }
}
