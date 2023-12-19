using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class Database : MonoBehaviour
{
    string dbName = "URI=file:" + @"D:\Unity projects\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap.db";
    public int targetPlateNumber = 10; 

    void Start()
    {
        getData();
    }

    void Update()
    {

    }

    public void getData()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Hedef PlateNumber'ý sorgunuzda kullanmak için doðru syntax kullanýn
                string sorgu = "SELECT NaturalDisasters FROM TurkeyRiskMap WHERE PlateNumber = "+ targetPlateNumber;
                command.CommandText = sorgu;

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
        }
    }
}