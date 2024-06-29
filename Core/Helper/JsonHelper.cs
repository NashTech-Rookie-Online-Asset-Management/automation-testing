
using Newtonsoft.Json;

using System.Reflection;


namespace AssetManagement.Core.Helper
{
    public class JsonHelper
    {
        //Official
        public static string ReadJsonFile(string path)
        {
            string currentDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            path = Path.Combine(currentDirectoryPath, path);

            if (!File.Exists(path))
            {
                throw new Exception("Can't find file: " + path);
            }

            return File.ReadAllText(path);
        }

        public static T ReadAndParse<T>(string path) where T : class
        {
            var jsonContent = ReadJsonFile(path);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }



        //public static IEnumerable<T> LoadJsonData<T>(string fileLocation)
        //{
        //    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        //    string jsonFilePath = Path.Combine(projectDirectory, fileLocation);
        //    var jsonString = File.ReadAllText(jsonFilePath);
        //    return JsonConvert.DeserializeObject<List<T>>(jsonString);

        //}
    }
    //    public static IEnumerable<T> GetData<T>(string filePath, string testType = "all") where T : ITestable
    //    {

    //        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../"));
    //        string jsonFilePath = Path.Combine(projectRoot, filePath);
    //        string jsonData = File.ReadAllText(jsonFilePath);


    //        List<T> testCases = JsonConvert.DeserializeObject<List<T>>(jsonData);


    //        return testCases.Where(tc => tc.TestType == testType);
    //    }


    //    public static IEnumerable<T> GetData<T>(string filePath)
    //    {

    //        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../"));
    //        string jsonFilePath = Path.Combine(projectRoot, filePath);
    //        string jsonData = File.ReadAllText(jsonFilePath);

    //        return JsonConvert.DeserializeObject<List<T>>(jsonData);
    //    }
    //}


}
