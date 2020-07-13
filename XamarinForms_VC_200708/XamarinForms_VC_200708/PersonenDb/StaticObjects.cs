using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinForms_VC_200708.PersonenDb.Model;

namespace XamarinForms_VC_200708.PersonenDb
{
    //Statische Klasse mit globalen Objekten (kann auch Service- und Controllerobjekte beinhalten)
    public static class StaticObjects
    {
        private static ObservableCollection<Person> personList;
        public static ObservableCollection<Person> PersonList
        {
            get
            {
                if (personList == null)
                {
                    personList = new ObservableCollection<Person>()
                    {
                        new Model.Person() { Firstname = "Rainer", Lastname = "Zufall" }
                    };
                }
                return personList;
            }
            set { personList = value; }
        }
    }
}
