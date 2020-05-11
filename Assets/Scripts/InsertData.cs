using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class InsertData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/OudeKerk";
        // open Connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();


        // Insert into Table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT or IGNORE into Memories (id, name, memory, date) VALUES (1, 'Sander', 'Hoi', 22-04-2020), (2, 'Roel', 'Testing some more', 23-04-2020), (3, 'Blbla', 'Testing some more', 23-04-2020)";
        cmnd.ExecuteNonQuery();
        dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
