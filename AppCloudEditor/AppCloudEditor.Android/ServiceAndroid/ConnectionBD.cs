using System;
using System.Collections.Generic;
using System.IO;
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
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionBD))]
namespace AppCloudEditor.Droid.ServiceAndroid
{
    public class ConnectionBD : Isqlite
    {
        public SQLiteConnection GetConnectionBD()
        {
            var dbase = "AppCloundEditorBD"; //Nome da base de dados
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData); //Nome da base de dados 
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path); //Pega a conexão da base de dados
            return connection;
        }
    }
}