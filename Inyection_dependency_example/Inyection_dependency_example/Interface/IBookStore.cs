using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IBookStore
    {
        Task<BookStoreDTO> GetById(int idBookStore);

        Task<List<BookStoreDTO>> GetBookStores();

        Task<BookStoreDTO> Insert(BookStoreDTO bookStoreDTO);

        Task<BookStoreDTO> Update(int idBookStore, BookStoreDTO bookStoreDTO);

    }
}
