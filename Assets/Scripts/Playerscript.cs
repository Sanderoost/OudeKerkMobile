using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Playerscript : MonoBehaviour
{
    private GameObject book;
    public GameObject Memory;

    private int readerCount = 0;
    private IDataReader reader;
    private IDbConnection dbcon;

    // Start is called before the first frame update
    void Start()
    {
        book = GameObject.FindGameObjectWithTag("book");
        string connection = "URI=file:" + Application.persistentDataPath + "/OudeKerk";

        // open Connection
        dbcon = new SqliteConnection(connection);

        dbcon.Open();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = transform.position - book.transform.position;
        float distance = directionToTarget.z;
        if (distance > -1 && distance < 0.5){
            getData();
        }
    }


    void getData()
    {
   
        // read and print all values 
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query = "SELECT * FROM Memories";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            if (readerCount != 4)
            {
                GameObject Paper = Instantiate(Memory);
                Paper.transform.position = new Vector3(book.transform.position.x  + (readerCount * 0.35f), book.transform.position.y + 0.2f, book.transform.position.z);
                TextMesh[] components = Paper.GetComponentsInChildren<TextMesh>(true);
                components[0].text = reader[1].ToString();
                components[1].text = "28 April";
                components[2].text = reader[2].ToString();
                readerCount++;
            }
        }
        if (readerCount == 4)
        {
            dbcon.Close();
        }
    }
}

