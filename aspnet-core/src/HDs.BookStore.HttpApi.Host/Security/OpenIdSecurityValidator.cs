using System.Threading.Tasks;
using System;
using OpenIddict.Validation;
using static OpenIddict.Validation.OpenIddictValidationHandlers.Protection;
using static OpenIddict.Validation.OpenIddictValidationEvents;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Volo.Abp.Users;
using HDs.BookStore.Security;

namespace HDs.BookStore.OpenIddict
{
    public static class OpenIdSecurityValidator
    {
        public class SecurityValidator : IOpenIddictValidationHandler<ValidateTokenContext>
        {
            private readonly ICurrentUser currentUser;

            public static OpenIddictValidationHandlerDescriptor Descriptor { get; }
                = OpenIddictValidationHandlerDescriptor.CreateBuilder<ValidateTokenContext>()
                    .UseSingletonHandler<SecurityValidator>()
                    .SetOrder(ValidateIdentityModelToken.Descriptor.Order + 500)
                    .SetType(OpenIddictValidationHandlerType.Custom)
                    .Build();

            public SecurityValidator(ICurrentUser currentUser) => this.currentUser = currentUser;

            /// <inheritdoc/>
            public ValueTask HandleAsync(ValidateTokenContext context)
            {
                if (context is null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                var sessionLogin = context.Principal?.GetSessionLogin();

                var invalid = true;

                if (invalid)
                {
                    context.Reject(
                        error: Errors.InvalidToken,
                        description: "The token is invalid.");
                    return default;
                }

                return default;
            }
        }
    }
}
