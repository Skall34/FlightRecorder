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

        public async Task<(List<Avion>, List<Aeroport>)> FetchDataAsync()
        {
            List<Avion> avions = new List<Avion>();
            List<Aeroport> aeroports = new List<Aeroport>();

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

                        if (data.TryGetValue("data1", out var data1))
                        {
                            foreach (var item in data1)
                            {
                                Avion avion = new Avion
                                {
                                    Index = int.TryParse(item.TryGetValue("index", out string index) ? index : "", out int indexValue) ? indexValue : 0,
                                    ICAO = item.TryGetValue("ICAO", out string icao) ? icao : "",
                                    Type = item.TryGetValue("Type", out string type) ? type : "",
                                    Immat = item.TryGetValue("Immat", out string immat) ? immat : "",
                                    Localisation = item.TryGetValue("Localisation", out string localisation) ? localisation : "",
                                    Hub = item.TryGetValue("Hub", out string hub) ? hub : "",
                                    CoutHoraire = int.TryParse(item.TryGetValue("Cout Horaire", out string cout) ? cout : "", out int coutValue) ? coutValue : 0,
                                    Etat = int.TryParse(item.TryGetValue("Etat", out string etat) ? etat : "", out int etatValue) ? etatValue : 0,
                                    Status = int.TryParse(item.TryGetValue("Status", out string status) ? status : "", out int statusValue) ? statusValue : 0,
                                    Horametre = item.TryGetValue("Horametre", out string horametre) ? horametre : "",
                                    DernierUtilisateur = item.TryGetValue("Dernier utilisateur", out string utilisateur) ? utilisateur : ""
                                };

                                avions.Add(avion);
                            }
                        }

                        if (data.TryGetValue("data2", out var data2))
                        {
                            foreach (var item in data2)
                            {
                                Aeroport aeroport = new Aeroport
                                {
                                    Ident = item.TryGetValue("Ident", out string ident) ? ident : "",
                                    Type = item.TryGetValue("type", out string type) ? type : "",
                                    Name = item.TryGetValue("name", out string name) ? name : "",
                                    Municipality = item.TryGetValue("municipality", out string municipality) ? municipality : "",
                                    LatitudeDeg = double.TryParse(item.TryGetValue("latitude_deg", out string latitude) ? latitude : "", out double latitudeValue) ? latitudeValue : 0,
                                    LongitudeDeg = double.TryParse(item.TryGetValue("longitude_deg", out string longitude) ? longitude : "", out double longitudeValue) ? longitudeValue : 0,
                                    ElevationFt = int.TryParse(item.TryGetValue("elevation_ft", out string elevation) ? elevation : "", out int elevationValue) ? elevationValue : 0,
                                    Piste = item.TryGetValue("Piste", out string piste) ? piste : "",
                                    LongueurDePiste = item.TryGetValue("Longueur de piste", out string longueur) ? longueur : "",
                                    TypeDePiste = item.TryGetValue("Type de piste", out string typePiste) ? typePiste : "",
                                    Observations = item.TryGetValue("Observations", out string observations) ? observations : "",
                                    WikipediaLink = item.TryGetValue("wikipedia_link", out string wikiLink) ? wikiLink : "",
                                    Fret = int.TryParse(item.TryGetValue("fret", out string fret) ? fret : "", out int fretValue) ? fretValue : 0,
                                };

                                aeroports.Add(aeroport);
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

            return (avions, aeroports);
        }



        public async Task FillComboBoxAsync(ComboBox comboBox)
        {
            var (avions, _) = await FetchDataAsync();
            if (avions != null)
            {
                comboBox.Items.AddRange(avions.Select(avion => avion.Immat).Where(immat => !string.IsNullOrEmpty(immat)).ToArray());
            }
        }



    }
}
