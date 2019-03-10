using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose(){ Client.ClearAll(); }

    [TestMethod]
    public void ClientContstructor_CreatesInstanceOfClient_Client(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 8);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String(){
      string firstName = "Bob";
      Client newClient = new Client(firstName, "Foo", "607-499-0243", "bobfooATgmailDOTcom", 8);
      string result = newClient.GetFirstName();
      Assert.AreEqual(firstName, result);
    }

    [TestMethod]
    public void GetLastName_ReturnsLastName_String(){
      string lastName = "Foo";
      Client newClient = new Client("Bob", lastName, "607-499-0243", "bobfooATgmailDOTcom", 8);
      string result = newClient.GetLastName();
      Assert.AreEqual(lastName, result);
    }

    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String(){
      string phoneNumber = "607-499-0243";
      Client newClient = new Client("Bob", "Foo", phoneNumber, "bobfooATgmailDOTcom", 8);
      string result = newClient.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }

    [TestMethod]
    public void GetEmail_ReturnsEmail_String(){
      string email = "bobfooATgmailDOTcom";
      Client newClient = new Client("Bob", "Foo", "607-499-0243", email, 3);
      string result = newClient.GetEmail();
      Assert.AreEqual(email, result);
    }

    [TestMethod]
    public void GetID_ReturnsID_Int(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);
      int result = newClient.GetID();
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetStylistID_ReturnsStylistID_Int(){
      int stylistID = 8;
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", stylistID);
      int result = newClient.GetStylistID();
      Assert.AreEqual(stylistID, result);
    }

    [TestMethod]
    public void SetFirstName_SetsFirstName_String(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);

      string newFirstName = "Kara";
      newClient.SetFirstName(newFirstName);
      string result = newClient.GetFirstName();

      Assert.AreEqual(newFirstName, result);
    }

    [TestMethod]
    public void SetLastName_SetsLastName_String(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);

      string newLastName = "Danvers";
      newClient.SetLastName(newLastName);
      string result = newClient.GetLastName();

      Assert.AreEqual(newLastName, result);
    }

    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);

      string newPhoneNumber = "390-275-3988";
      newClient.SetPhoneNumber(newPhoneNumber);
      string result = newClient.GetPhoneNumber();

      Assert.AreEqual(newPhoneNumber, result);
    }

    [TestMethod]
    public void SetEmail_SetsEmail_String(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);

      string newEmail = "bobfooATyahooDOTcom";
      newClient.SetEmail(newEmail);
      string result = newClient.GetEmail();

      Assert.AreEqual(newEmail, result);
    }

    [TestMethod]
    public void SetStylistID_SetsStylistID_Int(){
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);

      int newStylistID = 7;
      newClient.SetStylistID(newStylistID);
      int result = newClient.GetStylistID();

      Assert.AreEqual(newStylistID, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList(){
      List<Client> newList = new List<Client>();
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);
      Client newClient2 = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);
      List<Client> newList = new List<Client> { newClient, newClient2 };

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      Client newClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);
      Client newClient2 = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);

      Client result = Client.Find(2);

      Assert.AreEqual(newClient2, result);
    }
  }
}
