// BlitzKarteService.cs 
using Blitzkarten.Models;
using System.Text.Json;

namespace Blitzkarten.Services
{
    public class BlitzKarteService
    {
        public BlitzKarteService()
        {
            CopyJsonFileIfNotExists();
        }

        private static void CopyJsonFileIfNotExists()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "DeuA1.json");
            if (!File.Exists(filePath))
            {
                using var stream = FileSystem.OpenAppPackageFileAsync("DeuA1.json").Result;
                using var reader = new StreamReader(stream);
                var content = reader.ReadToEnd();
                File.WriteAllText(filePath, content);
            }
        }

        public static async Task<List<BlitzKarte>> LoadBlitzKarten()
        {
            string dataFile = Path.Combine(FileSystem.AppDataDirectory, "DeuA1.json");

            // If file doesn't exist, copy from bundled assets
            if (!File.Exists(dataFile))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("DeuA1.json");
                using var reader = new StreamReader(stream);
                var defaultData = await reader.ReadToEndAsync();
                await File.WriteAllTextAsync(dataFile, defaultData);
            }

            var json = await File.ReadAllTextAsync(dataFile);
            var result = JsonSerializer.Deserialize<List<BlitzKarte>>(json);
            return result ?? [];
        }
    }
}
