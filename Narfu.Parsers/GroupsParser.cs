using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Narfu.Domain;
using Group = Narfu.Domain.Group;

namespace Narfu.Parsers
{
    public class GroupsParser
    {
        /// <summary>
        /// Получить список групп из высшей школы
        /// </summary>
        /// <returns>Массив с группами</returns>
        public static async Task<Group[]> GetGroupsFromSchool(School school)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri($"{Constants.EndPoint}")
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.DefaultUserAgent);

            var doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync($"/?groups&institution={school.Id}"));

            var groups = doc.DocumentNode.SelectNodes("//div[contains(@class, 'tab-pane')]/div/a")
                             .Where(x => x.Attributes["href"].Value.StartsWith("?"))
                             .Select(x => new Group
                             {
                                 RealId = int.Parse(x.ChildNodes[1].InnerText),
                                 SiteId = int.Parse(x.Attributes["href"].Value.Split('=')[1]),
                                 Name = Regex.Replace(x.ChildNodes[2].InnerText.Trim(), @"\s+", " ")
                             })
                             .Distinct()
                             .ToArray();

            return groups;
        }
    }
}