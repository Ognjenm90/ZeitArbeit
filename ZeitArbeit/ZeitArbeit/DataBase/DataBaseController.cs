using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZeitArbeit.DataBase
{
   public class DataBaseController
    {
        private static object locker = new Object();
        private SQLiteConnection database;

        public DataBaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            this.database.CreateTable<TimeWorked>();
     
        }
        public IEnumerator<TimeWorked> GetDBItems()
        {
           lock (locker)
            {
                if (this.database.Table<TimeWorked>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return this.database.Table<TimeWorked>().GetEnumerator();

                }
            }
        }

        public int saveDbItem(TimeWorked time)
        {
            lock (locker)
            {
                if (time.Id != 0)
                {
                    this.database.Update(time);
                    return time.Id;

                }
                else
                {
                    return this.database.Insert(time);
                }


            }

        }

        public int DeleteDBItem(int id)
        {
            return this.database.Delete<TimeWorked>(id);
        }
    }
}

