using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitArbeit
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTime1 : ContentPage
	{
        private TimeWorked timeWorked = new TimeWorked();
        private ObservableCollection<TimeWorked> saveData = new ObservableCollection<TimeWorked>();
        public EditTime1 ()
		{
        
            InitializeComponent ();
          
        }
        //Navigation zur Einträge
        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new List());
        }
        public EditTime1(TimeWorked tw)
        {
           
             NavigationPage.SetHasNavigationBar(this, false);
            
            InitializeComponent();
            Init();
            this.timeWorked = tw;
            startTimePicker.Time = DateTime.Now.TimeOfDay;
            endTimePicker.Time = DateTime.Now.TimeOfDay;
        }
        public void Init()
        {
            //save data für diese Seite erstellen
            var enumerator = App.Dbcontroller.GetDBItems();
            if (enumerator != null)
                while (enumerator.MoveNext())
                {
                    this.saveData.Add(enumerator.Current);

                }
        }
        //die Zeit löschen
        private void OnDelete(object sender, EventArgs e)
        {
            DisplayAlert("Meldung", "Ihre Arbeitszeit von diesem Tag wurde gelöscht", "OK");
            this.saveData.Remove(this.timeWorked);
            App.Dbcontroller.DeleteDBItem(this.timeWorked.Id);
            
            Navigation.PushAsync(new List());
        }
        void OnTimeSelected(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            calculateTime();
        }
      //  Die "Ticks" in Zeit umwandeln
        void calculateTime()
        {
            TimeSpan timeSpan = endTimePicker.Time- startTimePicker.Time;
            long ticks = timeSpan.Ticks;
            long minutes = ticks / 600000000;
            long hours = 0;
            if (minutes >= 60)
            {
                hours = minutes / 60;
                minutes = minutes % 60;
            }


           
        }
        //die Zeit korrigieren
        private void OnEdit(object sender, EventArgs e)
        {
            if (endTimePicker.Time >= startTimePicker.Time) { 
                //alte Eintrag wird gelöscht
                this.saveData.Remove(this.timeWorked);
            App.Dbcontroller.DeleteDBItem(this.timeWorked.Id);
            TimeSpan timeSpan = endTimePicker.Time - startTimePicker.Time;
            TimeWorked newTime = new TimeWorked()
            {

                Ticks = timeSpan.Ticks,
                Date= DatePicker.Date
            };

            newTime.calculateTime();
            newTime.calculateDay();


                //neue Eintrag wird gespeichert
                App.Dbcontroller.saveDbItem(newTime);
            DisplayAlert("Meldung", "Ihre Arbeitszeit wurde gespeichert", "OK");
                Navigation.PushAsync(new List());
            }
            //Meldung wenn man feierabend früher als anfangszeit einträgt
            else { DisplayAlert("Meldung", "Ihre Anfangsarbeitszeit muss früher als Feierabend eingetragen werden", "OK"); }
        }
    }
}