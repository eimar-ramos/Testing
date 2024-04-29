using System.Security.Claims;

using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Interfaces;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Web.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
