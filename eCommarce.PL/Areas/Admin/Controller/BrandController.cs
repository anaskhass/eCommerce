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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpPost("with-image")]
        public async Task<IActionResult> Createe([FromForm] BrandRequest request)
        {
            var result = await brandService.CreateFile(request);
            return Ok(result);
        }


        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(brandService.GetAll());
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
            var category = brandService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = brandService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id }, request);
        

        }


        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = brandService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = brandService.Delete(id);


            return deleted > 0 ? Ok() : NotFound();
        }


        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {

            var updated = brandService.ToggleStatues(id);
            return updated ? Ok(new { message = "statues updated  " }) : NotFound(new { message = "Category Not Found" });
        }
    }
}

