﻿using ProgamacionRadEx.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ProgamacionRadEx
{
    public partial class App : Application
    {

        static DataBase db;

        public static DataBase Database
        {
            get
            {
                var dbpath = String.Empty;
                var namedb = String.Empty;
                var fullpath = String.Empty;

                dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                namedb = "DBPerson.db3";
                fullpath = Path.Combine(dbpath, namedb);

                if (db == null)
                {
                    db = new DataBase(fullpath);
                }

                return db;
            }
        }




        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Views.PageListPersonas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
