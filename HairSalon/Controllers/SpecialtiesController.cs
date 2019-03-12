using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index() {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New() { return View(); }

    [HttpPost("/specialties")]
    public ActionResult Create(string description){
      Specialty specialty = new Specialty(description);
      specialty.Save();
      return RedirectToAction("Index");
    }
  }
}
