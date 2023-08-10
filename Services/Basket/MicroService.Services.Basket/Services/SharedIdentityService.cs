namespace MicroService.Services.Basket.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserID => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
