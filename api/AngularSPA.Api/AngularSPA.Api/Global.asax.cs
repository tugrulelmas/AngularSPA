﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace AngularSPA.Api
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e) {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}