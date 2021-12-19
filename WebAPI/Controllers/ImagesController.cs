using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var result = imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getByCarId")]
        public IActionResult GetByCarId(int carId)
        {
            var result = imageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = imageService.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
   
        [HttpPost("add")]
        public IActionResult Post([FromForm(Name = "ImagePath")] IFormFile file, [FromForm]Image image)
        {
            var result = imageService.Add(file,image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = imageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
