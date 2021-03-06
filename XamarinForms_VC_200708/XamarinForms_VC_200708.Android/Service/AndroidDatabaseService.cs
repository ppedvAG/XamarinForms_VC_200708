﻿using System;
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
using SQLite;
using Xamarin.Forms;
using XamarinForms_VC_200708.Droid.Service;
using XamarinForms_VC_200708.PersonenDb.Services;

//Mittels des Assambly-Attributs Dependency kann diese Klasse beim DependencyService angemeldet werden.
[assembly: Dependency(typeof(AndroidDatabaseService))]
namespace XamarinForms_VC_200708.Droid.Service
{
    //Diese Klasse erbt von dem allgemeinen Interface IDatabaseService, damit der DependencyService die Zuweisung durchführen kann
    public class AndroidDatabaseService : IDatabaseService
    {
        //Property, welche das Connection-Objekt beinhaltet
        public SQLiteConnection Con { get; set; }

        //Methode zum Etablieren der Verbindung
        public SQLiteConnection GetConnection()
        {
            //Kreieren des Datenbankpfads
            string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbName = "PersonenDb.db3";

            string path = Path.Combine(ordner, dbName);

            //Instanziierung und Rückgabe des Connection-Objekts
            Con = new SQLiteConnection(path);
            return Con;
        }
    }
}