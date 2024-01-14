using Microsoft.AspNetCore.Mvc;
using Product_Maneger.DataBase;
using Product_Maneger.Models;
using Product_Maneger.Models.DTO;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("GetСategories")]
        public ActionResult GetСategories()
        {
            var res = _categoryManager.GetCategories();
            return Ok(res);
        }
        [HttpPut("AddCategory")]
        public ActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            var res = _categoryManager.AddCategory(categoryDTO);
            return Ok($"Test Add {res}!");
        }
        [HttpDelete("DeleteCategory")]
        public ActionResult DeleteCategory(int id)
        {
            var res = _categoryManager.DeleteCategory(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }
    }
}
