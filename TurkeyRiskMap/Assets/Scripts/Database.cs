using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class Database : MonoBehaviour
{
    string dbName = "URI=file:" + @"D:\Unity projects\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap.db"; 

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void getData(int targetPlateNumber)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                
                string disaster = "SELECT NaturalDisasters FROM TurkeyRiskMap WHERE PlateNumber = "+ targetPlateNumber;
                command.CommandText = disaster;

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string naturalDisaster = reader.GetString(0);
                        Debug.Log(naturalDisaster);
                    }
                    else
                    {
                        Debug.Log("Veri bulunamadý.");
                    }
                }
            }
            connection.Close();
        }
        
    }
}