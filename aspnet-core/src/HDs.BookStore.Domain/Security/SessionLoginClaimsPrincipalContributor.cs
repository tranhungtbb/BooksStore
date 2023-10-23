using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace HDs.BookStore.Security
{
    public class SessionLoginClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
    {
        private readonly IdentityUserManager userManager;

        public SessionLoginClaimsPrincipalContributor(IdentityUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
            // todo update db
            var claimsIdentity = context.ClaimsPrincipal.Identities.FirstOrDefault();
            var userId = claimsIdentity?.FindUserId();
            if (userId.HasValue)
            {
                string currentSession = Guid.NewGuid().ToString("N");

                // save session_login to db
                claimsIdentity?.AddIfNotContains(new Claim("session_login", currentSession));
                await Task.CompletedTask;
            }
        }
    }

    public static class CurrentUserExtensions
    {
        public static string? GetSessionLogin(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue("session_login");
        }
    }

}
