using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_VC_200708.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidToastService
    public interface IToastService
    {
        void ShowLong(string msg);
        void ShowShort(string msg);
    }
}