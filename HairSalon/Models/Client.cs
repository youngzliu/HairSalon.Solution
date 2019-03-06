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

    public Client(string firstName, string lastName, string phoneNumber, string phoneNumber, string email, int ID, int StylistID){
      MyFirstName = firstName;
      MyLastName = lastName;
      MyPhoneNumber = phoneNumber;
      MyEmail = email;
      myID = ID;
      MyStylistID = StylistID;
    }

    public void SetFirstName(string firstName){ MyFirstName = firstName; }
    public void SetLastName(string lastName){ MyLastName = lastName; }
    public void SetPhoneNumber(string phoneNumber){ MyPhoneNumber = phoneNumber; }
    public void SetEmail(string email){ MyEmail = email; }
    public void SetID(int ID){ MyID = ID; }
    public void SetStylistID(int stylistID){ MyStylistID = stylistID; }

    public string GetFirstName(){ return MyFirstName; }
    public string GetLastName(){ return MyLastName; }
    public string GetPhoneNumber(){ return MyPhoneNumber; }
    public string GetEmail(){ return MyEmail; }
    public int GetID(){ return MyID; }
    public int GetStylistID(){ return MyStylistID; }
  }
}
