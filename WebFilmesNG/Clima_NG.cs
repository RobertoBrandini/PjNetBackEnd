using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebFilmesModel;

namespace WebFilmesNG
{
    public static class Clima_NG
    {
        public static DataTable ObterClima()
        {
            return WebFilmesAD.ClimaAD.ObterClima();
        }

        public static Int32 InserirClima(WebFilmesModel.Clima objClima)
        {
            return WebFilmesAD.ClimaAD.InserirClima(objClima);
        }


        public static DataTable DownloadClima()
        {
            string urlClima = @"http://api.openweathermap.org/data/2.5/forecast/daily?q=49095780&mode=json&units=metric&cnt=16";
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(urlClima);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                var weatherData = (WeatherData)serializer.ReadObject(ms);
                Clima objClima = new Clima();

                foreach (var item in weatherData.list)
                {
                    objClima.dt = item.dt.ToString();
                    objClima.temp_dia = Convert.ToDecimal(item.temp.day.ToString());
                    objClima.temp_tarde = Convert.ToDecimal(item.temp.eve.ToString());
                    objClima.temp_noite = Convert.ToDecimal(item.temp.night.ToString());
                    int data = Convert.ToInt32(item.dt.ToString());
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    objClima.data = epoch.AddSeconds((int)data);
                    
                    objClima.velocidade_vento = Convert.ToDecimal(item.speed.ToString());
                    objClima.nuvens = Convert.ToInt32(item.clouds.ToString());
                    if (!string.IsNullOrEmpty(item.rain.ToString()))
                        objClima.chuva = (int)(Math.Round(Convert.ToDecimal(item.rain.ToString()), MidpointRounding.ToEven));
                    else
                        objClima.chuva = 0;

                    foreach (var desc in item.weather)
                    {
                        objClima.nuvens_descricao = desc.main.ToString();
                        objClima.descricao = desc.description.ToString();
                        objClima.icone = desc.icon.ToString();
                        WebFilmesAD.ClimaAD.InserirClima(objClima);
                    }


                }
            }

            return ObterClima();

        }
    }
}
