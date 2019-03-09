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
    }
}
