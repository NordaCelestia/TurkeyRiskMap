using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;

public class Database : MonoBehaviour
{
    string dbName = "URI=file:" + @"D:\Unity projects\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap.db";
    string data;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public string getData(int targetPlateNumber, string commandText)
    {
        using (var connection = new SqliteConnection(dbName))
        {

            string disaster = "SELECT NaturalDisasters FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string city = "SELECT City FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string soil = "SELECT SoilType FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string population = "SELECT Population FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string area = "SELECT AreaMeasurement FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string cityInfo = "SELECT CityInformation FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;
            string rainfall = "SELECT Rainfall FROM TurkeyRiskMap WHERE PlateNumber = " + targetPlateNumber;

            switch (commandText)
            {
                case "disaster":
                    commandText = disaster;
                    break;
                case "city":
                    commandText = city;
                    break;
                case "soil":
                    commandText = soil;
                    break;
                case "population":
                    commandText = population;
                    break;
                case "area":
                    commandText = area;
                    break;
                case "cityInfo":
                    commandText = cityInfo;
                    break;
                case "rainfall":
                    commandText = rainfall;
                    break;
            }


            connection.Open();

                using (var command = connection.CreateCommand())
                {


                    command.CommandText = commandText;

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data = reader.GetString(0);
                            
                        }
                        else
                        {
                            Debug.Log("Veri bulunamadý.");
                        }
                    }
                }
                
            
            
            connection.Close();
        }

        return data;
    }

    
}