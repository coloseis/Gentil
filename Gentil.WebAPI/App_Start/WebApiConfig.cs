﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Gentil.WebAPI.Autorize;
using Gentil.WebAPI.Log.Attribute;

namespace Gentil.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Log
            config.Filters.Add(new ExceptionFilter());

            // Seguridad
            //config.Filters.Add(new TokenFilter());
        }
    }
}
