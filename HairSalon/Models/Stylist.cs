using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string MyFirstName;
    private string MyLastName;
    private string MyPhoneNumber;
    private string MyEmail;
    private int MyID;
    // private List<Client> MyClients;
    // private static List<Stylist> AllStylists = new List<Stylist>();

    public Stylist(string firstName, string lastName, string phoneNumber, string email, int ID = 0){
      MyFirstName = firstName;
      MyLastName = lastName;
      MyPhoneNumber = phoneNumber;
      MyEmail = email;
      // MyClients = new List<Client>();
      // AllStylists.Add(this);
      MyID = ID;
    }

    public string GetFirstName(){ return MyFirstName; }
    public string GetLastName(){ return MyLastName; }
    public string GetPhoneNumber(){ return MyPhoneNumber; }
    public string GetEmail(){ return MyEmail; }
    public int GetID(){ return MyID; }

    public List<Client> GetClients(){
      List<Client> allStylistClients = new List<Client>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylistID = @stylistID;";
      MySqlParameter stylistID = new MySqlParameter();
      stylistID.ParameterName = "@stylistID";
      stylistID.Value = this.MyID;
      cmd.Parameters.Add(stylistID);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientID = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string phoneNumber = rdr.GetString(3);
        string email = rdr.GetString(4);
        Client newClient = new Client(firstName, lastName, phoneNumber, email, this.MyID, clientID);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }

    public static List<Stylist> GetAll() {
      List<Stylist> allStylists = new List<Stylist>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int stylistID = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string phoneNumber = rdr.GetString(3);
        string email = rdr.GetString(4);
        Stylist newStylist = new Stylist(firstName, lastName, phoneNumber, email, stylistID);
        allStylists.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allStylists;
    }

    public void SetFirstName(string firstName){ MyFirstName = firstName; }
    public void SetLastName(string lastName){ MyLastName = lastName; }
    public void SetPhoneNumber(string phoneNumber){ MyPhoneNumber = phoneNumber; }
    public void SetEmail(string email){ MyEmail = email; }
    // public void AddClient(Client c){ MyClients.Add(c); }

    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_ID, specialty_ID) VALUES (@stylistID, @specialtyID);";
      MySqlParameter stylist_ID = new MySqlParameter();
      stylist_ID.ParameterName = "@stylistID";
      stylist_ID.Value = MyID;
      cmd.Parameters.Add(stylist_ID);
      MySqlParameter specialty_ID = new MySqlParameter();
      specialty_ID.ParameterName = "@specialtyID";
      specialty_ID.Value = newSpecialty.GetID();
      cmd.Parameters.Add(specialty_ID);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists; DELETE FROM stylists_specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      Client.ClearAll();
    }

    public void Delete(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE ID = @thisID; DELETE FROM clients WHERE stylistID = @thisID; DELETE from stylists_specialties WHERE stylist_ID = @thisID;";
      MySqlParameter thisID = new MySqlParameter();
      thisID.ParameterName = "@thisID";
      thisID.Value = this.MyID;
      cmd.Parameters.Add(thisID);
      cmd.ExecuteNonQuery();
      // var cmd2 = conn.CreateCommand() as MySqlCommand;
      // cmd2.CommandText = @"DELETE FROM clients WHERE stylistID = @stylistID;";
      // MySqlParameter stylistID = new MySqlParameter();
      // stylistID.ParameterName = "@stylistID";
      // stylistID.Value = this.MyID;
      // cmd2.Parameters.Add(stylistID);
      // cmd2.ExecuteNonQuery();
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
      cmd.CommandText = @"INSERT INTO stylists (firstName, lastName, phoneNumber, email) VALUES (@firstName, @lastName, @phoneNumber, @email);";
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
      cmd.ExecuteNonQuery();
      MyID = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Specialty> GetSpecialties(){
      List<Specialty> allSpecialties = new List<Specialty>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists JOIN stylists_specialties ON (stylists.ID = stylists_specialties.stylist_ID) JOIN specialties ON (stylists_specialties.specialty_ID = specialties.ID) WHERE stylists.ID = (@stylistID);";
      MySqlParameter stylistID = new MySqlParameter();
      stylistID.ParameterName = "@stylistID";
      stylistID.Value = MyID;
      cmd.Parameters.Add(stylistID);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int specialtyID = rdr.GetInt32(0);
        string description = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(description, specialtyID);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public void Edit(string newFirstName, string newLastName, string newPhoneNumber, string newEmail){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET firstName = @firstName, lastName = @lastName, phoneNumber = @phoneNumber, email = @email WHERE ID = @searchID;";
      MySqlParameter searchID = new MySqlParameter();
      searchID.ParameterName = "@searchID";
      searchID.Value = MyID;
      cmd.Parameters.Add(searchID);
      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@firstName";
      firstName.Value = newFirstName;
      cmd.Parameters.Add(firstName);
      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@lastName";
      lastName.Value = newLastName;
      cmd.Parameters.Add(lastName);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = newPhoneNumber;
      cmd.Parameters.Add(phoneNumber);
      MySqlParameter email = new MySqlParameter();
      email.ParameterName = "@email";
      email.Value = newEmail;
      cmd.Parameters.Add(email);
      cmd.ExecuteNonQuery();
      MyFirstName = newFirstName;
      MyLastName = newLastName;
      MyPhoneNumber = newPhoneNumber;
      MyEmail = newEmail;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist){
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool stylistEquality = (this.GetFirstName() == newStylist.GetFirstName() && this.GetLastName() == newStylist.GetLastName() && this.GetPhoneNumber() == newStylist.GetPhoneNumber() && this.GetEmail() == newStylist.GetEmail() && this.GetID() == newStylist.GetID());
        return (stylistEquality);
      }
    }

    public static Stylist Find(int id){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE ID = @thisID;";
      MySqlParameter thisID = new MySqlParameter();
      thisID.ParameterName = "@thisID";
      thisID.Value = id;
      cmd.Parameters.Add(thisID);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistID = 0;
      string firstName = "";
      string lastName = "";
      string phoneNumber = "";
      string email = "";
      while (rdr.Read())
      {
        stylistID = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        phoneNumber = rdr.GetString(3);
        email = rdr.GetString(4);
      }
      Stylist foundStylist = new Stylist(firstName, lastName, phoneNumber, email, stylistID);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }
  }
}
