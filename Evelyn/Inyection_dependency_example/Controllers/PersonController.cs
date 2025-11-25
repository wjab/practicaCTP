using Inyection_dependency_example.Entidades;
using System.Net;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Controllers
{
    [ApiController]
    [Route("api/Person")]
    public class PersonController(IPerson personAPI): Controller
    {
        private readonly IPerson personApi = personAPI;
        private GenericResponse? response = null;

        [HttpGet]
        public GenericResponse Get()
        {
            response = new GenericResponse();
            try
            {
                response.Request = new Dictionary<string, int> {  };
                var resp = personApi.Get();
                if (resp == null)
                {
                    response.HttpStatus = HttpStatusCode.NoContent;
                }
                else
                {
                    response.Response = resp;
                }
                return response;
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPost]
        public GenericResponse Post(PersonDTO dto)
        {
            response = new GenericResponse();
            try
            {
                response.Request = dto;
                response.Response = personApi.Add(dto);
                return response;
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPut]
        public GenericResponse Put(PersonDTO dto)
        {
            response = new GenericResponse();
            try
            {
                response.Request = dto;
                var resp = personApi.Update(dto);
                if (resp == null)
                {
                    response.HttpStatus = HttpStatusCode.MethodNotAllowed;
                }
                else
                {
                    response.Response = resp;

                }
                return response;
            }
            catch (Exception e)
            {
                response.HttpStatus = HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpDelete]
        public GenericResponse Delete(PersonDTO dto)
        {
            response = new GenericResponse();
            try
            {
                response.Request = dto;
                response.Response = personApi.Delete();
                return response;
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
