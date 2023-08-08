using MongoDB.Bson.Serialization.Attributes;

namespace MicroService.Services.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
