using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public void Dispose(){  }

    public SpecialtyTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=young_liu_test;";
    }

    [TestMethod]
    public void SpecialtyContstructor_CreatesInstanceOfSpecialty_Specialty(){
      Specialty newSpecialty = new Specialty("Mullet");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String(){
      string description = "Mullet";
      Specialty newSpecialty = new Specialty("Mullet");
      string result = newSpecialty.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetID_ReturnsID_Int(){
      Specialty newSpecialty = new Specialty("Mullet", 5);
      int result = newSpecialty.GetID();
      Assert.AreEqual(5, result);
    }


    [TestMethod]
    public void SetDescription_SetsDescription_String(){
      Specialty specialty = new Specialty("Mullet");

      string newDescription = "Short Bob";
      specialty.SetDescription(newDescription);
      string result = specialty.GetDescription();

      Assert.AreEqual(newDescription, result);
    }


  }
}
