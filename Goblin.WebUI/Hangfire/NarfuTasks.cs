using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Narfu.Domain;
using Narfu.Parsers;
using Narfu.Schedule;
using Newtonsoft.Json;

namespace Goblin.WebUI.Hangfire
{
    public class NarfuTasks
    {
        public async Task UpdateGroups()
        {
            var dllName = typeof(StudentsSchedule).Assembly.ManifestModule.Name;
            var location = typeof(StudentsSchedule).Assembly.Location.Replace(dllName, "");
            var dataPath = $"{location}Data\\Groups.json";

            var groups = await GetGroups();
            File.WriteAllText(dataPath, JsonConvert.SerializeObject(groups));
        }

        private async Task<Group[]> GetGroups()
        {
            //TODO: yield
            var schools = await SchoolParser.GetSchools();
            var returnGroups = new List<Group>();
            foreach(var school in schools)
            {
                var groups = await GroupsParser.GetGroupsFromSchool(school);
                returnGroups.AddRange(groups);
            }

            return returnGroups.ToArray();
        }
    }
}