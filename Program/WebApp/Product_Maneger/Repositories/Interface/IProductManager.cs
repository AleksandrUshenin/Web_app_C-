using Product_Maneger.Models.DTO;

namespace Product_Maneger.Repositories.Interface
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetProducts();
        int AddProduct(ProductDTO productDTO);
        bool DeleteProduct(int id);
        bool AddProductPrice(int id, int price);
    }
}
