﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NelitaBeautyStudio.Web.Startup))]
namespace NelitaBeautyStudio.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
