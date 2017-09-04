using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace Qingke365.RollCall.WebApi.Providers
{
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 验证 client 信息
        /// </summary>
        public override  async  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (clientId != "xishuai" || clientSecret != "123")
            {
                context.SetError("invalid_client", "client or clientSecret is not valid");
                return;
            }
            context.Validated();
        }

        /// <summary>
        /// 生成 access_token（client credentials 授权方式）
        /// </summary>
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(
                context.ClientId, OAuthDefaults.AuthenticationType),
                context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);
        }
    }
}
