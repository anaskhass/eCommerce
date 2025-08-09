using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using eCommarce.BLL.Services.Interface;
using IAuthenticationService = eCommarce.BLL.Services.Interface.IAuthenticationService;
using eCommarce.BLL.Services.Class;
using Microsoft.AspNetCore.Authorization;

namespace eCommarce.PL.Areas.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
  
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


        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("This is only for admins");
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


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProdectRequest request)
        {
            var result = await productService.CreateFile(request);
            return Ok(result);
        }


        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProdectRequest request)
        {
            var updated = productService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = productService.Delete(id);


            return deleted > 0 ? Ok() : NotFound();
        }


        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {

            var updated = productService.ToggleStatues(id);
            return updated ? Ok(new { message = "statues updated  " }) : NotFound(new { message = "Category Not Found" });
        }
    }
}

