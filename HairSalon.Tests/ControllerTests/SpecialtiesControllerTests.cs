using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTest{
    public SpecialtiesControllerTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=young_liu_test;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True(){
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_SpecialtyList(){
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True(){
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult newView = controller.New();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult(){
      SpecialtiesController controller = new SpecialtiesController();
      IActionResult view = controller.Create("Mullet");
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index(){
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.Create("Mullet") as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual(result, "Index");
    }
  }
}
