using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_VC_200708.PersonenDb.Model
{
    public class Person
    {
        //Diese Model-Klasse wurde zur Verwendung durch SQLite optimiert. Dazu wurden Property-Attribute hinzugefügt.
        //Der Primary Key muss definiert sein; AutoIncrement zählt diesen automatisch hoch.
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //Properties, die nicht in der Datenbank vermerkt werden sollen, müssen mit Ignore markiert sein.
        [Ignore]
        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }
    }
}
