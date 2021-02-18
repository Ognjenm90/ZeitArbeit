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
    //Alte Version
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Note : ContentPage
	{
        public TimeWorked SelectedSaveData { get; set; }
        private long allWorkedTicks;
        public string allWorkedTime { get; set; }
        private ObservableCollection<TimeWorked> saveData = new ObservableCollection<TimeWorked>();
        
        


        

        public Note()
        {
            InitializeComponent();
            Init();
            this.BindingContext = this;
          
        }

        public void calculateTime()
        {
            long minutes = this.allWorkedTicks / 600000000;
            long hours = 0;
            if (minutes >= 60)
            {
                hours = minutes / 60;
                minutes = minutes % 60;
            }
            this.allWorkedTime = String.Format("{0} :{1}", hours, minutes);
               }
        public void Init()
        {
            
            var enumerator = App.Dbcontroller.GetDBItems();
            
              if (enumerator != null)
                while (enumerator.MoveNext())
            {
                this.allWorkedTicks = this.allWorkedTicks + enumerator.Current.Ticks;
                this.saveData.Add(enumerator.Current);

                }
            else
            {

            }
            var sorted = saveData.OrderBy(x => x.Date)
                  .ToList();
            calculateTime();
            Console.WriteLine(this.allWorkedTime);
            //  TimeListView.ItemsSource = this.saveData;
           
             TimeListView.ItemsSource = sorted;
           
             TimeListView.ItemTapped += OnDelete;


}
        void OnDelete(object sender, ItemTappedEventArgs e)
        {
            TimeWorked note = (TimeWorked)e.Item;
            Navigation.PushAsync(new EditTime1(note));


            /* con.DeleteAsync(SelectedSaveData);
             saveData.Remove(SelectedSaveData);*/
            /*   Navigation.PushAsync(new NewTime());

               var item = (ToolbarItem)sender;
                var model = (TimeWorked)item.CommandParameter;
               Navigation.PushAsync(new EditTime(model));*/
            /* this.saveData.Remove(model);
              App.Dbcontroller.DeleteDBItem(model.Id);*/
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
