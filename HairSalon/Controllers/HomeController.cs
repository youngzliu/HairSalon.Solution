using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index() { return View(); }

    [Route("/form")]
    public ActionResult Form() { return View(); }

    [Route("/stylist")]
    public ActionResult Stylist(string firstName, string lastName, string phoneNumber, string email){
      Stylist sty = new Stylist(firstName, lastName, phoneNumber, email, 1);
      return View(sty);
    }
  }
}
