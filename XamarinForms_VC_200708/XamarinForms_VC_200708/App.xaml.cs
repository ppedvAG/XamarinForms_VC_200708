using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_VC_200708.PersonenDb.Services;

namespace XamarinForms_VC_200708
{
    //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
    //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Zuweisung der MainPage-Property zu einer Page
            //MainPage = new MainPage();

            //Zuweisung der MainPage-Property zu einer NavigationPage (ermöglicht Stack-Navigation) mit Angabe der Startpage.
            //MainPage = new NavigationPage(new MainPage());

            //Zuweisung der MainPage-Property zu einer MasterDetailPage (vgl. BspLayouts/MasterDetail)
            MainPage = new BspNavigation.MasterDetail.MDP();
        }

        //Controller/Service als statische Property in der App-Klasse (ermöglicht globalen Zugriff über 'App.PropertyName')
        private static PersonenDbController personenDatenbank;
        public static PersonenDbController PersonenDatenbank
        {
            get
            {
                //Instanziierung, falls noch nicht geschehen
                if (personenDatenbank == null)
                    personenDatenbank = new PersonenDbController();
                return personenDatenbank;
            }
            set { personenDatenbank = value; }
        }


        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
