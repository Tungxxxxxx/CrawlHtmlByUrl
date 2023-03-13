using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlHtmlByUrl
{
    public class VnExpress_TheThao
    {
        public static string VNEXPRESS_THE_THAO = @"https://vnexpress.net/bong-da";
        public static string HTTT_HOME = @"http://httt.piacom.com.vn/Home.aspx?MenuID=38112";
        public static List<string> GetAllLink()
        {
           HttpClient client = new HttpClient();
            string htmlTheThao = client.GetStringAsync(VNEXPRESS_THE_THAO).Result;
            //MatchCollection links = Regex.Matches(htmlTheThao, @"<h3 class=""title-news"">(.*?)</h3>");
            MatchCollection links = Regex.Matches(htmlTheThao, @"href=""https://vnexpress.net(.*?)""", RegexOptions.Singleline);
            List<string> res= new List<string>();

            foreach (var item in links)
            {
                var temp = item.ToString();
                if (temp.Contains(".html")||temp.Contains("#box_comment_vne"))
                {
                res.Add(temp);
                }
            }
            for (int i = 0; i < res.Count; i++)
            {
                for (int j = 0; j < res.Count; j++)
                {
                    if (i!=j && res[i]==res[j])
                    {
                        res.Remove(res[j]);
                    }
                }
            }
            return res;
        }  
        public static string GetHTTT_HOME()
        {
           HttpClient client = new HttpClient();
            string res = client.GetStringAsync(HTTT_HOME).Result;
            //MatchCollection links = Regex.Matches(htmlTheThao, @"<h3 class=""title-news"">(.*?)</h3>");
            //MatchCollection links = Regex.Matches(htmlTheThao, @"href=""https://vnexpress.net(.*?)""", RegexOptions.Singleline);

            return res;
        }
    }
}
