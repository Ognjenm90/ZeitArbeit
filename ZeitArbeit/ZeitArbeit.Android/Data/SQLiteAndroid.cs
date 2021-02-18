using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeitArbeit.DataBase;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;
using ZeitArbeit.Droid.Data;
using System.IO;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace ZeitArbeit.Droid.Data
{
    class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }
        public SQLiteConnection GetConnection()
        {
            string fileName = "hours_db.sqlite";
            string fileLokation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLokation, fileName);
            var con = new SQLite.SQLiteConnection(full_path);
            return con;
        }
    }
}