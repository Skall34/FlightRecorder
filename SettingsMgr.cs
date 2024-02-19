using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

//This a SettingsMgr class all designed by chatgpt

public class SettingsMgr
{
    private string _settingsFilePath;

    public const string GFORMURL = "GoogleFormUrl";
    public const string CALLSIGNENTRY = "callsign_entry";
    public const string AIRCRAFTENTRY = "aircraft_entry";
    public const string PAXENTRY = "pax_entry";
    public const string CARGOENTRY = "cargo_entry";

    public const string STARTIATAENTRY = "startIata_entry";
    public const string STARTFUELENTRY = "startFuel_entry";
    public const string STARTTIMEENTRY = "startTime_entry";

    public const string ENDIATAENTRY = "endIata_entry";
    public const string ENDFUELENTRY = "endFuel_entry";
    public const string ENDTIMEENTRY = "endTime_entry";

    public const string FLIGHTNOTEENTRY = "flightNote_entry";
    public const string COMMENTENTRY = "comment_entry";

        [JsonInclude]
    private Settings? _settings;
    public Settings? allSettings
    {
        get
        {
            return _settings;
        }
    }


    public SettingsMgr(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
        if (!LoadSettings())
        {
            _settings=new Settings();
        }
    }

    public bool LoadSettings()
    {
        bool result=false;
        try
        {
            string json = File.ReadAllText(_settingsFilePath);
            _settings = JsonSerializer.Deserialize<Settings>(json);
            result = true;
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            Console.WriteLine($"Error loading settings: {ex.Message}");
            _settings = new Settings();
        }
        return result;
    }

    public void SaveSettings()
    {
        try
        {
            string json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_settingsFilePath, json);
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            Console.WriteLine($"Error saving settings: {ex.Message}");
        }
    }

    public class Settings
    {
        public  class GFormSettings
        {
            [JsonInclude]
            public  Dictionary<string, string> Setting;


            public GFormSettings()
            {
                Setting= new Dictionary<string, string>(); 
            }

            public string getValue(string key)
            {
                if (Setting.ContainsKey(key))
                {
                    return Setting[key];
                }
                else
                {
                    return string.Empty;
                }
            }

            public void setValue(string key,string value )
            {
                Setting[key] = value;
            }
        }

        [JsonInclude]
        public GFormSettings gformSettings;

        public  class Fleet
        {
            [JsonInclude]
            public  List<string> AircraftModels { get; set; }
            [JsonInclude] 
            public  Dictionary<string,List<string>> Immats { get; set; }

            public Fleet()
            {
                AircraftModels = new List<string>(); ;
                Immats = new Dictionary<string,List<string>>();
            }

            public  void addAircraftModel(string aircraftModel)
            {
                if (!AircraftModels.Contains(aircraftModel))
                {
                    AircraftModels.Add(aircraftModel);
                    Immats[aircraftModel] = new List<string>();
                }
            }

            public  void addImmat(string aircraftModel,string immat)
            {
                if (!AircraftModels.Contains(aircraftModel))
                {
                    AircraftModels.Add(aircraftModel);
                    Immats[aircraftModel]=new List<string>();
                }
                if (!Immats[aircraftModel].Contains(immat))
                {
                    Immats[aircraftModel].Add(immat);
                }
            }

        }

        [JsonInclude]
        public Fleet fleet;

        public Settings()
        {
            gformSettings=new GFormSettings();
            fleet=new Fleet();
        }

    }
}
