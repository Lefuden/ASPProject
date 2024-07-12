using ASPProjectFrontend.Repositories;

namespace ASPProjectFrontend.Services;

public partial class ApiServices(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, IJwtTokenValidator jwtValidator)
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly HttpClient _client = httpClientFactory.CreateClient("ApiASPProject");
    private readonly IJwtTokenValidator _jwtValidator = jwtValidator;
}
