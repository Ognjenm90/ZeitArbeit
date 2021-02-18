using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mobile.DataGrid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevExpress.Mobile.Core.Containers;

   
namespace ZeitArbeit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List : ContentPage
    {
    
        public TimeWorked SelectedSaveData { get; set; }
        private long allWorkedTicks;
        public string allWorkedTime { get; set; }
        public string empty { get; set; }
       
        private ObservableCollection<TimeWorked> saveData = new ObservableCollection<TimeWorked>();
        // private BindingList<Orders> saveData1 = new BindingList<Orders>();
        // public ListView l = new ListView();
       

    

        public List()
        {
            this.BindingContext =this;
            InitializeComponent();
            Init();
            
           
            NavigationPage.SetHasNavigationBar(this, false);
        }

   
        public void Init()
        {
            // die zahl der Objekten die in Datenbank sind
            var enumerator = App.Dbcontroller.GetDBItems();

        
            if (enumerator != null)
            {
                //solange es die Objekten gibt die Zeit ausrechnen (in TimeWork Klasse) und zusetzen in ObservableCollection-saveData.
                while (enumerator.MoveNext())
                {
                    this.allWorkedTicks = this.allWorkedTicks + enumerator.Current.Ticks;
                    enumerator.Current.calculateTime();
                    this.saveData.Add(enumerator.Current);
                    
                }


                var report = new List<Object>();
             

                grid.ItemsSource = this.saveData;

            }
            else
            {
                grid.ItemsSource = this.saveData;
            }

        }
        //Navigation zum MainPage

        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());
        }
     
        //Zum Löschen oder zum Korrigieren ein Eintrag drauf tippen
        private void Grid_RowTap(object sender, RowTapEventArgs e)
        {
  //TimeWorked note =(TimeWorked)e.RowHandle;
         var id =(grid.GetRow(e.RowHandle).DataObject as TimeWorked);
            Navigation.PushAsync(new EditTime1(id));
        }
    }
}
