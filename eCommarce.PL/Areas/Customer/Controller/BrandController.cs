using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using eCommarce.BLL.Services.Interface;
using IAuthenticationService = eCommarce.BLL.Services.Interface.IAuthenticationService;
using eCommarce.BLL.Services.Class;
using Microsoft.AspNetCore.Authorization;

namespace eCommarce.PL.Areas.Customer.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]



    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }



        [HttpGet("")]
        public IActionResult GetAll()
        {

            return Ok(brandService.GetAll(true));
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = brandService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}

