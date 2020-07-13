using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using XamarinForms_VC_200708.Uebungen.GoogleBooks.Model;

namespace XamarinForms_VC_200708.Uebungen.GoogleBooks.Service
{
    //Service-Klasse zum Zugriff auf GoogleBooks
    public class BookService
    {
        public GBook FindBooks(string searchstring)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                //WebClient läd Bücherliste herunter
                json = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={searchstring}");
            }

            //Json deserialisiert den String in Model-Objekte
            return JsonConvert.DeserializeObject<GBook>(json);
        }
    }
}
