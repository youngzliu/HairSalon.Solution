using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest
  {
    [TestMethod]
    public void ClientContstructor_CreatesInstanceOfClient_Client(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3, 8);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String(){
      string firstName = "Bob";
      Client newClient = new Client(firstName, "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3, 8);
      string result = newClient.GetFirstName();
      Assert.AreEqual(firstName, result);
    }

    [TestMethod]
    public void GetLastName_ReturnsLastName_String(){
      string lastName = "Foo";
      Client newClient = new Client("Bob", lastName, "607-499-0243", "bobfooATgmailDOTcom", 3, 8);
      string result = newClient.GetLastName();
      Assert.AreEqual(lastName, result);
    }

    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String(){
      string phoneNumber = "607-499-0243";
      Client newClient = new Client("Bob", "Foo", phoneNumber, "bobfooATgmailDOTcom", 3, 8);
      string result = newClient.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }

    [TestMethod]
    public void GetEmail_ReturnsEmail_String(){
      string email = "bobfooATgmailDOTcom";
      Client newClient = new Client("Bob", "Foo", "607-499-0243", email, 3, 8);
      string result = newClient.GetEmail();
      Assert.AreEqual(email, result);
    }

    [TestMethod]
    public void GetID_ReturnsID_Int(){
      int ID = 3;
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", ID, 8);
      int result = newClient.GetID();
      Assert.AreEqual(ID, result);
    }

    [TestMethod]
    public void GetStylistID_ReturnsStylistID_Int(){
      int stylistID = 8;
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3, stylistID);
      int result = newClient.GetStylistID();
      Assert.AreEqual(stylistID, result);
    }
  }
}
