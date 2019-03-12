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

    public void SetDescription(string description){ MyDescription = description; }
    
  }
}
