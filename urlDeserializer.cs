using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<(List<Avion>, List<Mission>)> FetchDataAsync()
        {
            List<Avion> avions = new List<Avion>();
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

            return (avions, missions);
        }

        public async Task<List<Aeroport>> FetchAirportsDataAsync(string filename)
        {
            List<Aeroport> aeroports ;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        // Désérialisation du JSON
                        aeroports = await Aeroport.deserializeAeroports(jsonString);
                        //if we received airports, store them locally
                        if (aeroports != null)
                        {                           
                            StreamWriter sw= new StreamWriter(filename);
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(sw, aeroports);
                            sw.Close();
                        }
                    }
                    else
                    {
                        aeroports = new List<Aeroport>();
                            // Gérer les erreurs si la requête n'a pas réussi
                        Console.WriteLine("Erreur lors de la récupération des données : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    aeroports = new List<Aeroport>();
                    // Gérer les exceptions
                    Console.WriteLine("Erreur lors de la récupération des données : " + ex.Message);
                }
            }

            return aeroports;
        }



        //public async Task FillComboBoxImmatAsync(ComboBox comboBox)
        //{
        //    if (avions == null)
        //    {
        //        var (avions, _) = await FetchDataAsync();
        //    }

        //    if (avions != null)
        //    {
        //        // Effacez les éléments existants dans la combobox
        //        comboBox.Items.Clear();

        //        // Parcourez la liste des avions
        //        foreach (var avion in avions)
        //        {
        //            // Vérifiez si le statut de l'avion est égal à 1
        //            if (avion.Status == 1 || avion.Status == 2)
        //            {
        //                // Si le statut est égal à 1, passez à l'itération suivante
        //                continue;
        //            }

        //            // Ajoutez l'immatriculation de l'avion à la combobox
        //            comboBox.Items.Add(avion.Immat);
        //        }
        //    }
        //}


        //public async Task FillComboBoxMissionsAsync(ComboBox comboBox)
        //{
        //    var (_, missions) = await FetchDataAsync();
        //    if (missions != null)
        //    {
        //        comboBox.Items.AddRange(missions.Select(mission => mission.Libelle).Where(mission => !string.IsNullOrEmpty(mission)).ToArray());
        //    }
        //}

    }
}
