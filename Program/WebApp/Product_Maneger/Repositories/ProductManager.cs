using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Product_Maneger.DataBase;
using Product_Maneger.Models;
using Product_Maneger.Models.DTO;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger.Repositories
{
    public class ProductManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductManager(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _cache = memoryCache;
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            if (_cache.TryGetValue("products", out List<ProductDTO> productsCache))
                return productsCache;

            List<Product> products = new List<Product>();
            using (var db = new ContextDataBase())
            {
                var cat = db.Categories.ToList();
                products = db.Products.ToList();
            }
            var res = products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();

            _cache.Set("products", res, TimeSpan.FromMinutes(30));

            return res;
        }
        public int AddProduct(ProductDTO productDTO)
        {
            using (var db = new ContextDataBase())
            {
                var cat = db.Categories.ToList();
                var products = db.Products.ToList();
                var res = products.FirstOrDefault(x => x.Name.ToLower() == productDTO.Name.ToLower());
                if (res is null)
                {
                    _cache.Remove("products");
                    res = new Product() { Name = productDTO.Name, Description = productDTO.Description, Price = productDTO.Price, CategoryId = productDTO.CategoryId };
                    db.Products.Add(res);
                    db.SaveChanges();
                }
                return res.Id;
            }
        }
        public bool DeleteProduct(int id)
        {
            List<Product> products = new List<Product>();
            using (var db = new ContextDataBase())
            {
                var cat = db.Categories.ToList();
                products = db.Products.ToList();
                var obj = products.FirstOrDefault(x => x.Id == id);
                if (obj is null)
                    return false;

                db.Products.Remove(obj);
                db.SaveChanges();
                _cache.Remove("products");
                return true;
            }
        }
        public bool AddProductPrice(int id, int price)
        {
            using (var db = new ContextDataBase())
            {
                var cat = db.Categories.ToList();
                var products = db.Products.ToList();
                var res = products.FirstOrDefault(x => x.Id == id);
                if (res is null)
                    return false;
                res.Price = price;

                db.SaveChanges();

                _cache.Remove("products");

                return true;
            }
        }
    }
}
