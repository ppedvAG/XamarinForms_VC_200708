using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinForms_VC_200708.PersonenDb.Services;

//vgl. AndroidDatabaseService.cs
[assembly: Xamarin.Forms.Dependency(typeof(XamarinForms_VC_200708.Droid.Service.ToastService_Android))]
namespace XamarinForms_VC_200708.Droid.Service
{
    public class ToastService_Android : IToastService
    {
        public void ShowLong(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
        }

        public void ShowShort(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Short).Show();
        }
    }
}