using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inyection_dependency_example.Controllers
{
    [Controller]
    [Route("api/BookShelf")]
    public class BookShelfController(IBookShelfAPI iBookShelfAPI) : Controller
    {
        private readonly IBookShelfAPI IbookShelfAPI = iBookShelfAPI;
        private GenericResponse? response;

        [HttpGet]
        public async Task<GenericResponse> GetBookShelf()
        {
            response = new GenericResponse() { Request = "All book shelves", HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IbookShelfAPI.GetBookShelf();
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPost]
        public async Task<GenericResponse> Post([FromBody] BookShelfDTO bookShelfDTO)
        {
            response = new GenericResponse() { Request = bookShelfDTO, HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IbookShelfAPI.Insert(bookShelfDTO);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPut]
        public async Task<GenericResponse> Put([FromQuery]int bookShelfId, [FromBody]BookShelfDTO bookShelfDTO)
        {
            response = new GenericResponse() { Request = "All book shelves", HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await IbookShelfAPI.Update(bookShelfId, bookShelfDTO);
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
