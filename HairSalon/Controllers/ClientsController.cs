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

    [HttpGet("/stylists/{stylistID}/clients/{clientID}/edit")]
    public ActionResult Edit(int stylistID, int clientID)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistID);
      model.Add("stylist", stylist);
      Client client = Client.Find(clientID);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/stylists/{stylistID}/clients/{clientID}")]
    public ActionResult Update(int stylistID, int clientID, string firstName, string lastName, string phoneNumber, string email)
    {
      Client client = Client.Find(clientID);
      client.Edit(firstName, lastName, phoneNumber, email);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistID);
      model.Add("stylist", stylist);
      model.Add("client", client);
      return View("Show", model);
    }
  }
}
