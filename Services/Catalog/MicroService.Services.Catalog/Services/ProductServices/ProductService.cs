using AutoMapper;
using MicroService.Services.Catalog.Dtos.CategoryDtos;
using MicroService.Services.Catalog.Dtos.ProductDtos;
using MicroService.Services.Catalog.Models;
using MicroService.Services.Catalog.Settings;
using MicroService.Shared.Dtos;
using MongoDB.Driver;

namespace MicroService.Services.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>
                (_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>
                (_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(201);
        }

        public async Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            var value = await _productCollection.DeleteOneAsync(x => x.ProductID == id);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultProductDto>>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<ResultProductDto>> GetByIDProductAsync(string id)
        {
            var values = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            if (values == null)
            {
                return Response<ResultProductDto>.Fail("Ürün Bulunmadı", 404);
            }
            return Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(values), 200);
        }

        public async Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
            return Response<NoContent>.Success(204);
        }
    }
}