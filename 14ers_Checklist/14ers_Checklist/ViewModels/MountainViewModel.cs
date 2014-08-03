using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _14ers_Checklist.Models; 

namespace _14ers_Checklist.ViewModels
{
    public class MountainViewModel : BaseViewModel
    {
        private DataBaseContext.Mountain databaseInstance;
        public TimeSpan timeSpan; 
        
        public MountainViewModel(DataBaseContext.Mountain mountain)
        {
            this.databaseInstance = mountain;
            this.db = App.DB;
            this.timeSpan = new TimeSpan(0, 0, mountain.Time);  
        }
        public string Name
        {
            get { return databaseInstance.Name; }
        }
        public string Range
        {
            get { return databaseInstance.Range; }
        }
        public int Height
        {
            get { return databaseInstance.Height; }
        }
        public string HeightString
        {
            get { return String.Format("{0:n0}",databaseInstance.Height); }
        }
        public DateTime? Date
        {
            get { return databaseInstance.Date; }
        }
        public TimeSpan Time
        {
            get 
            {
                return timeSpan; 
            }
            set
            {
                this.timeSpan = value;
                databaseInstance.Time = (int)this.timeSpan.TotalSeconds; 
            }
        }
        public String Message
        {
            get { return databaseInstance.Message; }
        }

        public Boolean Check
        {
            get { return databaseInstance.Check; }
            set 
            {
                databaseInstance.Check = value; 
                db.SubmitChanges();
                NotifyPropertyChanged("Check"); 
            }
        }
        
        public void Update_Ascent(DateTime date, TimeSpan time, string log)
        {
            databaseInstance.Date = date;
            databaseInstance.Time = (int)time.TotalSeconds;
            databaseInstance.Message = log;
            db.SubmitChanges();
            NotifyPropertyChanged("Date");
            NotifyPropertyChanged("Time");
            NotifyPropertyChanged("Message");
        }

    }
}
