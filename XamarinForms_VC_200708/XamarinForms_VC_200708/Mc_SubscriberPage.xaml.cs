using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinForms_VC_200708
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mc_SubscriberPage : ContentPage
    {
        //vgl. auch MainPage.xaml
        public Mc_SubscriberPage()
        {
            InitializeComponent();

            //Abonieren einer Nachricht über das MessagingCenter unter Angabe von 
            //<Sender, Nachrichtentyp>(Empfänger, Titel, Methode zum Handeln des Inhalts)
            MessagingCenter.Subscribe<MainPage, string>(this, "GesendeterText", SetzeText);
        }

        //Methode, welche die MC-Nachricht handelt. Diese wird automatisch ausgeführt, wenn die Nachricht eintrifft
        private void SetzeText(object sender, string text)
        {
            Lbl_Main.Text = text;
        }
    }
}