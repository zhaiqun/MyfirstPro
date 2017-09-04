using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Qingke365.RollCall.WebApi.Startup))]
namespace Qingke365.RollCall.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);

            //var configuration = new HttpConfiguration();
            //WebApiConfig.Register(configuration);
            //app.Use(configuration);
        }
    }
}