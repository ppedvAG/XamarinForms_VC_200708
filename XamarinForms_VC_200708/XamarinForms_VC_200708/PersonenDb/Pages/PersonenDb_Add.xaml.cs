using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_VC_200708.PersonenDb.Model;
using XamarinForms_VC_200708.PersonenDb.Services;

namespace XamarinForms_VC_200708.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonenDb_Add : ContentPage
    {
        //Konstruktor
        public PersonenDb_Add()
        {
            // GUI - Initialisierung
            InitializeComponent();

            //Completed-EventHandler-Zuweisung (User-Komport)
            Entry_Firstname.Completed += (s, e) => Entry_Lastname.Focus();
            Entry_Lastname.Completed += Btn_AddPerson_Clicked;
            Entry_Lastname.Completed += (s, e) => Entry_Firstname.Focus();
        }

        //Methode zum Hinzufügen einer neuen Person
        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            //Objektinstanziierung mit User-Eingaben
            Person person = new Person()
            {
                Firstname = Entry_Firstname.Text,
                Lastname = Entry_Lastname.Text
            };

            //Hinzufügen zur lokalen Liste
            StaticObjects.PersonList.Add(person);
            //Hinzufügen zur Datenbank
            App.PersonenDatenbank.AddPerson(person);

            //Ausgabe eines Toasts über den ToastController
            ToastController.ShowToastMessage("Person hinzugefügt", ToastDuration.Short);

            //Leeren  der Eingabefelder
            Entry_Firstname.Text = string.Empty;
            Entry_Lastname.Text = string.Empty;

        }
    }
}