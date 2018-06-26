using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
  public class MySQL
  {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //private string _query;
   /* public  string Query
    {
      get {return _query;}
      set {_query = value;}
    }*/

    public MySQL()
    {
      Initialise();
    }

    private void Initialise()
    {
      server = "localhost";
      database = "bugs";
      uid = "root";
      password = "root";

      string connectionString;
      
      connectionString = "SERVER=" + server + ";" + 
                         "DATABASE=" + database + ";" + 
                         "UID=" + uid + ";" + 
                         "PASSWORD=" + password + ";";
      connection = new MySqlConnection(connectionString);
    }

    private void OpenConnection()
    {
      try
      {
        connection.Open();
      }
      catch (MySqlException ex)
      {
        switch (ex.Number)
        {
          case 0:
            throw new Exception("Cannot connect to databaaase server " + ex.Source);
          //MessageBox.Show("Cannot connect to database server");
          //break;
          case 1044:
          case 1045:
            throw new Exception("Invalid username/password to connect with database " + ex.Source);
          //MessageBox.Show("Invalid username/password to connect with database");
          //break;
          default:
            throw new Exception("Couldn't able to open db connection " + ex.Source);
            //MessageBox.Show("Connection to database couldn't be opened");
            //break;
        }
      }
    }
    private void CloseConnection()
    {
      try
      {
        connection.Close();
      }
      catch (MySqlException ex)
      {
        throw new Exception("Couldn't able to CLOSE a connection to databas: " + ex.Source);
      }
    }
    public void Update()
    {
    }

    public bool Delete(string query)
    {
      bool isDeleted = false;

      this.OpenConnection();
      MySqlCommand cmd = new MySqlCommand(query, connection);
      var effectedRows = cmd.ExecuteNonQuery();
      this.CloseConnection();

      if (effectedRows > 0)
        isDeleted = true;
      
      return isDeleted;
    }

    
    public bool IsUserAdmin(string query)
    {
            //List<string>[] data = new List<string>()[];

            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            else
                return false;
        }



    //public int Count()
    //{

    //}
  }
}
