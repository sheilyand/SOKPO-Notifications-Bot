using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace SOKPO_NotificationsBot_Tests
{
    public class Tests
    {

        [Test]
        [Description("Проверяет корректность конфигурационного файла бота")]
        public void IsThereAConfig()
        {
            string configFileName = "config.json";
            string projectName = "SOKPO-NotificationsBot";

            char sep = Path.DirectorySeparatorChar;
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string configFile = File.ReadAllText($"{solutionDir}{sep}{projectName}{sep}{configFileName}");
            try
            {
                JObject parsedJson = JObject.Parse(configFile);
            }
            catch
            {
                Assert.Fail("Не удалось распарсить конфигурационный файл как JSON");
            }
        }
    }
}