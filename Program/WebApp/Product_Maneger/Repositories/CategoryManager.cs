using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Product_Maneger.DataBase;
using Product_Maneger.Models;
using Product_Maneger.Models.DTO;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger.Repositories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        public CategoryManager(IMapper mapper, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _mapper = mapper;
            _cache = memoryCache;
            _configuration = configuration;
        }
        public int AddCategory(CategoryDTO categoryDTO)
        {
            using (var db = new ContextDataBase(_configuration.GetValue<string>("PathDataBase")))
            {
                var cat = db.Products.ToList();
                var products = db.Categories.ToList();
                var res = products.FirstOrDefault(x => x.Name.ToLower() == categoryDTO.Name.ToLower());
                if (res is null)
                {
                    _cache.Remove("categories");
                    res = new Category() { Name = categoryDTO.Name, Description = categoryDTO.Description };
                    db.Categories.Add(res);
                    db.SaveChanges();
                }
                return res.Id;
            }
        }

        public bool DeleteCategory(int id)
        {
            return false;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            if (_cache.TryGetValue("categories", out List<CategoryDTO> categoriesCache))
                return categoriesCache;

            List<Category> products = new List<Category>();
            using (var db = new ContextDataBase(_configuration.GetValue<string>("PathDataBase")))
            {
                var cat = db.Products.ToList();
                products = db.Categories.ToList();
            }
            var res = products.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();

            _cache.Set("categories", res, TimeSpan.FromMinutes(30));

            return res;
        }
    }
}
