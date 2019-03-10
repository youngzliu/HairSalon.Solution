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
    public ActionResult New() { return View(); }

    [HttpPost("/stylists")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, string email){
      Stylist sty = new Stylist(firstName, lastName, phoneNumber, email);
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll(){
      Stylist.ClearAll();
      return View();
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      return View(model);
    }

    [HttpPost("/stylists/{stylistID}/clients")]
    public ActionResult Create(int stylistID, string firstName, string lastName, string phoneNumber, string email)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistID);
      Client newClient = new Client(firstName, lastName, phoneNumber, email, stylistID);
      foundStylist.AddClient(newClient);
      List<Client> stylistClients = foundStylist.GetClients();
      model.Add("stylist", foundStylist);
      model.Add("clients", stylistClients);
      return View("Show", model);
    }
  }
}
