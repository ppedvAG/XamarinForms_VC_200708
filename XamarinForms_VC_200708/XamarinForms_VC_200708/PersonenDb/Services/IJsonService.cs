using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_VC_200708.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidJsonService
    public interface IJsonService
    {
        void SaveJson(object data);

        T LoadJson<T>();
    }
}
