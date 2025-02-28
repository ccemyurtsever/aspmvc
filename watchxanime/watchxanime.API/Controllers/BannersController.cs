using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchxanime.Business;
using watchxanime.DTO.DTOs.BannerDTOs;
using watchxanime.Entity.Entites;

namespace watchxanime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerServices, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerServices.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerServices.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bannerServices.TDelete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDTO createBannerDTO)
        {
            var newValue = _mapper.Map<Banner>(createBannerDTO);
            _bannerServices.TCreate(newValue);
            return Ok(newValue);
        }
        [HttpPut]
        public IActionResult Update(UpdateBannerDTO updateBannerDTO)
        {
            var value = _mapper.Map<Banner>(updateBannerDTO);
            _bannerServices.TUpdate(value);
            return Ok(value);
        }
    }
}
