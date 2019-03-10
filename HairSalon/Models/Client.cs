using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    private string MyFirstName;
    private string MyLastName;
    private string MyPhoneNumber;
    private string MyEmail;
    private int MyID;
    private int MyStylistID;
    private static List<Client> AllClients = new List<Client>();

    public Client(string firstName, string lastName, string phoneNumber, string email, int StylistID){
      MyFirstName = firstName;
      MyLastName = lastName;
      MyPhoneNumber = phoneNumber;
      MyEmail = email;
      MyStylistID = StylistID;
      AllClients.Add(this);
      MyID = AllClients.Count;
    }

    public string GetFirstName(){ return MyFirstName; }
    public string GetLastName(){ return MyLastName; }
    public string GetPhoneNumber(){ return MyPhoneNumber; }
    public string GetEmail(){ return MyEmail; }
    public int GetID(){ return MyID; }
    public int GetStylistID(){ return MyStylistID; }
    public static List<Client> GetAll(){ return AllClients; }

    public void SetFirstName(string firstName){ MyFirstName = firstName; }
    public void SetLastName(string lastName){ MyLastName = lastName; }
    public void SetPhoneNumber(string phoneNumber){ MyPhoneNumber = phoneNumber; }
    public void SetEmail(string email){ MyEmail = email; }
    public void SetStylistID(int stylistID){ MyStylistID = stylistID; }
    public static void ClearAll(){ AllClients.Clear(); }
  }
}
