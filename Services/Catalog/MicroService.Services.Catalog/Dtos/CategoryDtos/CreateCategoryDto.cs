using MongoDB.Bson.Serialization.Attributes;

namespace MicroService.Services.Catalog.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
