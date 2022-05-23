using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDIAZ.Semana7.Clase;
using System.IO;
using VDIAZ.Semana7.Clase.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteClientAndroid))]
namespace VDIAZ.Semana7.Clase.Droid
{
    public class SQLiteClientAndroid : DBManager
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}