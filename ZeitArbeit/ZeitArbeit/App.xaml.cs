using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitArbeit.DataBase;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZeitArbeit
{
    public partial class App : Application
    {
        private static DataBaseController dbcontroller;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
         
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
      //DataBase
        public static DataBaseController Dbcontroller
        {
            get
            {
                if (dbcontroller == null)
                {

                    dbcontroller = new DataBaseController();
                }
                return dbcontroller;
            }
        }
        }
}
