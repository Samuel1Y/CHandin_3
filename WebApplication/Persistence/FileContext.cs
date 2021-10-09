using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace FileData
{
    public class FileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges<T>(IList<T> list, bool isFamily)
        {
            if (isFamily)
            {
                // storing families
                string jsonFamilies = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
                {
                    outputFile.Write(jsonFamilies);
                }
            }
            else
            {
                // storing persons
                string jsonAdults = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
                {
                    outputFile.Write(jsonAdults);
                }
            }
        }
    }
}