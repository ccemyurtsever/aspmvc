using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using watchxanime.Business;
using watchxanime.DTO.DTOs.AnimeDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController(IGenericService<Anime> _animeService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _animeService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _animeService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _animeService.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateAnimeDTO createAnimeDTO)
        {
            var newValue = _mapper.Map<Anime>(createAnimeDTO);
            _animeService.TCreate(newValue);
            return Ok(newValue);
        }
        [HttpPut]
        public IActionResult Update(UpdateAnimeDTO updateAnimeDTO)
        {
            var value = _mapper.Map<Anime>(updateAnimeDTO);
            _animeService.TUpdate(value);
            return Ok(value);
        }
    }
}

