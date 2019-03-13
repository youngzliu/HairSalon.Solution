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
      sty.Save();
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
      List<Specialty> stylistSpecialties = Specialty.GetAll();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", stylistSpecialties);
      return View(model);
    }

    [HttpPost("/stylists/{stylistID}/clients")]
    public ActionResult Create(int stylistID, string firstName, string lastName, string phoneNumber, string email)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistID);
      Client newClient = new Client(firstName, lastName, phoneNumber, email, stylistID);
      newClient.Save();
      // foundStylist.AddClient(newClient);
      List<Client> stylistClients = foundStylist.GetClients();
      List<Specialty> stylistSpecialties = Specialty.GetAll();
      model.Add("stylist", foundStylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", stylistSpecialties);
      return View("Show", model);
    }

    [HttpPost("stylists/{stylistID}/delete")]
    public ActionResult Destroy(int stylistID){
      Stylist.Find(stylistID).Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("stylists/{stylistID}/edit")]
    public ActionResult Edit(int stylistID)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistID);
      return View(stylist);
    }

    [HttpPost("/stylists/{stylistID}")]
    public ActionResult Update(int stylistID, string firstName, string lastName, string phoneNumber, string email)
    {
      Stylist stylist = Stylist.Find(stylistID);
      stylist.Edit(firstName, lastName, phoneNumber, email);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Client> stylistClients = stylist.GetClients();
      List<Specialty> stylistSpecialties = Specialty.GetAll();
      model.Add("stylist", stylist);
      model.Add("clients", stylistClients);
      model.Add("specialties", stylistSpecialties);
      return View("Show", model);
    }

    [HttpPost("/stylists/{stylistID}/clients/{clientID}/delete")]
    public ActionResult Destroy(int stylistID, int clientID){
      Client.Find(clientID).Delete();
      Stylist selectedStylist = Stylist.Find(stylistID);
      List<Client> stylistClients = selectedStylist.GetClients();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      List<Specialty> stylistSpecialties = Specialty.GetAll();
      model.Add("specialties", stylistSpecialties);
      return View("Show", model);
    }

    [HttpPost("/stylists/{stylistID}/specialties/new")]
    public ActionResult AddSpecialty(int stylistID, int specialtyID)
    {
      Stylist stylist = Stylist.Find(stylistID);
      Specialty specialty = Specialty.Find(specialtyID);
      stylist.AddSpecialty(specialty);
      return RedirectToAction("Show", new {id = stylistID});
    }
  }
}
