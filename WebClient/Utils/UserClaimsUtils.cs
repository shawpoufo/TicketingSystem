
using System.Security.Claims;

public static class UserClaimsUtil{

    public static int? GetId(this ClaimsPrincipal claimsPrincipal){
        var id = claimsPrincipal.Claims.FirstOrDefault( c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Convert.ToInt32(id);
    }
}