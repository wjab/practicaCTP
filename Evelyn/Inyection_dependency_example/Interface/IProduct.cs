using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IProduct
    {
        Task<ProductDTO> GetById(int IdProduct);

        Task<List<ProductDTO>> GetProduct();

        Task<ProductDTO> Insert(ProductDTO ProductDTO);

        Task<ProductDTO> Update(int IdProduct, ProductDTO ProductDTO);

    }
}