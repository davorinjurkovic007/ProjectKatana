using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Nancy.Owin;
using System.Net;
using System.Web.Http;

namespace Pluralsight.Owin.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = ctx =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took: " + watch.ElapsedMilliseconds + "ms");
                }
            });

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/Auth/Login")
            });

            app.Use(async (ctx, next) =>
            {
                if (ctx.Authentication.User.Identity.IsAuthenticated)
                    Debug.WriteLine("User: " + ctx.Authentication.User.Identity.Name);
                else
                    Debug.WriteLine("User Not Authenitcated");
                await next();
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

            //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            //app.UseNancy();
            app.UseNancy(configNancy =>
            {
                configNancy.PassThroughWhenStatusCodesAre(Nancy.HttpStatusCode.NotFound);
            });

            // Comment out becouse ASP.NET MVC. It wont work if this is in place
            //app.Use(async (ctx, next) => {
            //    await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>");
            //    Debug.WriteLine("Just after hello world: " + ctx.Request.Path);
            //});
        }
    }
}
