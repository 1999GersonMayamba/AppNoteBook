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
using AppCloudEditor.Droid.ServiceAndroid;
using AppCloudEditor.INTERFACE;


[assembly: Xamarin.Forms.Dependency(typeof(AndroidMessage))]
namespace AppCloudEditor.Droid.ServiceAndroid
{
    public class AndroidMessage : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void LongCenterMessageAlert(string message)
        {
            throw new NotImplementedException();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}