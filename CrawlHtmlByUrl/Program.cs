using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlHtmlByUrl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine(CrawlHTML.ExportDataEnd(@"https://vnexpress.net/truyen-thong-indonesia-khen-u20-viet-nam-phi-thuong-4577561.html"));
           // var temp = VnExpress_TheThao.GetAllLink();
          //  foreach (var item in temp)
           // {
           //     Console.WriteLine(item);
           //     Console.WriteLine(CrawlHTML.ExportDataEnd(item.Replace(@"href=""", "").Replace(@"""","")));
            //}
            Console.WriteLine(VnExpress_TheThao.GetHTTT_HOME());
            Console.ReadLine();
        }
    }
}
