﻿using BIT.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BIT.AspNetCore
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {


        //TODO implement protection https://github.com/cuongle/Hmac.WebApi/blob/master/Hmac.Api/Filters/AuthenticateAttribute.cs
        //TODO implement protection https://stackoverflow.com/questions/11775594/how-to-secure-an-asp-net-web-api
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Todo read if authentication is on
            // do something before the action executes
            var keys = context.HttpContext.Request.Headers["Token"];


            var memoryCache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));

            string Key = string.Empty;
            string Issuer = string.Empty;
            bool IsAuthenticationOn = true;
            if ((!memoryCache.TryGetValue(nameof(Key), out Key)) || (!memoryCache.TryGetValue(nameof(Issuer), out Issuer))|| (!memoryCache.TryGetValue(nameof(IsAuthenticationOn), out IsAuthenticationOn)))
            {

                var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");

                var Configuration = builder.Build();
                //reading the values for first time
                Key = Configuration["Token:Key"];
                Issuer = Configuration["Token:Issuer"];
                IsAuthenticationOn = bool.Parse(Configuration["Token:IsAuthenticationOn"]);



                //put the values in the memory cache to avoid reading them all the time
                memoryCache.Set(nameof(Key), Key);
                memoryCache.Set(nameof(Issuer), Issuer);
                memoryCache.Set(nameof(IsAuthenticationOn), IsAuthenticationOn);
            }
            else
            {
                Key = memoryCache.Get<string>(nameof(Key));
                Issuer= memoryCache.Get<string>(nameof(Issuer));
                IsAuthenticationOn = memoryCache.Get<bool>(nameof(IsAuthenticationOn));
            }

            if(IsAuthenticationOn)
            {
                if (!JwtService.VerifyToken(keys, Key, Issuer))
                {
                    context.Result = new UnauthorizedResult();
                }
            }


          
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}