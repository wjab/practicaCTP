using Inyection_dependency_example.Entidades;
using System.Net;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Implementation;

namespace Inyection_dependency_example.Controllers
{
    [Route("api/Book")]
    [ApiController()]    
    public class BookController(IBookAPI iBookAPI) : Controller
    {        
        private readonly IBookAPI IBookAPI = iBookAPI;
        private GenericResponse? response;

        [HttpDelete]
        public async Task<GenericResponse> Delete(int bookId)
        {
            response = new GenericResponse() { Request = bookId, HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IBookAPI.Delete(bookId);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpGet("/GetBooks")]
        public async Task<GenericResponse> GetBooks() 
        {
            response = new GenericResponse() { Request = "All Books", HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IBookAPI.GetBooks();
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpGet]
        public async Task<GenericResponse> GetById(int bookId)
        {
            response = new GenericResponse() { Request = bookId, HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IBookAPI.GetById(bookId);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPost]
        public async Task<GenericResponse> Post(BookDTO book)
        {
            response = new GenericResponse() { Request = book, HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IBookAPI.Insert(book);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPut]
        public async Task<GenericResponse> Put(int bookId, BookDTO book)
        {
            response = new GenericResponse() { HttpStatus = HttpStatusCode.OK };
            Dictionary<string, object> myParams = new()
            {
                { "bookId", bookId },
                { "book", book }
            };

            try
            {
                response.Request = myParams;
                response.Response = await IBookAPI.Update(bookId, book);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
