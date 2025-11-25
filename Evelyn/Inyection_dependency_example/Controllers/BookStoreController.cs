using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inyection_dependency_example.Controllers
{
    [Controller]
    [Route("/api/BookStore")]
    public class BookStoreController : Controller
    {
        private readonly IBookStore IBookStore;
        private GenericResponse? response;

        public BookStoreController(IBookStore IBookStore) 
        {
            this.IBookStore = IBookStore;
        }

        [HttpGet]
        public async Task<GenericResponse> GetAll()
        {
            response = new GenericResponse() { Request = "Obtener todos los libros"};

            try
            {
                response.Response = await IBookStore.GetBookStores();
            }
            catch (Exception ex) 
            { 
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpGet("GetById")]
        public async Task<GenericResponse> GetById(int IdBookStore)
        {
            response = new GenericResponse() { Request = IdBookStore };

            try
            {
                response.Response = await IBookStore.GetById(IdBookStore);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpPost]
        public async Task<GenericResponse> Insert([FromBody]BookStoreDTO bookStoreDTO)
        {
            response = new GenericResponse() { Request = bookStoreDTO };

            try
            {
                response.Response = await IBookStore.Insert(bookStoreDTO);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpPut]
        public async Task<GenericResponse> Update([FromQuery] int IdBookStore, [FromBody] BookStoreDTO bookStoreDTO)
        {
            response = new GenericResponse() { Request = bookStoreDTO };

            try
            {
                response.Response = await IBookStore.Update(IdBookStore, bookStoreDTO);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }


    }
}
