using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Collections.ObjectModel;

namespace ZeitArbeit
{//Zeit Klasse
    public class TimeWorked 
    {
        
    [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public String Datum { get; set; }
        public DateTime Monat { get; set; }
        public string Tag { get; set; }
        public long Ticks { get; set; }
        public double Hours { get; set; }
        public double Stunden { get; set; }
        public long Minutes { get; set; }
        public string Time { get; set; }
        public string Zeit { get; set; }
        public string Day { get; set; }
      
       
    
       
            public void calculateDay()
        {
Day= String.Format("{0} /{1} /{2}",Date.Day, Date.Month,Date.Year);

        }
        //Zeit ausrechnen
        public void calculateTime()
        {
            //Damit die Worter auf Deutch angezeigt werden
            Tag = Day;
            Zeit = Time;
            Datum = Date.ToString("dd / MM / yyyy");
           Monat = Date;
            Stunden = Hours;
            long minutes = Ticks / 600000000;
            long hours = 0;
           
            if (minutes >= 60)
            {
                hours = minutes / 60;
                
                minutes = minutes % 60;
              
                
            }

            
          //gesamte Stunden in IndustrieZeit umrechnen
                Hours = (double)TimeSpan.FromTicks(Ticks).TotalHours;
            Hours = Math.Round(Hours, 2);
           
            Time = String.Format("{0} :{1}", hours, minutes);
        }
    }
}

