using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
