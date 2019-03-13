using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private string MyDescription;
    private int MyID;

    public Specialty(string description, int ID = 0){
      MyDescription = description;
      MyID = ID;
    }

    public string GetDescription() { return MyDescription; }
    public int GetID() { return MyID; }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties; DELETE FROM stylists_specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
    }

    public void SetDescription(string description){ MyDescription = description; }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_ID, specialty_ID) VALUES (@stylistID, @specialtyID);";
      MySqlParameter stylist_ID = new MySqlParameter();
      stylist_ID.ParameterName = "@stylistID";
      stylist_ID.Value = newStylist.GetID();
      cmd.Parameters.Add(stylist_ID);
      MySqlParameter specialty_ID = new MySqlParameter();
      specialty_ID.ParameterName = "@specialtyID";
      specialty_ID.Value = MyID;
      cmd.Parameters.Add(specialty_ID);
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
      cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@description);";
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@description";
      description.Value = this.MyDescription;
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();
      MyID = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetStylists(){
      List<Stylist> allStylists = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM stylists JOIN stylists_specialties ON (stylists.ID = stylists_specialties.stylist_ID) JOIN specialties ON (stylists_specialties.specialty_ID = specialties.ID) WHERE specialties.ID = (@specialtyID);";
      MySqlParameter specialtyID = new MySqlParameter();
      specialtyID.ParameterName = "@specialtyID";
      specialtyID.Value = MyID;
      cmd.Parameters.Add(specialtyID);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistID = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string phoneNumber = rdr.GetString(3);
        string email = rdr.GetString(4);
        Stylist newStylist = new Stylist(firstName, lastName, phoneNumber, email, stylistID);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static List<Specialty> GetAll(){
      List<Specialty> allSpecialties = new List<Specialty>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read()){
        int ID = rdr.GetInt32(0);
        string description = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(description, ID);
        allSpecialties.Add(newSpecialty);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allSpecialties;
    }

    public static Specialty Find(int id){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE ID = @thisID;";
      MySqlParameter thisID = new MySqlParameter();
      thisID.ParameterName = "@thisID";
      thisID.Value = id;
      cmd.Parameters.Add(thisID);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int specialtyID = 0;
      string description = "";
      while (rdr.Read())
      {
        specialtyID = rdr.GetInt32(0);
        description = rdr.GetString(1);
      }
      Specialty foundSpecialty = new Specialty(description, specialtyID);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundSpecialty;
    }

    public override bool Equals(System.Object otherSpecialty){
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool specialtyEquality = (this.GetDescription() == newSpecialty.GetDescription() && this.GetID() == newSpecialty.GetID());
        return (specialtyEquality);
      }
    }
  }
}
