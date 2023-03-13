using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TruyCapCanLogin
{
    internal class Login
    {
        public static void loginBtn_Click()
        {
            string benutzername = @"TUNGPT";
            string passwort = @"Tungha123";
            string cookieHeader;
            //passwort = changeString(passwort);
            //benutzername = changeString(benutzername);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://httt.piacom.com.vn/Default.Aspx");
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;

            request.Method = "POST";
            string postData = "login=hans-neo@web.de&password=xxxxx&step=login";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string Text = "";

            foreach (Cookie cook in response.Cookies)
            {
                Text += "COOKIE: " + cook.Name + " = " + cook.Value + "\r\n";

            }
            request.AllowAutoRedirect = false;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            //webBrowser1.Navigate("https://secure.bodytel.com/de/mybodytel.html");
        }
        public static void loginBtn_Click2()
        {
            string url = @"http://httt.piacom.com.vn/";
            string url2 = @"http://httt.piacom.com.vn/Home.aspx?MenuID=38121";
            string benutzername = @"TUNGPT";
            string passwort = @"Tungha123";
            HttpWebRequest http = WebRequest.Create(url) as HttpWebRequest;
            http.KeepAlive = true;
            http.Method = "POST";
            http.ContentType = "application/x-www-form-urlencoded";
            string postData = "usercode=" + benutzername + "&userpassword=" + passwort;
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
            http.ContentLength = dataBytes.Length;
            using (Stream postStream = http.GetRequestStream())
            {
                postStream.Write(dataBytes, 0, dataBytes.Length);
            }
            HttpWebResponse httpResponse = http.GetResponse() as HttpWebResponse;
            // Probably want to inspect the http.Headers here first
            http = WebRequest.Create(url2) as HttpWebRequest;
            http.CookieContainer = new CookieContainer();
            http.CookieContainer.Add(httpResponse.Cookies);
            HttpWebResponse httpResponse2 = http.GetResponse() as HttpWebResponse;
        }

        private string changeString(string myString)
        {

            myString = myString.Replace("System.Windows.Controls.TextBox: ", "");
            return myString;
        }
    }
}
