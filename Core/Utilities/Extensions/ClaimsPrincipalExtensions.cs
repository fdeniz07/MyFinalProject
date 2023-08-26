using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Extensions;

public static class ClaimsPrincipalExtensions
{
    //O an gelen(login olan) kisinin claimlerine ulasmak icin ClaimsPrincipal sinifini extend ediyoruz.
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        return result;
    }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal?.Claims(ClaimTypes.Role);

    public static int GetUserId(this ClaimsPrincipal claimsPrincipal) =>
        Convert.ToInt32(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
}
