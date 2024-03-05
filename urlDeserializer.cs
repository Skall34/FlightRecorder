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

        public async Task<(List<Avion>, List<Aeroport>, List<Mission>)> FetchDataAsync()
        {
            List<Avion> avions = new List<Avion>();
            List<Aeroport> aeroports = new List<Aeroport>();
            List<Mission> missions = new List<Mission>();

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

                        if (data.TryGetValue("flotte", out var flotte))
                        {
                            foreach (var item in flotte)
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

                        if (data.TryGetValue("airports", out var airports))
                        {
                            foreach (var item in airports)
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

                        if (data.TryGetValue("missions", out var missionTemp))
                        {
                            foreach (var item in missionTemp)
                            {
                                Mission mission = new Mission
                                {
                                    Libelle = item.TryGetValue("Libelle", out string libMission) ? libMission : "",
                                    Index = int.TryParse(item.TryGetValue("Index", out string indexMission) ? indexMission : "", out int index) ? index : 0,
                                };

                                missions.Add(mission);
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

            return (avions, aeroports,missions);
        }



        public async Task FillComboBoxImmatAsync(ComboBox comboBox)
        {
            var (avions, _, _) = await FetchDataAsync();
            if (avions != null)
            {
                // Effacez les éléments existants dans la combobox
                comboBox.Items.Clear();

                // Parcourez la liste des avions
                foreach (var avion in avions)
                {
                    // Vérifiez si le statut de l'avion est égal à 1
                    if (avion.Status == 1 || avion.Status == 2)
                    {
                        // Si le statut est égal à 1, passez à l'itération suivante
                        continue;
                    }

                    // Ajoutez l'immatriculation de l'avion à la combobox
                    comboBox.Items.Add(avion.Immat);
                }
            }
        }


        public async Task FillComboBoxMissionsAsync(ComboBox comboBox)
        {
            var (_, _, missions) = await FetchDataAsync();
            if (missions != null)
            {
                comboBox.Items.AddRange(missions.Select(mission => mission.Libelle).Where(mission => !string.IsNullOrEmpty(mission)).ToArray());
            }
        }

    }
}
