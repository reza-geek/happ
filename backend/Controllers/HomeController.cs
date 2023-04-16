using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers;

public class Model{
    public string Name {get;set;}
}


[Route("/api/Home")]
[Authorize]
public class HomeController : Controller
{
    private Hospital_DBN2 context;
    

    [HttpGet("GetPart")]
    public IEnumerable<Part>  GetPart()
    {        
        return  context.Part;
    }
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,Hospital_DBN2 ctx)
    {
        context = ctx;  
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("GetModels")]
    public IEnumerable<Model> GetModels(){
        return new List<Model>(){
            new Model(){  Name= "Riza" }
        };
    } 
}
