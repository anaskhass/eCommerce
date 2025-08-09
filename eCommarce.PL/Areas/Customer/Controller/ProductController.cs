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
    public class ProductController : ControllerBase
    {
        private readonly IProdectService productService;

        public ProductController(IProdectService productService)
        {
            this.productService = productService;
        }



        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(productService.GetAll());
        }





        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = productService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }






        
    }
}

