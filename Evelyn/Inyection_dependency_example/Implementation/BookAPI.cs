using AutoMapper;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Inyection_dependency_example.Implementation
{
    public class BookAPI : IBookAPI
    {
        private readonly ApplicationDbContext context;
        private Book? existingBook;
        private IMapper IMapper;
        private List<Book> bookList =
        [
            new() {
              IdBook = 1,
              Title = "The Great Adventure",
              Description = "An inspiring story of bravery and discovery.",
              Author = "Jane Doe",
              PublishedDate = DateTime.Parse("2020-06-15"),
              CreationDate = DateTime.Parse("2020-01-10"),
              UpdateDate = DateTime.Parse("2021-05-20")
            },
            new () {
              IdBook = 2,
              Title = "Mysteries of the Universe",
              Description = "Exploring the unknowns beyond our galaxy.",
              Author = "John Smith",
              PublishedDate = DateTime.Parse("2018-11-23"),
              CreationDate = DateTime.Parse("2018-03-05"),
              UpdateDate = DateTime.Parse("2019-08-14")
            }
        ];

        public BookAPI(IMapper IMapper, ApplicationDbContext applicationDbContext)
        {
            this.IMapper = IMapper;
            this.context = applicationDbContext;
        }

        public async Task<bool> Delete(int bookId)
        {
            var a = await context.BookDB.Select(x => x).ToListAsync();

            Book? existingBook = (from b in bookList
                                 where b.IdBook == bookId
                                 select b).FirstOrDefault();

            if (existingBook != null)
            {
                bookList.Remove(existingBook);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var a = await context.BookDB.Select(x => x).ToListAsync();

            return IMapper.Map<List<BookDTO>>(bookList);
        }

        public async Task<BookDTO?> GetById(int bookId)
        {
            var a = await context.BookDB.Select(x => x).ToListAsync();

            existingBook = (from b in bookList
                           where b.IdBook == bookId
                           select b).FirstOrDefault();

            if (existingBook != null)
            {
                return IMapper.Map<BookDTO>(existingBook);
            }
            else
            {
                return null;
            }
        }

        public async Task<BookDTO?> Insert(BookDTO bookDTO)
        {
            var a = await context.BookDB.Select(x => x).ToListAsync();

            if (bookDTO != null)
            {
                existingBook = IMapper.Map<Book>(bookDTO);
                existingBook.UpdateDate = DateTime.Now;
                existingBook.CreationDate = DateTime.Now;

                bookList.Add(existingBook);
            }

            return bookDTO;
        }

        public async Task<BookDTO?> Update(int bookId, BookDTO bookDTO)
        {
            var a = await context.BookDB.Select(x => x).ToListAsync();

            existingBook = (from b in bookList
                            where b.IdBook == bookId
                            select b).FirstOrDefault();

            if (existingBook != null)
            {
                existingBook.Author = bookDTO.Author?? existingBook.Author;
                existingBook.Title = bookDTO.Title?? existingBook.Title;
                existingBook.Description = bookDTO.Description ?? existingBook.Description;
                existingBook.PublishedDate = bookDTO.PublishedDate;

                return IMapper.Map<BookDTO>(existingBook);
            }
            else
            {
                return null;
            }
        }
    }
}
