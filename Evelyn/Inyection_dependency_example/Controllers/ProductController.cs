using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Entidades;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inyection_dependency_example.Controllers
{
    [Controller]
    [Route("/api/Product")]
    public class ProductController : Controller
    {
        private readonly IProduct IProduct;
        private GenericResponse? response;

        public ProductController(IProduct IProduct)
        {
            this.IProduct = IProduct;
        }

        [HttpGet]
        public async Task<GenericResponse> GetAll()
        {
            response = new GenericResponse() { Request = "Obtener todos los productos" };

            try
            {
                response.Response = await IProduct.GetProduct();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpGet("GetById")]
        public async Task<GenericResponse> GetById(int IdProduct)
        {
            response = new GenericResponse() { Request = IdProduct };

            try
            {
                response.Response = await IProduct.GetById(IdProduct);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpPost]
        public async Task<GenericResponse> Insert([FromBody] ProductDTO ProductDTO)
        {
            response = new GenericResponse() { Request = ProductDTO };

            try
            {
                response.Response = await IProduct.Insert(ProductDTO);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpPut]
        public async Task<GenericResponse> Update([FromQuery] int IdProduct, [FromBody] ProductDTO ProductDTO)
        {
            response = new GenericResponse() { Request = ProductDTO };

            try
            {
                response.Response = await IProduct.Update(IdProduct, ProductDTO);
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

