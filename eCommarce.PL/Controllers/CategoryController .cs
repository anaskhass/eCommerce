using Microsoft.AspNetCore.Mvc;
using eCommarce.BLL.Services;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using Azure.Core;

namespace eCommarce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
           this.categoryService = categoryService;
        }

       
        [HttpGet("")]
        public IActionResult GetAll()
        {
           
            return Ok(categoryService.GetAll());
        }

       
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var category = categoryService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id=categoryService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id }, request);
        }


        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] CategoryRequest request)
        {
            var updated = categoryService.Update(id, request);
            return updated > 0 ? Ok() : NotFound(); 
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = categoryService.Delete(id);


            return deleted > 0 ? Ok() : NotFound();
        }

     
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {

            var updated = categoryService.ToggleStatues(id);
            return updated  ? Ok(new {message="statues updated  "}) : NotFound(new {message="Category Not Found"});
        }
    }
}
