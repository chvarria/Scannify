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
using Scannify.App_Code.Model;
using Xamarin.Forms;
using SQLite.Net.Interop;
using Environment = System.Environment;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(Scannify.Droid.Config))]
namespace Scannify.Droid
{
    class Config: IConfig
    {
        private string directorioBD;
        private ISQLitePlatform plataforma;

        public string DirectorioBD
        {
            get
            {
                if (string.IsNullOrEmpty(directorioBD))
                    directorioBD = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                return directorioBD;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get { return plataforma ?? (plataforma = new SQLitePlatformAndroid()); }
        }
    }
}