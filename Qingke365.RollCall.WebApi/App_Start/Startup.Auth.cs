using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Qingke365.RollCall.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qingke365.RollCall.WebApi
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/token"), //获取 access_token 授权服务请求地址
                AuthorizeEndpointPath = new PathString("/authorize"), //获取 authorization_code 授权服务请求地址
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10), //access_token 过期时间

                Provider = new OpenAuthorizationServerProvider(), //access_token 相关授权服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 授权服务
            };
            app.UseOAuthBearerTokens(OAuthOptions); //表示 token_type 使用 bearer 方式
        }
    }
}