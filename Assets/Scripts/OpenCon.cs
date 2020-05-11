using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class OpenCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/OudeKerk";

        // open Connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDataReader reader;

        //// Create table
        IDbCommand dbcmd = dbcon.CreateCommand();
        string q_createTable =
          "CREATE TABLE IF NOT EXISTS Memories (id INTEGER PRIMARY KEY, name TEXT, memory TEXT, date DATE )";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();

        Debug.Log("We have a connection");

        dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
