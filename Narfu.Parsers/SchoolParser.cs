using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Narfu.Domain;

namespace Narfu.Parsers
{
    public class SchoolParser
    {
        /// <summary>
        /// Получить список высших школ
        /// </summary>
        /// <returns>Массив с высшими школами</returns>
        public static async Task<School[]> GetSchools()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.EndPoint)
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.DefaultUserAgent);

            var doc = new HtmlDocument();
            doc.Load(await client.GetStreamAsync("/"));
            var schools = doc.DocumentNode.SelectNodes("//div[@id='classic']/div[contains(@class, 'institution_button')]/a")
                             .Select(x => new School
                             {
                                 Id = int.Parse(x.Attributes["href"].Value.Split('=')[1]),
                                 Url = $"{Constants.EndPoint}{x.Attributes["href"].Value}",
                                 Name = x.InnerText.Trim()
                             })
                             .Distinct()
                             .ToArray();
            return schools;
        }
    }
}
