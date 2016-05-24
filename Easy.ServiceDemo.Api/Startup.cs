﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Easy.ServiceDemo.Api.Startup))]

namespace Easy.ServiceDemo.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //config.Filters.Add(new ErrorAttribute());

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
