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
        public IActionResult GetAllCategories()
        {
           
            return Ok(categoryService.GetAllCategories());
        }

       
        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute]int id)
        {
            var category = categoryService.GetCategoryById(id);

            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryRequest request)
        {
            var id=categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(GetCategoryById), new { id }, request);
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateCategory([FromRoute]int id, [FromBody] CategoryRequest request)
        {
            var updated = categoryService.UpdateCategory(id, request);
            return updated > 0 ? Ok() : NotFound(); 
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleted = categoryService.DeleteCategory(id);


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
