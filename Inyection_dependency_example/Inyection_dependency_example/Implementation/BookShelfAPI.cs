using AutoMapper;
using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;
using Microsoft.EntityFrameworkCore;

namespace Inyection_dependency_example.Implementation
{
    public class BookShelfAPI : IBookShelfAPI
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BookShelfAPI(ApplicationDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookShelfDTO>> GetBookShelf()
        {
            var bookShelfList = await context.BookShelfDB.Select(x => x).ToListAsync();
            return mapper.Map<List<BookShelfDTO>>(bookShelfList);
        }

        public async Task<BookShelfDTO?> GetById(int bookShelfId)
        {
            var bookShelfDB = await context.BookShelfDB.Where(x => x.IdBookShelf == bookShelfId ).Select(x => x).FirstOrDefaultAsync();
            return mapper.Map<BookShelfDTO>(bookShelfDB);
        }

        public async Task<BookShelfDTO?> Insert(BookShelfDTO bookShelf)
        {
            var bookShelfDB = mapper.Map<BookShelfDB>(bookShelf);
            context.BookShelfDB.Add(bookShelfDB);
            await context.SaveChangesAsync();

            return mapper.Map<BookShelfDTO>(bookShelfDB);
        }

        public async Task<BookShelfDTO?> Update(int bookShelfId, BookShelfDTO bookShelf)
        {
            var bookShelfDB = await context.BookShelfDB.Where(x => x.IdBookShelf == bookShelfId).Select(x => x).FirstOrDefaultAsync();
            if (bookShelfDB == null)
            {
                throw new Exception($"BookShelfId {bookShelfId} does not exists in database");
            }

            bookShelfDB.HallNumber = bookShelf.HallNumber;
            bookShelfDB.CategoryName = bookShelf.CategoryName ?? bookShelfDB.CategoryName;
            await context.SaveChangesAsync();

            return mapper.Map<BookShelfDTO>(bookShelfDB);
        }
    }
}
