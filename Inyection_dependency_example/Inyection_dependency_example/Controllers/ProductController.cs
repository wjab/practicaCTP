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

        // GET ALL

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

        // GET BY ID
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


        // LIST (RAW LIST)

        [HttpGet("List")]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var products = await IProduct.GetProduct();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al obtener la lista de productos",
                    error = ex.Message
                });
            }
        }

        // POST - AGREGAR PRODUCTO==
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("El producto no puede ser nul");

            try
            {
                var result = await IProduct.Insert(product);
                return Ok(new
                {
                    message = "Producto creado exitosamente!",
                    product = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al insertar producto",
                    error = ex.Message
                });
            }
        }


        // PUT
        [HttpPut("Update/{IdProduct}")]
        public async Task<IActionResult> UpdateProduct(int IdProduct, [FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("El producto no puede ser nulo.");

            try
            {
                var result = await IProduct.Update(IdProduct, product);
                return Ok(new
                {
                    message = "Producto actualizado exitosamente",
                    product = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al actualizar producto",
                    error = ex.Message
                });
            }
        }
    }
}
