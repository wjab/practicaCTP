using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IBookShelfAPI
    {
        Task<BookShelfDTO?> GetById(int bookShelfId);
        Task<List<BookShelfDTO>> GetBookShelf();
        Task<BookShelfDTO?> Insert(BookShelfDTO bookShelf);
        Task<BookShelfDTO?> Update(int bookShelfId, BookShelfDTO bookShelf);
    }
}
