using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebFilmesModel
{
    [System.ComponentModel.DataObject(true)]
    public class Clima
    {

# pragma warning disable 1591

        public System.Int32 ID_Clima { get; set; }
        public System.String dt { get; set; }
        public System.DateTime? data { get; set; }
        public System.Decimal? temp_dia { get; set; }
        public System.Decimal? temp_tarde { get; set; }
        public System.Decimal? temp_noite { get; set; }
        public System.String nuvens_descricao { get; set; }
        public System.String descricao { get; set; }
        public System.String icone { get; set; }
        public System.Decimal? velocidade_vento { get; set; }
        public System.Int32? nuvens { get; set; }
        public System.Int32? chuva { get; set; }

#pragma warning restore 1591

    }

    [DataContract]
    public class WeatherData
    {
        [DataMember]
        public string cod { get; set; }

        [DataMember]
        public double message { get; set; }

        [DataMember]
        public City city { get; set; }

        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public List<List> list { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double? rain { get; set; }
    }



}
