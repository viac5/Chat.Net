using System;
using System.IO;

namespace Client
{
    class ActionsAuthorizationData
    {
        private string filePath = "data.txt";
        public void SaveData(string login, string password, string key)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Login:{login}");
                    writer.WriteLine($"Password:{password}");
                    writer.WriteLine($"Key:{key}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при записи данных: {ex.Message}");
            }
        }

        public string[] ReadData()
        {
            string data = "";
            string[] arrData = [];
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            data += line.Split(':')[1] + "\n";
                        data = data.Substring(0, data.Length - 1);
                    }
                    arrData = data.Split('\n');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при чтении данных: {ex.Message}");
            }
            return arrData;
        }
    }
}
