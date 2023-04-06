using Newtonsoft.Json;

namespace TOTPApp.Classes
{
    internal static class LoadSaveManager
    {
        //Constants

        private const string fileName = "TotpData.txt";
        private const string folderName = "TotpApp";

        // Internal Methods

        internal static List<TOTPWrapper> LoadTotps()
        {
            string path = GetPath();

            if (!File.Exists(path))
            {
                return new();
            }

            string fileContents = File.ReadAllText(path);

            var deserialisedObject = JsonConvert.DeserializeObject<List<TOTPWrapper>>(fileContents);

            if (deserialisedObject == null)
            {
                throw new Exception($"Unable to deserialise {path}");
            }

            return deserialisedObject;
        }

        internal static void SaveTotps(List<TOTPWrapper> tOTPs)
        {
            string path = GetPath();

            string fileContents = JsonConvert.SerializeObject(tOTPs);

            FileInfo fileInfo = new(path);
            fileInfo.Directory?.Create();

            File.WriteAllText(path, fileContents);
        }

        // Private Methods

        private static string GetPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName, fileName);
        }
    }
}
