using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GuessTheNumber
{
    public class GameResult
    {
        public string Date { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Attempts { get; set; }
        public string Result { get; set; } = string.Empty;
    }

    public class FileStorage
    {
        private readonly string _filepath;

        public FileStorage(string filepath = "../../../statistics.json")
        {
            _filepath = filepath;
        }

        public void SaveResult(GameResult resultData)
        {
            List<GameResult> list = new List<GameResult>();

            if (File.Exists(_filepath))
            {
                string json = File.ReadAllText(_filepath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    list = JsonSerializer.Deserialize<List<GameResult>>(json) ?? new List<GameResult>();
                }
            }

            list.Add(resultData);
            
            string newJson = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, newJson);
        }

        public List<GameResult> GetAllStats()
        {
            if (File.Exists(_filepath))
            {
                string json = File.ReadAllText(_filepath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<GameResult>>(json) ?? new List<GameResult>();
                }
            }
            return new List<GameResult>();
        }
    }
}
