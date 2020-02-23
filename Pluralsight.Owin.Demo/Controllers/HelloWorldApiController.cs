using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pluralsight.Owin.Demo.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldApiController : ApiController
    {
        /// <summary>
        /// Path will be /api/hello for this action
        /// </summary>
        /// <returns></returns>
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
        }
    }
}