using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitArbeit
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTime : ContentPage
	{
	//
        public NewTime()
        {
            InitializeComponent();
        
            startTimePicker.Time = DateTime.Now.TimeOfDay;
            endTimePicker.Time = DateTime.Now.TimeOfDay;
        }
        void OnTimeSelected(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            calculateTime();
        }
     
        void calculateTime()
        {
          
            TimeSpan timeSpan = endTimePicker.Time - startTimePicker.Time;
            long ticks = timeSpan.Ticks;
            long minutes = ticks / 600000000 ;
            long hours = 0;
            if (minutes >= 60)
            {
                hours = minutes / 60;
                minutes = minutes % 60;
            }
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            TimeSpan timeSpan = endTimePicker.Time - startTimePicker.Time;
            if (endTimePicker.Time >= startTimePicker.Time)
            {
                TimeWorked newTime = new TimeWorked()
                {

                    Ticks = timeSpan.Ticks,
                    Date = DatePicker.Date
                };
            
            newTime.calculateTime();
            newTime.calculateDay();
           

                
            App.Dbcontroller.saveDbItem(newTime);
            DisplayAlert("Meldung", "Ihre Arbeitszeit wurde gespeichert", "OK");
            }else { DisplayAlert("Meldung", "Ihre Anfangsarbeitszeit muss früher als Feierabend eingetragen werden", "OK"); }
        }

    }
}