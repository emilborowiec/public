# ASP.NET Cheat Sheet

### About ASP.NET platform

- ASP.NET is a platform for building all kinds of interactive web applications and services.
- ASP.NET is composed of **platform features**, **utility frameworks** and **application frameworks**.
- ASP.NET platform features include middleware, routing, razor engine, DI, model binding and more.
- ASP.NET application frameworks include mvc, razor pages and blazor.
- ASP.NET utility frameworks include **entity framework** and **identity**.
- Both MVC and Razor Pages are based on same platform features: middleware, endpoints, routing and razor.
- Middleware is set of components arranged in a pipeline for handling requests and responses.
- In ASP.NET application, programmer assembles middleware pipeline in `Startup.Configure` method.
- Request goes through middleware pipeline in order of adding middleware
- Response goes through the same middleware pipeline in reverse order
- Routing middleware looks at **Endpoints** defined in app and selects best match.
- `UseRouting` adds routing middleware to pipeline. At this point Endpoint gets associated wth HttpContext
- `UseEndpoints` adds and configures endpoint middleware. At this point endpoints will be executed.
- Endpoint is actually a `RequestDelegate` - a delegate accepting `HttpContext` and returning `Task`.
- Common endpoints include: controller actions, razor pages, lambda functions

### About MVC

- A controller is a class attributed with [Controller], derive from Controller and have Controller in name.
- To enable processing controllers, you need to `services.AddControllers()` in `Startup`.
- All public methods on a controller are **Actions**.
- Action is Endpoint
- Controllers support getting dependencies through construction injection and action injection.
- Routing to controllers and actions can be configured through **conventional routing** and **attribute routing**
- REST APIs should use attribute routing. Controllers with Views should use conventional routing.
- To enable attribute routing to controllers you need to do `endpoints.MapControllers()`.
- Actions can return `IActionResult` which is executed by framework to produce response.
- `Controller.View` helper method is used to produce `ViewResult` - a type of `IActionResult` that produces html response. 
- To enable processing views, you need to do `services.AddControllersWithViews()` in `Startup`.
- To enable conventional routing to controllers you need to do `endpoints.MapDefaultControllerRoute()`.
- Html response is based on Razor View (.cshtml) file. Also called just **View**.
- Framework finds View file based on convention:
    - Views/[ControllerName]/[ViewName].cshtml
    - Views/Shared/[ViewName].cshtml
- You can pass strongly typed data to view. It is then called **ViewModel**.
- Specify a view model using the @model directive. Use the model with @Model
- You can pass weakly typed data to view through ViewData, ViewDataAttribute or ViewBag.

### Roles in ASP.NET MVC
- Controller handles HTTP request through Action methods
- Controller can return View in response
- Controller initializes and passes ViewModel to View
- ViewModel holds data presented by the View
- View presents data and controls allowing user to send http requests
- Routing middleware selects Controller for http request
- Model Binder translates data from http request to action parameters or controller properties

### About Razor Pages
