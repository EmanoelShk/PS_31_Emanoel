using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLoginFramework
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        private const string fileName = "ActivitiesLog.txt";

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserUsername + ";" + LoginValidation.CurrentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(activityLine);
            writer.Close();
        }

        public static IEnumerable<string> GetAllActivities()
        {
            StreamReader reader = new StreamReader(fileName);
            IList<string> allActivities = new List<string>();
            while (true)
            {
                string line = reader.ReadLine();
                if (line ==  null)
                {
                    reader.Close();
                    break;
                }
                allActivities.Add(line);
            }

            return allActivities;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                                where activity.Contains(filter)
                                                select activity).ToList();
            return filteredActivities;
        }
    }
}
