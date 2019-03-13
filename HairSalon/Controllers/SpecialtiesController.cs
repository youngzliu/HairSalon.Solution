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

    [HttpGet("/specialties/{ID}")]
    public ActionResult Show(int id){
      Specialty specialty = Specialty.Find(id);
      List<Stylist> stylists = specialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("specialty", specialty);
      model.Add("stylists", stylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialties/{specialtyID}/stylists/new")]
    public ActionResult AddStylist(int specialtyID, int stylistID)
    {
      Specialty specialty = Specialty.Find(specialtyID);
      Stylist stylist = Stylist.Find(stylistID);
      specialty.AddStylist(stylist);
      return RedirectToAction("Show",  new { id = specialtyID });
    }
  }
}
