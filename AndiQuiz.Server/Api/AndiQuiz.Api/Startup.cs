﻿using Microsoft.Owin;
using Owin;
using System.Web.Http;

using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using AndiQuiz.Server.Common.Constants;

[assembly: OwinStartup(typeof(AndiQuiz.Server.Api.Startup))]

namespace AndiQuiz.Server.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            
            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
