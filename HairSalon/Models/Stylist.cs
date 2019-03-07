using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string MyFirstName;
    private string MyLastName;
    private string MyPhoneNumber;
    private string MyEmail;
    private int MyID;
    private List<Client> MyClients;
    private static List<Stylist> AllStylists = new List<Stylist>();

    public Stylist(string firstName, string lastName, string phoneNumber, string email, int ID){
      MyFirstName = firstName;
      MyLastName = lastName;
      MyPhoneNumber = phoneNumber;
      MyEmail = email;
      MyID = ID;
      MyClients = new List<Client>();
      AllStylists.Add(this);
    }

    public string GetFirstName(){ return MyFirstName; }
    public string GetLastName(){ return MyLastName; }
    public string GetPhoneNumber(){ return MyPhoneNumber; }
    public string GetEmail(){ return MyEmail; }
    public int GetID(){ return MyID; }
    public List<Client> GetClients(){ return MyClients; }
    public static List<Stylist> GetAll() { return AllStylists; }

    public void SetFirstName(string firstName){ MyFirstName = firstName; }
    public void SetLastName(string lastName){ MyLastName = lastName; }
    public void SetPhoneNumber(string phoneNumber){ MyPhoneNumber = phoneNumber; }
    public void SetEmail(string email){ MyEmail = email; }
    public void SetID(int ID){ MyID = ID; }
    public void AddClient(Client c){ MyClients.Add(c); }
    public static void ClearAll(){ AllStylists.Clear(); }
  }
}
