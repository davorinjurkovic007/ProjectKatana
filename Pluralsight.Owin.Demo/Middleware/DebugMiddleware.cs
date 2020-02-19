using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
>;

namespace Pluralsight.Owin.Demo
{
    public class DebugMiddleware
    {
        readonly AppFunc _next;
        private readonly DebugMiddlewareOptions options;

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            this.options = options;

            if(this.options.OnIncomingRequest == null)
            {
                this.options.OnIncomingRequest = ctx => { Debug.WriteLine("Incoming request in Options: " + ctx.Request.Path); };
            }

            if (this.options.OnOutgoingRequest == null)
            {
                this.options.OnOutgoingRequest = ctx => { Debug.WriteLine("Outgoing request in Options: " + ctx.Request.Path); };
            }
        }

        public async Task Invoke(IDictionary<string, object> enviroment)
        {
            var ctx = new OwinContext(enviroment);
            // Alternative call
            // var path = (string)enviroment["owin.RequestPath"];

            options.OnIncomingRequest(ctx);
            await _next(enviroment);
            options.OnOutgoingRequest(ctx);
        }
    }
}