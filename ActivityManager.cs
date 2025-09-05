using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TimeTracker
{
    public static class ActivityManager
    {
        private static readonly string FilePath = "activities.json";

        public static List<Activity> LoadActivities()
        {
            if (!File.Exists(FilePath)) return new List<Activity>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Activity>>(json) ?? new List<Activity>();
        }

        public static void SaveActivities(List<Activity> activities)
        {
            var json = JsonSerializer.Serialize(activities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
