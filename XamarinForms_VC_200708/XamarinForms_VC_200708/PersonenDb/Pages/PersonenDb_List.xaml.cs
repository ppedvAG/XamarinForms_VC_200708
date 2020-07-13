using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_VC_200708.PersonenDb.Services;

using System.Collections.ObjectModel;

namespace XamarinForms_VC_200708.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonenDb_List : ContentPage
    {
        public PersonenDb_List()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Zuweisung der lokalen Liste mit den Datenbank-Inhalten
            StaticObjects.PersonList = new System.Collections.ObjectModel.ObservableCollection<Model.Person>(App.PersonenDatenbank.GetPersonen());

            //Zuweisung der ItemSource zur Liste
            LstV_Liste.ItemsSource = StaticObjects.PersonList;
        }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", $"Soll {p.Firstname} {p.Lastname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                StaticObjects.PersonList.Remove(p);
                //Löschen aus Datenbank
                App.PersonenDatenbank.DeletePerson(p);

                //Ausgabe einer Toast-Nachricht mittels ToastController
                ToastController.ShowToastMessage("Person gelöscht", ToastDuration.Short);
            }

            //Aktualisieren der GUI
            RefreshPage();
        }


        //Methode zum Aktualisieren der GUI
        private void RefreshPage()
        {
            //Setzen der veränderten Property auf null
            LstV_Liste.ItemsSource = null;
            //Neuzuweisung der veränderten Property
            LstV_Liste.ItemsSource = StaticObjects.PersonList;
        }

        //EventHandler zum Speichern der Liste (mittels Json)
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Aufruf der Save-Methode des JsonControllers
            JsonController.Save(StaticObjects.PersonList);
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste gespeichert", ToastDuration.Short);
        }

        //EventHandler zum Laden der Liste (mittels Json)
        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            //Neuzuweisung der lokalen Liste mit durch JsonController geladenen Datei
            StaticObjects.PersonList = new ObservableCollection<Model.Person>(JsonController.Load<List<Model.Person>>());
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste geladen", ToastDuration.Short);
            //Aktualisierung der GUI
            RefreshPage();
        }
    }
}