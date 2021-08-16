using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TranslatorLibrary
{
    public class Libra
    {
        public Dictionary<string, string> dictionary= new Dictionary<string, string>();

        public void Add(string word, string translation)
        {
            dictionary.Add(word, translation);
        }
        
        public void DictionaryFromFile(string path)
        {
            var doc = new StreamReader(path);
            while (doc.Peek() >=0)
            {
                var str = doc.ReadLine();
                var pair = str.Split(" - ");
                Add(pair[0],pair[1]);
            }
        }

        public void DictionaryFromJson(string path)
        {
            /*using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var restoredPerson = JsonSerializer.Deserialize<(string key, string value)>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            }*/
            
        }

        public async Task CreateJson()
        {
            using (FileStream fs = new FileStream("D:/newjsom.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<Dictionary<string, string>>(fs, dictionary);
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}