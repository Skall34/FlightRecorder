using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightRecorder
{
    public class UrlDeserializer
    {
        private readonly string _url;

        public UrlDeserializer(string url)
        {
            _url = url;
        }

        public async Task<(List<string>, List<string>, List<AirportsFromFic>)> FetchDataAsync()
        {
            List<string> immatriculations = new List<string>();
            List<string> localisations = new List<string>();
            List<AirportsFromFic> data2Items = new List<AirportsFromFic>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        // Désérialisation du JSON
                        var data = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonString);

                        foreach (var dataList in data.Values)
                        {
                            foreach (var item in dataList)
                            {
                                if (item.TryGetValue("Immat", out string immat) && !string.IsNullOrEmpty(immat))
                                {
                                    immatriculations.Add(immat);
                                }
                                if (item.TryGetValue("Localisation", out string localisation) && !string.IsNullOrEmpty(localisation))
                                {
                                    localisations.Add(localisation);
                                }
                            }
                        }

                        if (data.TryGetValue("data2", out var data2))
                        {
                            foreach (var item in data2)
                            {
                                AirportsFromFic data2Item = new AirportsFromFic
                                {
                                    ICAO = item["ICAO"],
                                    Type = item["type"],
                                    Name = item["name"],
                                    Municipality = item["municipality"],
                                    LatitudeDeg = double.Parse(item["latitude_deg"]),
                                    LongitudeDeg = double.Parse(item["longitude_deg"]),
                                    ElevationFt = int.Parse(item["elevation_ft"]),
                                    Piste = item["Piste"],
                                    LongueurDePiste = item["Longueur de piste"],
                                    TypeDePiste = item["Type de piste"],
                                    Observations = item["Observations"],
                                    WikipediaLink = item["wikipedia_link"],
                                    Fret = int.Parse(item["fret"]),
                                    Pax = int.Parse(item["pax"])
                                };

                                data2Items.Add(data2Item);
                            }
                        }
                    }
                    else
                    {
                        // Gérer les erreurs si la requête n'a pas réussi
                        Console.WriteLine("Erreur lors de la récupération des données : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Gérer les exceptions
                    Console.WriteLine("Erreur lors de la récupération des données : " + ex.Message);
                }
            }

            return (immatriculations, localisations, data2Items);
        }



        public async Task FillComboBoxAsync(ComboBox comboBox)
        {
            (List<string> immatriculations, _, _) = await FetchDataAsync();
            comboBox.Items.AddRange(immatriculations.ToArray());
        }

    }
}
