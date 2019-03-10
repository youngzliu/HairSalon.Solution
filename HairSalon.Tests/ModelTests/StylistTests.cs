using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose() { Stylist.ClearAll(); }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String(){
      string firstName = "Bob";
      Stylist newStylist = new Stylist(firstName, "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      string result = newStylist.GetFirstName();
      Assert.AreEqual(firstName, result);
    }

    [TestMethod]
    public void GetLastName_ReturnsLastName_String(){
      string lastName = "Foo";
      Stylist newStylist = new Stylist("Bob", lastName, "607-499-0243", "bobfooATgmailDOTcom");
      string result = newStylist.GetLastName();
      Assert.AreEqual(lastName, result);
    }

    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String(){
      string phoneNumber = "607-499-0243";
      Stylist newStylist = new Stylist("Bob", "Foo", phoneNumber, "bobfooATgmailDOTcom");
      string result = newStylist.GetPhoneNumber();
      Assert.AreEqual(phoneNumber, result);
    }

    [TestMethod]
    public void GetEmail_ReturnsEmail_String(){
      string email = "bobfooATgmailDOTcom";
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", email);
      string result = newStylist.GetEmail();
      Assert.AreEqual(email, result);
    }

    [TestMethod]
    public void GetID_ReturnsID_Int(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      int result = newStylist.GetID();
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetClients_ReturnsClients_ListClient(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      Client newClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);
      List<Client> clientList = new List<Client> {newClient};
      newStylist.AddClient(newClient);

      List<Client> result = newStylist.GetClients();

      CollectionAssert.AreEqual(clientList, result);
    }

    [TestMethod]
    public void SetFirstName_SetsFirstName_String(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");

      string newFirstName = "Kara";
      newStylist.SetFirstName(newFirstName);
      string result = newStylist.GetFirstName();

      Assert.AreEqual(newFirstName, result);
    }

    [TestMethod]
    public void SetLastName_SetsLastName_String(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");

      string newLastName = "Danvers";
      newStylist.SetLastName(newLastName);
      string result = newStylist.GetLastName();

      Assert.AreEqual(newLastName, result);
    }

    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");

      string newPhoneNumber = "390-275-3988";
      newStylist.SetPhoneNumber(newPhoneNumber);
      string result = newStylist.GetPhoneNumber();

      Assert.AreEqual(newPhoneNumber, result);
    }

    [TestMethod]
    public void SetEmail_SetsEmail_String(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");

      string newEmail = "bobfooATyahooDOTcom";
      newStylist.SetEmail(newEmail);
      string result = newStylist.GetEmail();

      Assert.AreEqual(newEmail, result);
    }

    [TestMethod]
    public void AddClient_AddsClient_Client(){
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      Client newClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 3);
      List<Client> clientList = new List<Client> {newClient};

      newStylist.AddClient(newClient);
      List<Client> result = newStylist.GetClients();

      CollectionAssert.AreEqual(clientList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_StylistList()
    {
      List<Stylist> newList = new List<Stylist>();
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      Stylist newStylist2 = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");
      List<Stylist> newList = new List<Stylist> { newStylist, newStylist2 };

      List<Stylist> result = Stylist.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      Stylist newStylist = new Stylist("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom");
      Stylist newStylist2 = new Stylist("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom");

      Stylist result = Stylist.Find(2);

      Assert.AreEqual(newStylist2, result);
    }
  }
}
