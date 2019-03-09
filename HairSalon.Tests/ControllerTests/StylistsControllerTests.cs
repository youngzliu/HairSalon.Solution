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
      public void Form_ReturnsCorrectView_True(){
        StylistsController controller = new StylistsController();
        ActionResult indexView = controller.Form();
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
    }
}
