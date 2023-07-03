using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers;

public class Model{
    public string Name {get;set;}
}


[Route("/api/Home")]
public class HomeController : Controller
{
    private Hospital_DBN context;
    

    [HttpGet("GetPart")]
    public IEnumerable<Part>  GetPart()
    {        
        return  context.Part;
    }

    public HomeController(Hospital_DBN ctx)
    {
        context = ctx;  
    }

    

     

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}


    [HttpGet("GetPartCount")]
    public int GetPartCount()
    {
        var blogs = context.Part.Count();

        return blogs  ;

    }

    [HttpGet("GetModels")]
    public IEnumerable<Model> GetModels(){
        return new List<Model>(){
            new Model(){  Name= "Riza" }
        };
    } 
}
