using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinForms_VC_200708.Droid.Service;
using XamarinForms_VC_200708.PersonenDb.Services;

//vgl. AndroidDatabaseService.cs
[assembly: Dependency(typeof(AndroidJsonService))]
namespace XamarinForms_VC_200708.Droid.Service
{
    public class AndroidJsonService : IJsonService
    {
        private static string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "jsonfile.txt");

        public T LoadJson<T>()
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();

            string jsonString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void SaveJson(object data)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}