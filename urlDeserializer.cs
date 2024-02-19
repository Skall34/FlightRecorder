using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightRecorder
{
    
    public class urlDeserializer
    {
        private readonly string _url;

        public urlDeserializer(string url)
        {
            _url = url;
        }

        public async Task<List<string>> FetchDataAsync()
        {
            List<string> immatriculations = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        // Désérialisation du JSON
                        DataObject? dataObject = JsonConvert.DeserializeObject<DataObject>(jsonString);
                        if (null != dataObject)
                        {
                            if (null != dataObject.Data)
                            {
                                foreach (DataItem item in dataObject.Data)
                                {
                                    if ((null != item) && (null != item.Immat))
                                    {
                                        immatriculations.Add(item.Immat);
                                    }
                                }
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

            return immatriculations;
        }

        public async Task FillComboBoxAsync(ComboBox comboBox)
        {
            List<string> immatriculations = await FetchDataAsync();
            comboBox.Items.AddRange(immatriculations.ToArray());
        }
    }

    // Classe pour représenter la structure du JSON
    public class DataObject
    {
        public List<DataItem>? Data { get; set; }
    }

    public class DataItem
    {
        public string? Immat { get; set; }
        public string? Label { get; set; }
        public string? Lieu { get; set; }
    }
}
