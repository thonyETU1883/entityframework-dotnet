using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using entityframeworklearn.Models;

namespace entityframeworklearn.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Context context = new Context();
        Article article = new Article("clavier",800,0);
       /* List<Article> listearticle = article.requetepersonnalise(context);
        foreach(Article a in listearticle){
            Console.WriteLine("idarticle: "+a.getidarticle()+" nomarticle: "+a.getnomarticle()+" prix : "+a.getprix().ToString());
        }*/
        article.update(context,"article15");
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
}
