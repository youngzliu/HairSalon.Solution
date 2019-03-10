using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
    // private static List<Client> AllClients = new List<Client>();

    public Client(string firstName, string lastName, string phoneNumber, string email, int stylistID, int ID = 0){
      MyFirstName = firstName;
      MyLastName = lastName;
      MyPhoneNumber = phoneNumber;
      MyEmail = email;
      MyStylistID = stylistID;
      // AllClients.Add(this);
      MyID = ID;
    }

    public string GetFirstName(){ return MyFirstName; }
    public string GetLastName(){ return MyLastName; }
    public string GetPhoneNumber(){ return MyPhoneNumber; }
    public string GetEmail(){ return MyEmail; }
    public int GetID(){ return MyID; }
    public int GetStylistID(){ return MyStylistID; }
    public static List<Client> GetAll(){
      List<Client> allClients = new List<Client>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int clientID = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string phoneNumber = rdr.GetString(3);
        string email = rdr.GetString(4);
        int stylistID = rdr.GetInt32(0);
        Client newClient = new Client(firstName, lastName, phoneNumber, email, stylistID, clientID);
        allClients.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allClients;
    }

    public void SetFirstName(string firstName){ MyFirstName = firstName; }
    public void SetLastName(string lastName){ MyLastName = lastName; }
    public void SetPhoneNumber(string phoneNumber){ MyPhoneNumber = phoneNumber; }
    public void SetEmail(string email){ MyEmail = email; }
    public void SetStylistID(int stylistID){ MyStylistID = stylistID; }
    public static void ClearAll(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (firstName, lastName, phoneNumber, email, stylistID) VALUES (@firstName, @lastName, @phoneNumber, @email, @stylistID);";
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@firstName";
      firstName.Value = this.MyFirstName;
      cmd.Parameters.Add(firstName);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@lastName";
      lastName.Value = this.MyLastName;
      cmd.Parameters.Add(lastName);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = this.MyPhoneNumber;
      cmd.Parameters.Add(phoneNumber);
      MySqlParameter email = new MySqlParameter();
      email.ParameterName = "@email";
      email.Value = this.MyEmail;
      cmd.Parameters.Add(email);
      MySqlParameter stylistID = new MySqlParameter();
      stylistID.ParameterName = "@stylistID";
      stylistID.Value = this.MyStylistID;
      cmd.Parameters.Add(stylistID);
      cmd.ExecuteNonQuery();
      MyID = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherItem){
      if (!(otherItem is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherItem;
        bool descriptionEquality = (this.GetFirstName() == newClient.GetFirstName() && this.GetLastName() == newClient.GetLastName() && this.GetPhoneNumber() == newClient.GetPhoneNumber() && this.GetEmail() == newClient.GetEmail() && this.GetID() == newClient.GetID());
        return (descriptionEquality);
      }
    }

    public static Client Find(int searchID){ return new Client("bla", "bla", "bla", "bla", 5); }
  }
}
