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

    public ClientTest(){
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=young_liu_test;";
    }

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
      newClient.Save();
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient, newClient2 };

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      Client testClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetID());

      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfClientsAreSame_Client()
    {
      Client newClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);
      Client newClient2 = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);

      Assert.AreEqual(newClient, newClient2);
    }

    [TestMethod]
    public void Save_AssignsIDToClient_ID()
    {
      Client testClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 7);

      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetID();
      int testID = testClient.GetID();

      Assert.AreEqual(testID, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      Client testClient = new Client("Bob", "Foo", "607-499-0243", "bobfooATgmailDOTcom", 3);
      testClient.Save();
      string altFirstName = "Kara";
      string altLastName = "Danvers";
      string altPhoneNumber = "603-682-9071";
      string altEmail = "karadanversATgmailDOTcom";
      Client altClient = new Client(altFirstName, altLastName, altPhoneNumber, altEmail, 3, testClient.GetID());

      testClient.Edit(altFirstName, altLastName, altPhoneNumber, altEmail);

      Assert.AreEqual(testClient, altClient);
    }

    [TestMethod]
    public void Delete_DeletesClient_Client(){
      Client testClient = new Client("Kara", "Danvers", "603-682-9071", "karadanversATgmailDOTcom", 3);
      testClient.Save();
      List<Client> emptyList = new List<Client>();

      testClient.Delete();
      List<Client> postDeleteClients = Client.GetAll();

      CollectionAssert.AreEqual(emptyList, postDeleteClients);
    }
  }
}
