using AutoMapper;
using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;
using Microsoft.EntityFrameworkCore;

namespace Inyection_dependency_example.Implementation
{
    public class ProductAPI : IProduct
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductAPI(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProduct()
        {
            List<ProductDB> ProductDBList = await context.ProductDB.Select(x => x).ToListAsync();

            return mapper.Map<List<ProductDTO>>(ProductDBList);
        }

        public async Task<ProductDTO> GetById(int IdProduct)
        {
            ProductDB? ProductDB = await context.ProductDB.Where(x => x.IdProduct == IdProduct).Select(x => x).FirstOrDefaultAsync();

            return mapper.Map<ProductDTO>(ProductDB);
        }

        public async Task<ProductDTO> Insert(ProductDTO ProductDTO)
        {
            if (ProductDTO == null)
            {
                throw new Exception("El Product no debe estar nulo!");
            }

            var newProductDB = mapper.Map<ProductDB>(ProductDTO);
            context.ProductDB.Add(newProductDB);
            await context.SaveChangesAsync();

            await context.Entry(newProductDB).ReloadAsync();

            return mapper.Map<ProductDTO>(newProductDB);

        }

        public async Task<ProductDTO> Update(int IdProduct, ProductDTO ProductDTO)
        {
            if (ProductDTO == null && IdProduct == 0)
            {
                throw new Exception("El producto no debe estar nulo y/o el Id del producto no puede ser cero");
            }

            ProductDB? ProductDB = await context.ProductDB.Where(x => x.IdProduct == IdProduct).Select(x => x).FirstOrDefaultAsync();

            if (ProductDB == null)
            {
                throw new Exception("Registro no encontrado en base de datos");
            }

            ProductDB.Name = ProductDTO!.Name ?? ProductDB.Name;
            ProductDB.Description = ProductDTO.Description ?? ProductDB.Description;
            ProductDB.Amount = ProductDTO.Amount ?? ProductDB.Amount;
            ProductDB.Worth = ProductDTO.Worth ?? ProductDB.Worth;
            ProductDB.Date_of_entry = ProductDTO.Date_of_entry ?? ProductDB.Date_of_entry;
            //ProductDB.FkCategory = ProductDTO.FkCategory ?? ProductDB.FkCategory;

            await context.SaveChangesAsync();

            return mapper.Map<ProductDTO>(ProductDB);

        }
    }
}
