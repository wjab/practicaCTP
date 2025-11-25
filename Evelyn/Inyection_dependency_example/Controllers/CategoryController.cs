using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inyection_dependency_example.Controllers
{
    [Controller]
    [Route("api/Category")]
    public class CategoryController(ICategoryAPI ICategoryAPI) : Controller
    {
        private readonly ICategoryAPI ICategoryAPI = ICategoryAPI;
        private GenericResponse? response;

        [HttpGet]
        public async Task<GenericResponse> GetCategory()
        {
            response = new GenericResponse() { Request = "All book shelves", HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await ICategoryAPI.GetCategory();
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPost]
        public async Task<GenericResponse> Post([FromBody] CategoryDTO CategoryDTO)
        {
            response = new GenericResponse() { Request = CategoryDTO, HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await ICategoryAPI.Insert(CategoryDTO);
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPut]
        public async Task<GenericResponse> Put([FromQuery] int IdCategory, [FromBody] CategoryDTO CategoryDTO)
        {
            response = new GenericResponse() { Request = "All book shelves", HttpStatus = HttpStatusCode.OK };

            try
            {
                response.Response = await ICategoryAPI.Update(IdCategory, CategoryDTO);
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
