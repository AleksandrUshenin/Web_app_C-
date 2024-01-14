using Product_Maneger.Models.DTO;

namespace Product_Maneger.Repositories.Interface
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDTO> GetCategories();
        int AddCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
    }
}
