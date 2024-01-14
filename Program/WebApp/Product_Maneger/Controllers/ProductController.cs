using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product_Maneger.DataBase;
using Product_Maneger.Models;
using Product_Maneger.Models.DTO;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet("GetProducts")]
        public ActionResult GetProducts() 
        {
            var products = _productManager.GetProducts();
            return Ok(products);
        }
        [HttpPut("AddProduct")]
        public ActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            int idProduct = _productManager.AddProduct(productDTO);
            return Ok(idProduct);
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(int id) 
        {
            var res = _productManager.DeleteProduct(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }
        [HttpPut("AddProductPrice")]
        public ActionResult AddProductPrice(int id, int price)
        {
            bool result = _productManager.AddProductPrice(id, price);
            if (result == false)
                return StatusCode(500);
            return Ok($"Add price ok! id = {id}, price = {price}");
        }
    }
}