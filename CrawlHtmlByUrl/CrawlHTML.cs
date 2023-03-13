using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlHtmlByUrl
{
    public class CrawlHTML
    {
        public static string GetHTMLByUrl(string url)
        {
            string res = "";
            HttpClient client = new HttpClient();
            string html = client.GetStringAsync(url).Result;
            MatchCollection texts = Regex.Matches(html, @"<p class=""Normal"">(.*?)</p>", RegexOptions.Singleline);
            foreach (Match text in texts)
            {
                res += text;
            }
            return res;
        }
        public static MatchCollection GetElementReplace(string html)
        {
            MatchCollection matches = Regex.Matches(html, @"<(.*?)>");
            return matches;
        }
        public static string ExportDataEnd(string url)
        {
            string html = GetHTMLByUrl(url);
            var matchs = GetElementReplace(html);
            foreach (var item in matchs)
            {
               html= html.Replace(item.ToString(), "");
            }
            return html;
        }
    }
}
