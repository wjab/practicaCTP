using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IBookAPI
    {
        Task<BookDTO?> GetById(int bookId);
        Task<List<BookDTO>> GetBooks();
        Task<BookDTO?> Insert(BookDTO book);
        Task<BookDTO?> Update(int bookId, BookDTO book);
        Task<bool> Delete(int bookId);
    }
}
