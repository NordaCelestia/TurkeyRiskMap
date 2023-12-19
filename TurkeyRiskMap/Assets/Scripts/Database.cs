using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour
{
    private SQLiteConnection _connection;



    void Start()
    {
        string dbPath = "URI=file:" + @"D:\Unity projects\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap\TurkeyRiskMap.db";

        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        string cityinfo = GetCityInformationByPlateNumber(23);
        Debug.Log(cityinfo);
    }


    void Update()
    {
        
    }

    private void OnDestroy()
    {
        
        if (_connection != null)
        {
            _connection.Close();
        }
    }

    [Table("TurkeyRiskMap")]
    public class DataModel
    {
        [PrimaryKey]
        public int Platenumber { get; set; }

        [Column("City")]
        public string City { get; set;  }

        [Column("SoilType")]
        public string SoilType { get; set; }

        [Column("Population")]
        public int Population { get; set; }

        [Column("AreaMeasurement")]
        public int AreaMesurement { get; set; }

        [Column("CityInformation")]
        public string CityInformation { get; set; }

        [Column("NaturalDisasters")]
        public string NaturalDisasters { get; set; }

        [Column("Rainfall")]
        public int Rainfall { get; set; }
    }

    private string GetCityInformationByPlateNumber(int plateNumber)
    {
        // SQLite sorgusu: Plaka numarasý 23 olan þehrin City bilgisini al
        var queryResult = _connection.Table<DataModel>().Where(x => x.Platenumber == plateNumber).FirstOrDefault();

        // Eðer sonuç varsa City bilgisini al, yoksa boþ bir string döndür
        return queryResult != null ? queryResult.City : string.Empty;
    }
}



