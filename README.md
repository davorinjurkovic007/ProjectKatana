# ProjectKatana
Example of project Katana 

Just basic example how to make basic project using OWIN with Katana

## Build a Simple OWIN Pipeline

* NuGet the required host
  - Microsoft.Owin.Host.SystemWeb
* Add public class Startup
* Add Configuration(IAppBuilder app) method
* Add Middlewares

## Creating Middleware with OWIN
* XXXMiddleware class
* XXXMiddlewareOptions class
* XXXMiddlewareExtensions

## Integrating Framework
We loked at how we could take NancyFx and ASP.NET Web API and plug them into the pipelne, 
lifting the abstraciton level of that delopment API a whole lot by giving us a much easier 
API to program against.  
And in the end we add ASP.NET MVC

## Securing OWIN Pipelines
* Add CookieAuthenticationMiddleware
* Authenticate user
  - IAuthenticationManager.SignIn()
* Use the user and the user's claims
* Log out user
  - IAuthenticationManager.SignOut()
