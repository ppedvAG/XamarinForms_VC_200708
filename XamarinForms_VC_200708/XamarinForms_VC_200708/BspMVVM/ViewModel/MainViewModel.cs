using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinForms_VC_200708.BspMVVM.Model;
using XamarinForms_VC_200708.BspMVVM.Service;
using XamarinForms_VC_200708.PersonenDb.Services;

namespace XamarinForms_VC_200708.BspMVVM.ViewModel
{
    //Das ViewModel dient als Verbindungsklasse zwischen einem View und den Model- und Controllerklassen.
    //Mittels des INotifyPropertyChanged-Interfaces kann das View über Property-Veränderungen informiert werden.
    public class MainViewModel : INotifyPropertyChanged
    {
        //zugehöriges View (zum Zugriff auf Page-Methoden wie z.B. DisplayAlert)
        public Page ContextPage { get; set; }

        //Properties zum Anbinden an das View (.NET-Properties benötigen bei Veränderung  einen Eventwurf, um das View 
        //über die Veränderung zu informieren
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public bool IsRefreshing { get; set; }

        //Diese Property verweist direkt auf die entsprechende Property im Model
        public ObservableCollection<Model.Person> PersonenListe
        {
            get { return Model.Person.PersonenListe; }
            set { Model.Person.PersonenListe = value; }
        }

        //Command-Properties werden benötigt, um Eventwürfe auf EventHandler umzuleiten
        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }
        public Command RefreshCmd { get; set; }

        //Konstruktor
        public MainViewModel()
        {
            //Property-Initialisierungen
            PersonenListe = new ObservableCollection<Model.Person>(DbService.Datenbank.GetPersonen().ToList());

            //Initialisierung der Command-Objekte mit Übergabe des auszuführenden EventHandlers
            HinzufuegenCmd = new Command(AddPerson);
            LoeschenCmd = new Command(DeletePerson);
            RefreshCmd = new Command(Refresh);

            //Aktualisierung der GUI
            Refresh();
        }

        //Methode zur Aktualisierung des ListViews
        private void Refresh()
        {
            PersonenListe = new ObservableCollection<Model.Person>(DbService.Datenbank.GetPersonen().ToList());
            IsRefreshing = false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonenListe"));
        }

        //Durch das Interface gefordertes Event
        public event PropertyChangedEventHandler PropertyChanged;

        //EventHandler-Methoden
        private void AddPerson()
        {
            //Erstellen und Hinzufügen einer neuen Person
            Person neuePerson = new Person()
            {
                Firstname = Vorname,
                Lastname = Nachname
            };

            PersonenListe.Add(neuePerson);
            DbService.Datenbank.AddPerson(neuePerson);

            //Leeren der UI-Elemente
            Vorname = String.Empty;
            Nachname = String.Empty;

            //Informieren das Views über Veränderung in den Properties
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vorname"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nachname"));
        }

        private async void DeletePerson(object p)
        {
            //Aufruf einer 'MessageBox' und Abfrage der User-Antwort über ContextPage-Property
            bool result = await ContextPage.DisplayAlert("Löschen", "Soll die Person wirklich gelöscht weden?", "Ja", "Nein");

            if (result)
            {
                DbService.Datenbank.DeletePerson(p as Person);
                PersonenListe.Remove(p as Person);

                Refresh();
            }
        }

    }
}
