using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest{

      [TestMethod]
      public void Create_ReturnsCorrectActionType_RedirectToActionResult(){
        StylistsController controller = new StylistsController();
        IActionResult view = controller.Create("bob", "foo", "409-582-3251", "bobfooATgmailDOTcom");
        Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
      }

      [TestMethod]
      public void Create_RedirectsToCorrectAction_Index(){
        StylistsController controller = new StylistsController();
        RedirectToActionResult actionResult = controller.Create("bob", "foo", "409-582-3251", "bobfooATgmailDOTcom") as RedirectToActionResult;
        string result = actionResult.ActionName;
        Assert.AreEqual(result, "Index");
      }

      [TestMethod]
      public void New_ReturnsCorrectView_True(){
        StylistsController controller = new StylistsController();
        ActionResult indexView = controller.New();
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void Index_ReturnsCorrectView_True(){
        StylistsController controller = new StylistsController();
        ActionResult indexView = controller.Index();
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void Index_HasCorrectModelType_ItemList(){
        StylistsController controller = new StylistsController();
        ViewResult indexView = controller.Index() as ViewResult;
        var result = indexView.ViewData.Model;
        Assert.IsInstanceOfType(result, typeof(List<Stylist>));
      }

      [TestMethod]
      public void Delete_ReturnsCorrectView_True(){
        StylistsController controller = new StylistsController();
        ActionResult indexView = controller.DeleteAll();
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void Show_ReturnsCorrectView_True(){
        StylistsController controller = new StylistsController();
        Stylist stylist = new Stylist("bob", "foo", "409-582-3251", "bobfooATgmailDOTcom");
        ActionResult indexView = controller.Show(1);
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

      [TestMethod]
      public void Show_HasCorrectModelType_Stylist(){
        StylistsController controller = new StylistsController();
        Stylist stylist = new Stylist("bob", "foo", "409-582-3251", "bobfooATgmailDOTcom");
        ViewResult indexView = controller.Show(1) as ViewResult;
        var result = indexView.ViewData.Model;
        Assert.IsInstanceOfType(result, typeof(Stylist));
      }
    }
}
