using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest{
    public ClientsControllerTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=young_liu_test;";
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1);
      ActionResult showView = controller.Show(1, 1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1);
      ViewResult showView = controller.Show(1,1) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      ActionResult newView = controller.New(1);
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_HasCorrectModelType_Stylist(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      ViewResult newView = controller.New(1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Stylist));
    }

    [TestMethod]
    public void Edit_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1, 1);
      ActionResult showView = controller.Edit(1, 1);
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Edit_HasCorrectModelType_Dictionary(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1, 1);
      ViewResult newView = controller.Edit(1, 1) as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Update_ReturnsCorrectView_True(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1, 1);
      ActionResult showView = controller.Update(1, 1, "bla", "foo", "340-203-6833", "blaATgmailDOTcom");
      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Update_HasCorrectModelType_Dictionary(){
      ClientsController controller = new ClientsController();
      Stylist stylist = new Stylist("kara", "danvers", "409-582-3251", "karadanversATgmailDOTcom");
      Client client = new Client("bob", "foo", "324-635-0182", "bobfooATgmailDOTcom", 1, 1);
      ViewResult newView = controller.Update(1, 1, "bla", "foo", "340-203-6833", "blaATgmailDOTcom") as ViewResult;
      var result = newView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }
  }
}
