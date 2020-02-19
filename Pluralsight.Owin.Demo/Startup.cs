using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

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
            
            app.Use(async (ctx, next) => {
                await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>");
                Debug.WriteLine("Just after hello world: " + ctx.Request.Path);
            });
        }
    }
}