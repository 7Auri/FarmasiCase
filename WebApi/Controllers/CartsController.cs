using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _cartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Add(Cart newCart)
        {
            var result = _cartService.Create(newCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(string id, Cart updatedCart)
        {
            var result = _cartService.Update(id, updatedCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _cartService.Remove(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
