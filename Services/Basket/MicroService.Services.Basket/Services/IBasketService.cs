using MicroService.Services.Basket.Dtos;
using MicroService.Shared.Dtos;

namespace MicroService.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userID);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> DeleteBasket(string userID);

    }
}
