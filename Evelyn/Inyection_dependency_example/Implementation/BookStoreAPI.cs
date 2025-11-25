using AutoMapper;
using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;
using Inyection_dependency_example.Utils;
using Microsoft.EntityFrameworkCore;

namespace Inyection_dependency_example.Implementation
{
    public class BookStoreAPI : IBookStore
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BookStoreAPI(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookStoreDTO>> GetBookStores()
        {
            List<BookStoreDB> bookStoreDBList = await context.BookStoreDB.Select(x => x).ToListAsync();

            return mapper.Map<List<BookStoreDTO>>(bookStoreDBList);
        }

        public async Task<BookStoreDTO> GetById(int idBookStore)
        {
            BookStoreDB bookStoreDB = await context.BookStoreDB.Where(x => x.IdBookStore == idBookStore).Select(x => x).FirstOrDefaultAsync();

            return mapper.Map<BookStoreDTO>(bookStoreDB);
        }

        public async Task<BookStoreDTO> Insert(BookStoreDTO bookStoreDTO)
        {
            if(bookStoreDTO == null)
            {
                throw new Exception("El BookStore no debe estar nulo");
            }

            var newBookStoreDB = mapper.Map<BookStoreDB>(bookStoreDTO);
            context.BookStoreDB.Add(newBookStoreDB);
            await context.SaveChangesAsync();

            return mapper.Map<BookStoreDTO>(newBookStoreDB);
        }

        public async Task<BookStoreDTO> Update(int idBookStore, BookStoreDTO bookStoreDTO)
        {
            if (bookStoreDTO == null && idBookStore == 0)
            {
                throw new Exception("El BookStore no debe estar nulo y/o el identificador de la tienda no puede ser cero");
            }

            BookStoreDB bookStoreDB = await context.BookStoreDB.Where(x => x.IdBookStore == idBookStore).Select(x => x).FirstOrDefaultAsync();

            if(bookStoreDB == null)
            {
                throw new Exception("Registro no encontrado en base de datos");
            }

            bookStoreDB.Name = bookStoreDTO.Name ?? bookStoreDB.Name;
            bookStoreDB.PhoneNumber = bookStoreDTO.PhoneNumber ?? bookStoreDB.PhoneNumber;
            bookStoreDB.Email = bookStoreDTO.Email ?? bookStoreDB.Email;
            bookStoreDB.Address = bookStoreDTO.Address ?? bookStoreDB.Address;

            await context.SaveChangesAsync();

            return mapper.Map<BookStoreDTO>(bookStoreDB);
        }
    }
}
