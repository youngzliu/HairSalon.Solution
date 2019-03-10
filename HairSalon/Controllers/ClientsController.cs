using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/stylists/{stylistID}/clients/{clientID}")]
    public ActionResult Show(int stylistID, int clientID){
      Client client = Client.Find(clientID);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistID);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    [HttpGet("/stylists/{stylistID}/clients/new")]
    public ActionResult New(int stylistID)
    {
      Stylist stylist = Stylist.Find(stylistID);
      return View(stylist);
    }

    // [HttpGet("/stylists")]
    // public ActionResult Index() {
    //   List<Stylist> allStylists = Stylist.GetAll();
    //   return View(allStylists);
    // }
    //
    // [HttpGet("/stylists/new")]
    // public ActionResult New() { return View(); }
    //
    // [HttpPost("/stylists")]
    // public ActionResult Create(string firstName, string lastName, string phoneNumber, string email){
    //   Stylist sty = new Stylist(firstName, lastName, phoneNumber, email);
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpPost("/stylists/delete")]
    // public ActionResult DeleteAll(){
    //   Stylist.ClearAll();
    //   return View();
    // }
    //
    // [HttpGet("/stylists/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist selectedStylist = Stylist.Find(id);
    //   List<Client> stylistClients = selectedStylist.GetClients();
    //   model.Add("stylist", selectedStylist);
    //   model.Add("clients", stylistClients);
    //   return View(model);
    // }
  }
}
