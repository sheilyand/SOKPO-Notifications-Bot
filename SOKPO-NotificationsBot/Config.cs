using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace SOKPO_NotificationsBot
{
    class Config
    {
        public string token;
        public Config() 
        {
            token = ReadToken();
        }

        /// <summary>
        /// Распарсить конфигурационный файл
        /// </summary>
        /// <returns></returns>
        JObject GetConfig() 
        {
            string configFileName = "config.json";
            char sep = Path.DirectorySeparatorChar;
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string configFile = File.ReadAllText($"{solutionDir}{sep}{configFileName}");
            try
            {
                return JObject.Parse(configFile);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Не удалось распарсить конфигурационный файл!");
            }
            
             
        }

        /// <summary>
        /// Вытянуть токен из конфиг файла
        /// </summary>
        /// <returns></returns>
        string ReadToken() 
        {

            JObject parsedJson = GetConfig();
            try
            {
                return parsedJson["token"].Value<string>();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Не удалось получить токен бота из конфигурационного файла!");
            }
        }
    }
}
