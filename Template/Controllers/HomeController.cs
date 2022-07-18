using Microsoft.AspNetCore.Mvc;
using Template.Models;

namespace Template.Controllers
{
  public class HomeController : Controller
  {
    //Hello() method is a route and will create a special path/ pattern (server searches HomeController for Hello() method)
    //hello friend returning is the "Action"
    //right below is the route decorator (used to easily declare custom URL paths for each route)
    //.cshtml files should never be named based on route decorators. If they are, View() won't be able to find them.
    [Route("/hello")]
    public string Hello() { return "Hello friend!"; }

    [Route("/goodbye")]
    public string Goodbye() { return "Goodbye friend."; }
    //Here with the / we no longer need to append a path. This is the Homepage
    //Here, view locates the Views DIR in the production project
    //Then MethodForRoute() route (since it's in HomeController) it will look for the subdirectory Home
    //Now the method looks for the matching file name (in this case, MethodForRoute.cshtml) - now the view method can return the HTML in this file
    [Route("/")]
    public ActionResult MethodForRoute()
    {
      TemplateVariable myTemplateVariable = new TemplateVariable();
      myTemplateVariable.Recipient = "Output";
      return View(myTemplateVariable);
    }

    [Route("/form")]
    public ActionResult Form() { return View(); }
    
    [Route("/Output")]
    public ActionResult OutputForm(string recipient)
    {
      TemplateVariable myTemplateVariable = new TemplateVariable();
      myTemplateVariable.Recipient = recipient;
      return View(myTemplateVariable);
    }
  }
}