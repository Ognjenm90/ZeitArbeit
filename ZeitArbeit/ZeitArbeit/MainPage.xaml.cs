using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZeitArbeit
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
          //Uhr
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
time.Text=DateTime.Now.ToString("HH:mm:ss")

     );
                return true;
            });

          //die Tagen auf deutch
            string day="";
           if(DateTime.Now.DayOfWeek.ToString()=="Monday") {
                day = "Montag";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
            {
                day = "Dienstag";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
            {
                day = "Mittwoch";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
            {
                day = "Donnerstag";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
            {
                day = "Freitag";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Saturday")
            {
                day = "Sammstag";
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Sunday")
            {
                day = "Sonntag";
            }
            date.Text = day+ " " + DateTime.Now.ToShortDateString();
        } 
        
        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new NewTime());
        }

      /*  private void Button3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Note());
        }*/

        private void Button3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new List());
        }

    }
}
