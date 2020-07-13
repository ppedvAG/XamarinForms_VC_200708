using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinForms_VC_200708.BspMVVM.Model;

namespace XamarinForms_VC_200708.BspMVVM.Service
{
    //In MVVM gehören Service- und Controller-Klassen mit zum Model
    //(bez. SQLite vgl. PersonenDb/Services)
    public class DbService
    {
        public static DbService Datenbank { get; set; } = new DbService();

        static object locker = new object();

        SQLiteConnection database;

        public DbService()
        {
            locker = new object();

            lock (locker)
            {
                database = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mvvm.db3"));

                database.CreateTable<Person>();
            }
        }

        public Person GetPerson(Guid id)
        {
            lock (locker)
            {
                return database.Get<Person>(id);
            }
        }

        public List<Person> GetPersonen()
        {
            lock (locker)
            {
                return database.Table<Person>().ToList();
            }
        }

        public int AddPerson(Person person)
        {
            lock (locker)
            {
                return database.Insert(person);
            }
        }

        public int UpdatePerson(Person person)
        {
            lock (locker)
            {
                return database.Update(person);
            }
        }

        public int DeletePerson(Person person)
        {
            lock (locker)
            {
                return database.Delete(person);
            }
        }
    }
}