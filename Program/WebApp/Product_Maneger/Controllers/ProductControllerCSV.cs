using Microsoft.AspNetCore.Mvc;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductControllerCSV : ControllerBase
    {
        private readonly IProductControllerCSV _productControllerCSV;
        public ProductControllerCSV(IProductControllerCSV productControllerCSV)
        {
            _productControllerCSV = productControllerCSV;
        }
        [HttpGet("GetProductsSCV")]
        public FileContentResult GetProductsSCV()
        {
            var stringFile = _productControllerCSV.GetProductsCSV();
            return File(new System.Text.UTF8Encoding().GetBytes(stringFile), "text/scv", "Products.scv");
        }
    }
}
