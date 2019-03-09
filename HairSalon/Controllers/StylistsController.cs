using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index() {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult Form() { return View(); }

    [HttpPost("/stylists")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, string email){
      Stylist sty = new Stylist(firstName, lastName, phoneNumber, email, 1);
      return RedirectToAction("Index");
    }
  }
}
